using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using leckerito.Framework.Composition.ViewModelComposing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace leckerito.Framework.Composition.Tests
{
    public class ViewModelCompositionTests
    {
        [Fact]
        public void CanDiscoverSomeAppender()
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            Assert.Equal(2, viewModelAppenderLocator.Appenders.Count());
        }

        [Fact]
        public void CanDiscoverFromAllAssemblies()
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            Assert.Equal(1, viewModelAppenderLocator.Appenders.Count());
        }

        [Fact]
        public async Task CanComposeSomeViewModel()
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            var viewModelBuilder = new ViewModelComposer(viewModelAppenderLocator);
            var viewModel = new SomeViewModel();
            viewModel = await viewModelBuilder.Compose<SomeViewModel>(viewModel, new CompositionContext(viewModelBuilder, new DefaultHttpContext(), new RouteData())).ConfigureAwait(false);

            Assert.Equal("Hi, I am provided by SomeViewModelAppender", viewModel.ProvidedBySomeAppender);
        }

        [Fact]
        public async Task CanComposeToExistingInstanceOfSomeViewModel()
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            var viewModel = new SomeViewModel();
            var viewModelBuilder = new ViewModelComposer(viewModelAppenderLocator);
            viewModel = await viewModelBuilder.Compose(viewModel, new CompositionContext(viewModelBuilder, new DefaultHttpContext(), new RouteData())).ConfigureAwait(false);

            Assert.Equal("Hi, I am provided by SomeViewModelAppender", viewModel.ProvidedBySomeAppender);
        }

        [Fact]
        public async Task CanComposeToListOfSomeViewModel()
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            var viewModel = Enumerable.Range(0, 10).Select(i => new SomeViewModel() { Id = Guid.NewGuid() });
            var viewModelBuilder = new ViewModelComposer(viewModelAppenderLocator);
            viewModel = await viewModelBuilder.Compose<SomeViewModel>(viewModel, new CompositionContext(viewModelBuilder, new DefaultHttpContext(), new RouteData())).ConfigureAwait(false);

            Assert.True(viewModel.All(vm => vm.ProvidedBySomeAppender == "Hi, I am provided by SomeViewModelAppender"));
        }

        [Fact]
        public async Task CanComposeViewModelWithList()
        {
            var viewModelAppenderLocator = new ViewModelAppenderLocator();
            viewModelAppenderLocator.Discover();

            var viewModel = new ViewModelWithListOfSomeViewModel();
            var viewModelBuilder = new ViewModelComposer(viewModelAppenderLocator);
            viewModel = await viewModelBuilder.Compose(viewModel, new CompositionContext(viewModelBuilder, new DefaultHttpContext(), new RouteData())).ConfigureAwait(false);

        }
    }



    public class SomeViewModelAppender : ViewModelAppenderBase<SomeViewModel>
    {
        public override Task<SomeViewModel> AppendTo(SomeViewModel viewModel, CompositionContext context)
        {
            viewModel.ProvidedBySomeAppender = $"Hi, I am provided by {nameof(SomeViewModelAppender)}";
            return Task.FromResult(viewModel);
        }

        public override async Task<IEnumerable<SomeViewModel>> AppendTo(IEnumerable<SomeViewModel> list, CompositionContext context)
        {
            var result = new List<SomeViewModel>();

            foreach (var item in list)
                result.Add(await AppendTo(item, context));

            return result;
        }
    }

    public class ViewModelWithListOfSomeViewModelAppender : ViewModelAppenderBase<ViewModelWithListOfSomeViewModel>
    {
        public override async Task<ViewModelWithListOfSomeViewModel> AppendTo(ViewModelWithListOfSomeViewModel viewModel, CompositionContext context)
        {
            viewModel.SomeViewModels = new List<SomeViewModel>();

            for (int i = 0; i < 10; i++)
                viewModel.SomeViewModels.Add(new SomeViewModel() { Id = Guid.NewGuid() });

            await context.Compose<SomeViewModel>(viewModel.SomeViewModels);

            return viewModel;
        }

        public override Task<IEnumerable<ViewModelWithListOfSomeViewModel>> AppendTo(IEnumerable<ViewModelWithListOfSomeViewModel> list, CompositionContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class SomeViewModel
    {

        public Guid Id { get; set; }
        public string ProvidedBySomeAppender { get; set; }

    }

    public class ViewModelWithListOfSomeViewModel
    {

        public List<SomeViewModel> SomeViewModels { get; set; }

    }
}
