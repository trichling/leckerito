using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using lunchero.Contracts.Composition.Baskets;
using NServiceBus;

namespace lunchero.Ordering.Contracts.Baskets.CommandAttacher
{
    public class CheckoutAllMealsCommandAttacher : CommandAttacherBase<CheckoutAllMealsFromBasketModel>
    {
        public override async Task AttachTo(CheckoutAllMealsFromBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new CheckoutAllMeals() 
            {
                TableguestId = viewModel.TableguestId
            };

            await endpoint.Send("lunchero.Ordering", command).ConfigureAwait(false);
        }
    }
}