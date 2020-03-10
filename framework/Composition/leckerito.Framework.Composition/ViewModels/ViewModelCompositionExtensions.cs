
using Microsoft.Extensions.DependencyInjection;

namespace leckerito.Framework.Composition.ViewModels
{
    public static class ViewModelCompositionExtensions
    {
        public static IServiceCollection AddViewModelComposition(this IServiceCollection services)
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.DiscoverFromAllLoadedAssemblies();

            services.AddSingleton<IViewModelAppenderProvider>(viewModelAppenderLocator);
            services.AddTransient<IViewModelComposer, ViewModelComposer>();

            return services;
        }
    }
}