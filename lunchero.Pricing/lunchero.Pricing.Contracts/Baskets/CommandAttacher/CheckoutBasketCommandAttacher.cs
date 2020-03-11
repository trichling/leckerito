using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Contracts.Composition.Baskets;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;
using NServiceBus;

namespace lunchero.Pricing.Contracts.Baskets.CommandAttacher
{
    public class CheckoutBasketCommandAttacher : CommandAttacherBase<CheckoutBasketModel>
    {
        public override async Task AttachTo(CheckoutBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new CheckOutBasket() 
            {
                UserId = viewModel.UserId
            };

            await endpoint.Send("lunchero.Pricing", command);
        }
    }
}