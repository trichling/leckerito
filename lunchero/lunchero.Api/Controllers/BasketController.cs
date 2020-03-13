using System;
using System.Threading.Tasks;
using leckerito.Framework.Composition.CommandExecution;
using leckerito.Framework.Composition.ViewModelComposing;
using lunchero.Contracts.Composition.Baskets;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

namespace lunchero.Api.Controllers
{
    [ApiController]
    [Route("/basket")]
    public class BasketController : ControllerBase
    {
        private readonly IMessageSession endpoint;
        private readonly IViewModelComposer viewModelComposer;
        private readonly ICommandExecutor commandExecutor;

        public BasketController(IMessageSession endpoint, IViewModelComposer viewModelComposer, ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.viewModelComposer = viewModelComposer;
            this.endpoint = endpoint;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddToBasket(AddMealToBasketModel addArticleToBasket)
        {
            if (addArticleToBasket.MealId == Guid.Empty)
                addArticleToBasket.MealId = Guid.NewGuid();
            
            addArticleToBasket.TableguestId = GetUserIdFromLoggedInUser();

            await commandExecutor.ExecuteCommandsFor(addArticleToBasket, endpoint).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult>  CheckoutToBasket()
        {
            var checkoutBasket = new CheckoutAllMealsFromBasketModel() 
            {
                TableguestId = GetUserIdFromLoggedInUser()
            };

            await commandExecutor.ExecuteCommandsFor(checkoutBasket, endpoint).ConfigureAwait(false);

            return Ok();
        }

        private Guid GetUserIdFromLoggedInUser()
        {
            return new Guid("d9158173-ca65-403a-9bea-26d638e86fb1");
        }
    }
}