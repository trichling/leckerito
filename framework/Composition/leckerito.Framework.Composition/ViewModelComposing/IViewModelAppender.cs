using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace leckerito.Framework.Composition.ViewModelComposing
{
    public interface IViewModelAppender
    {
        
        bool WillAppendTo(System.Type typeOfViewModel);
        Task<dynamic> AppendTo(dynamic viewModel, CompositionContext context);
        Task<IEnumerable<dynamic>> AppendTo(IEnumerable<dynamic> list, CompositionContext context);

    }

    public interface IViewModelAppender<T> : IViewModelAppender 
    {
        
        Task<T> AppendTo(T viewModel, CompositionContext context);
        Task<IEnumerable<T>> AppendTo(IEnumerable<T> list, CompositionContext context);

    }
}