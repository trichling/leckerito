using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace leckerito.Framework.Composition.ViewModels
{


    public class ViewModelComposer : IViewModelComposer
    {
        private readonly IViewModelAppenderProvider provider;
        public ViewModelComposer(IViewModelAppenderProvider provider)
        {
            this.provider = provider;
        }

        public async Task<TViewModel> Compose<TViewModel>(TViewModel viewModel, CompositionContext context) 
        {
            var appenders = provider.AppendersFor<TViewModel>();
            foreach (var appender in appenders)
                viewModel = await appender.AppendTo(viewModel, context);

            return viewModel;
        }

        public async Task<IEnumerable<TViewModel>> Compose<TViewModel>(IEnumerable<TViewModel> list, CompositionContext context) 
        {
            var appenders = provider.AppendersFor<TViewModel>();
            foreach (var appender in appenders)
                list = await appender.AppendTo(list, context);

            return list;
        }

    }
}