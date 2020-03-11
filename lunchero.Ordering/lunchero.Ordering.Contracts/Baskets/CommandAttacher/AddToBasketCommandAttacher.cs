using System;
using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Contracts.Composition.Baskets;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using NServiceBus;

namespace lunchero.Ordering.Contracts.Baskets.CommandAttacher
{
    public class AddToBasketCommandAttacher : CommandAttacherBase<AddArticleToBasketModel>
    {

        public override async Task AttachTo(AddArticleToBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new AddArticleToBasket()
            {
                BasketId = viewModel.BasketId,
                UserId = viewModel.UserId,
                ArticleNumber = viewModel.ArticleNumber,
                Quantity = viewModel.Quantity,
                PickupId = Guid.NewGuid()
            };

            await endpoint.Send("lunchero.Ordering", command).ConfigureAwait(false);
        }
    }
}