using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace leckerito.Framework.Composition.ViewModels
{
    public delegate Task ExtendViewModel(Type typeOfInstance, dynamic instance, CompositionContext context);

    public class CompositionContext
    {

        private readonly IViewModelComposer composer;

        public CompositionContext(IViewModelComposer composer)
        {
            this.composer = composer;
        }

        public HttpContext HttpContext { get; set; }

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