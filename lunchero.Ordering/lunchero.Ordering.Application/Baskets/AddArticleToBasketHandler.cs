using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;

namespace lunchero.Ordering.Application.Baskets
{
    public class AddArticleToBasketHandler : IHandleMessages<AddArticleToBasket>
    {
        static ILog log = LogManager.GetLogger<AddArticleToBasketHandler>();

        public async Task Handle(AddArticleToBasket message, IMessageHandlerContext context)
        {
            log.Debug("AddArticleToBasketHandler");
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}