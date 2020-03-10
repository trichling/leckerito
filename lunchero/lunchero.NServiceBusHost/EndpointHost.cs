using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using NServiceBus.FluentConfiguration.Core;
using NServiceBus.FluentConfiguration.WebApi;

namespace lunchero.NServiceBusHost
{
    public class EndpointHost
    {

        public static readonly string EndpointName = "lunchero";
        private readonly string nsbPersistenceConnectionString;
        private readonly string nsbTransportConnectionString;
        private readonly IConfiguration configuration;
        private readonly IServiceCollection services;
        private IEndpointInstance endpoint;
        private IManageAnEndpoint endpointManager;

        public EndpointHost()
            : this(new ServiceCollection())
        {}

        public EndpointHost(IServiceCollection services)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local";
            configuration = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Program).Assembly)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();

            var accessKey = configuration["NServiceBusAccessKey"];
            nsbPersistenceConnectionString = configuration.GetConnectionString("NServiceBusPersistence");
            nsbTransportConnectionString = string.Format(configuration.GetConnectionString("NServiceBusTransport"), accessKey);


            this.services = services;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEndpointInstance>(s => this.endpoint);
        }

        public async Task Start()
        {
            ConfigureServices(this.services);

            endpointManager = 
                ConfigureEndpoint(this.services)
                .ManageEndpoint();

            endpointManager.Start();

            endpoint = endpointManager.Instance;
        }

        public async Task Stop()
        {
            await endpoint?.Stop();
        }

        public IConfigureAnEndpoint ConfigureEndpoint(IServiceCollection services)
        {
            return services.AddNServiceBus()
                .WithEndpoint(EndpointName)
                .WithTransport<AzureServiceBusTransport>(transport => {
                    transport.ConnectionString(nsbTransportConnectionString);
                    transport.RuleNameShortener(s => s.Substring(s.Length - 49));
                })
                .WithRouting(routing => {
                    routing.RouteToEndpoint(typeof(Contracts.Messages.MyMessage).Assembly, EndpointName);
                })
                .WithConventions(conventions => {
                    conventions.DefiningMessagesAs(t => t.Namespace.EndsWith("Messages"));
                    conventions.DefiningCommandsAs(t => t.Namespace.Contains("Commands"));
                    conventions.DefiningEventsAs(t => t.Namespace.Contains("Events"));
                })
                .WithPersistence<SqlPersistence>(persistence => {
                    persistence.ConnectionBuilder(() => new SqlConnection(nsbPersistenceConnectionString));
                    persistence.SqlDialect<SqlDialect.MsSqlServer>();
                    persistence.TablePrefix(EndpointName);
                })
                .WithDependencyInjection(this.services)
                .WithConfiguration(cfg => cfg.EnableInstallers());
        }

        public EndpointConfiguration ConfigureSendOnlyApiEndpoint()
        {
            return new NServiceBus.FluentConfiguration.Core.ConfigureNServiceBus()
                .WithEndpoint(EndpointName + ".Sender", cfg => {
                    cfg.SendOnly();
                })
                .WithTransport<AzureServiceBusTransport>(transport => {
                    transport.ConnectionString(nsbTransportConnectionString);
                    transport.RuleNameShortener(s => s.Substring(s.Length - 49));
                })
                .WithRouting(routing => {
                    routing.RouteToEndpoint(typeof(Contracts.Messages.MyMessage).Assembly, EndpointName);
                })
                .WithConventions(conventions => {
                    conventions.DefiningMessagesAs(t => t.Namespace.EndsWith("Messages"));
                    conventions.DefiningCommandsAs(t => t.Namespace.Contains("Commands"));
                    conventions.DefiningEventsAs(t => t.Namespace.Contains("Events"));
                })
                .Configuration;
        }

    }

    public static class IConfigureAnEndpointExtensions
    {

        public static IConfigureAnEndpoint WithDependencyInjection(this IConfigureAnEndpoint endpointConfiguration, IServiceCollection services)
        {
            endpointConfiguration.WithConfiguration(config => {
                config.UseContainer(new AutofacServiceProviderFactory(containerBuilder =>
                {
                    containerBuilder.Populate(services);
                }));
            });

            return endpointConfiguration;
        }

    }

}

