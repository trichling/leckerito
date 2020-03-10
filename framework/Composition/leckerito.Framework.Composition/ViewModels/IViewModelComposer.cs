using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace leckerito.Framework.Composition.ViewModels
{
    public interface IViewModelComposer
    {
        Task<TViewModel> Compose<TViewModel>(TViewModel viewModel, CompositionContext context); 
        Task<IEnumerable<TViewModel>> Compose<TViewModel>(IEnumerable<TViewModel> list, CompositionContext context);
    }
}