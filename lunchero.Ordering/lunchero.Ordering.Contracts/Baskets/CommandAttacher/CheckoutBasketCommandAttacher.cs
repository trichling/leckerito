using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Contracts.Composition.Baskets;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using NServiceBus;

namespace lunchero.Ordering.Contracts.Baskets.CommandAttacher
{
    public class CheckoutBasketCommandAttacher : CommandAttacherBase<CheckoutBasketModel>
    {
        public override async Task AttachTo(CheckoutBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new CheckOutBasket() 
            {
                BasketId = viewModel.BasketId,
                UserId = viewModel.UserId
            };

            await endpoint.Send("lunchero.Ordering", command).ConfigureAwait(false);
        }
    }
}