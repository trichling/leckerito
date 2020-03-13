using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Contracts.Composition.Baskets;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;
using NServiceBus;

namespace lunchero.Pricing.Contracts.Baskets.CommandAttacher
{
    public class AddMealToBasketCommandAttacher : CommandAttacherBase<AddMealToBasketModel>
    {
        public override async Task AttachTo(AddMealToBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new AddMealToBasket()
            {
                MealId = viewModel.MealId,
                TableguestId = viewModel.TableguestId,
                PickupOn = viewModel.PickupOn,
                ArticleNumber = viewModel.ArticleNumber,
                Quantity = viewModel.Quantity
            };

            await endpoint.Send("lunchero.Pricing", command);
        }
    }
}