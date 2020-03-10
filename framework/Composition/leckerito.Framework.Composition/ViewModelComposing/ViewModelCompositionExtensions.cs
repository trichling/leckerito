
using Microsoft.Extensions.DependencyInjection;

namespace leckerito.Framework.Composition.ViewModelComposing
{
    public static class ViewModelCompositionExtensions
    {
        public static IServiceCollection AddViewModelComposition(this IServiceCollection services)
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            services.AddSingleton<IViewModelAppenderProvider>(viewModelAppenderLocator);
            services.AddTransient<IViewModelComposer, ViewModelComposer>();

            return services;
        }
    }
}