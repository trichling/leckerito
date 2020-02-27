using System;
using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using lunchero.Ordering.Contracts.Baskets.Models;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

namespace lunchero.Ordering.Api.Controllers
{

    [ApiController]
    [Route("/basekt")]
    public class BasketController : ControllerBase
    {
        private readonly IMessageSession endpoint;

        public BasketController(IMessageSession endpoint)
        {
            this.endpoint = endpoint;

        }

        [HttpPost()]
        public async Task<IActionResult> AddToBasket(AddArticleToBasketModel article)
        {
            var userId = GetUserIdFromLoggedInUser();

            await this.endpoint.Send(new AddArticleToBasket() {
                UserId = userId,
                ArticleNumber = article.ArticleNumber,
                Quantity = article.Quantity
            }).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult>  CheckoutToBasket()
        {
            var userId = GetUserIdFromLoggedInUser();

            await this.endpoint.Send(new CheckOutBasket() {
                UserId = userId
            }).ConfigureAwait(false);

            return Ok();
        }

        private Guid GetUserIdFromLoggedInUser()
        {
            return new Guid("d9158173-ca65-403a-9bea-26d638e86fb1");
        }

    }
}