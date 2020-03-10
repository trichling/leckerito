using Microsoft.Extensions.DependencyInjection;

namespace leckerito.Framework.Composition.Commands
{
    public static class CommandAttacherExtensions
    {
        public static IServiceCollection AddCommandAttacher(this IServiceCollection services)
        {
            var commandAttacherLocator = new CommandAttacherLocator();
            commandAttacherLocator.DiscoverFromAllLoadedAssemblies();

            services.AddSingleton<ICommandAttacherProvider>(commandAttacherLocator);
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            return services;
        }
    }
}