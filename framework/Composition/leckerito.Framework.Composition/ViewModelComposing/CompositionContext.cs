using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace leckerito.Framework.Composition.ViewModelComposing
{
    public delegate Task ExtendViewModel(Type typeOfInstance, dynamic instance, CompositionContext context);

    public class CompositionContext
    {

        private readonly IViewModelComposer composer;

        public CompositionContext(IViewModelComposer composer, HttpContext httpContext, RouteData routeData)
        {
            this.composer = composer;
            this.HttpContext = httpContext;
            this.RouteData = routeData;
        }

        public HttpContext HttpContext { get;  }
        public RouteData RouteData { get;  }

        public async Task<T> Compose<T>(T viewModel) where T : class, new()
        {
            return await composer.Compose<T>(viewModel, this);
        }

        public async Task<IEnumerable<T>> Compose<T>(IEnumerable<T> viewModel) where T : class, new()
        {
            return await composer.Compose<T>(viewModel, this);
        }

    }
}