using System;
using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using lunchero.Contracts.Composition.Baskets;
using NServiceBus;

namespace lunchero.Ordering.Contracts.Baskets.CommandAttacher
{
    public class AddMealToBasketCommandAttacher : CommandAttacherBase<AddMealToBasketModel>
    {

        public override async Task AttachTo(AddMealToBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new AddMealToBasket()
            {
                MealId = viewModel.MealId,
                TableguestId = viewModel.TableguestId,
                ArticleNumber = viewModel.ArticleNumber,
                PickupOn = viewModel.PickupOn
            };

            await endpoint.Send("lunchero.Ordering", command).ConfigureAwait(false);
        }
    }
}