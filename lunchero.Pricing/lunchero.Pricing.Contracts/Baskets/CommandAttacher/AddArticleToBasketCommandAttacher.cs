using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using lunchero.Contracts.Composition.Baskets;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;
using NServiceBus;

namespace lunchero.Pricing.Contracts.Baskets.CommandAttacher
{
    public class AddArticleToBasketCommandAttacher : CommandAttacherBase<AddArticleToBasketModel>
    {
        public override async Task AttachTo(AddArticleToBasketModel viewModel, IMessageSession endpoint)
        {
            var command = new AddArticleToBasket()
            {
                UserId = viewModel.UserId,
                ArticleNumber = viewModel.ArticleNumber,
                Quantity = viewModel.Quantity
            };

            await endpoint.Send("lunchero.Pricing", command);
        }
    }
}