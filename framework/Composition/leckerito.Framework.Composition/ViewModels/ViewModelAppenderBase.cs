using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace leckerito.Framework.Composition.ViewModels
{
    public abstract class ViewModelAppenderBase<T> : IViewModelAppender<T> where T: class, new()
    {
        public abstract Task<T> AppendTo(T viewModel, CompositionContext context);

        public abstract Task<IEnumerable<T>> AppendTo(IEnumerable<T> list, CompositionContext context);


        public Task<dynamic> AppendTo(dynamic viewModel, CompositionContext context)
        {
            return (dynamic)AppendTo((T)viewModel, context);
        }

        public async Task<IEnumerable<dynamic>> AppendTo(IEnumerable<dynamic> list, CompositionContext context)
        {
            var result = await AppendTo(list.Cast<T>(), context);
            return result.Cast<dynamic>();
        }

        public bool WillAppendTo(Type typeOfViewModel)
        {
            return typeof(T).IsAssignableFrom(typeOfViewModel) ||
                    typeof(IEnumerable<T>).IsAssignableFrom(typeOfViewModel);
        }
    }

   
}