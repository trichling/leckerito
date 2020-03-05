using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lunchero.Ordering.NServiceBusHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace lunchero.Ordering.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseNServiceBus(hostBuilder => {
                    return new EndpointHost().ConfigureSendOnlyApiEndpoint();
                })
                .UseDefaultServiceProvider(options => {
                    options.ValidateOnBuild = false;
                    options.ValidateScopes = false;
                });
    }
}
