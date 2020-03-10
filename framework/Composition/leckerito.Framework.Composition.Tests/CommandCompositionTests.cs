using System.Threading.Tasks;
using leckerito.Framework.Composition.Commands;
using NServiceBus;
using NServiceBus.Testing;
using Xunit;

namespace leckerito.Framework.Composition.Tests
{
    public class CommandAttacherTests
    {
        
        [Fact]
        public async Task CanAttachToAddToBasketViewModel()
        {
            var endpoint = new TestableEndpointInstance();
            var commandAttacherLocator = new CommandAttacherLocator();
            commandAttacherLocator.DiscoverFromAllLoadedAssemblies();

            var executor = new CommandExecutor(commandAttacherLocator);

            var viewModel = new AddToBasket()
            {
                ArticleNumber = "13010",
                Quantity = 3
            };

            await executor.ExecuteCommandsFor(viewModel, endpoint);

            Assert.Equal(2, endpoint.SentMessages.Length);
        }

    }

    public class AddToBasketPricingAttacher : CommandAttacherBase<AddToBasket>
    {
        public override async Task AttachTo(AddToBasket viewModel, IMessageSession endpoint)
        {
            var command = new AddToBasketCommand() 
            {
                ArticleNumber = viewModel.ArticleNumber,
                Quantity = viewModel.Quantity
            };

            await endpoint.Send("leckerito.Pricing", command);
        }

        private class AddToBasketCommand : ICommand
        {
            public string ArticleNumber { get; set; }

            public int Quantity { get; set; }
        }
    }

    public class AddToBasketWarehouseAttacher : CommandAttacherBase<AddToBasket>
    {
        public override async Task AttachTo(AddToBasket viewModel, IMessageSession endpoint)
        {
            var command = new AddToBasketCommand() 
            {
                ArticleNumber = viewModel.ArticleNumber,
                Quantity = viewModel.Quantity
            };

            await endpoint.Send("leckerito.Warehouse", command);
        }

        private class AddToBasketCommand : ICommand
        {
            public string ArticleNumber { get; set; }

            public int Quantity { get; set; }
        }
    }

    public class AddToBasket
    {

        public string ArticleNumber { get; set; }

        public int Quantity { get; set; }

    }
}