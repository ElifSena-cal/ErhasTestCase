using Business.Abstract;
using Business.Concrete;
using DataAccess.ViewModels.Baskets;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ErhasTestCase.Controllers
{
    public class BasketController(IBasketService basketService) : Controller
    {
        private readonly IBasketService _basketService = basketService;

        [HttpPost]
        public async Task<IActionResult> AddToBasket(string ProductId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var vM_Create_BasketItem = new VM_Create_BasketItem
                {
                    ProductId = ProductId,
                    Quantity = 1
                };
                await _basketService.AddItemToBasketAsync(vM_Create_BasketItem);
                return ViewComponent("Basket");
            }
            else
            {
                return Unauthorized();
            }
       
        }
        //Update
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(string basketItemId, int quantity)
        {
            var vM_Update_BasketItem = new VM_Update_BasketItem
            {
                BasketItemId = Guid.Parse(basketItemId),
                Quantity = quantity
            };
            await _basketService.UpdateQuantityAsync(vM_Update_BasketItem);
            return ViewComponent("Basket");
        }
        //Delete
        [HttpPost]
        public async Task<IActionResult> RemoveBasketItem(string basketItemId)
        {
            await _basketService.RemoveBasketItemAsync(basketItemId);
            return ViewComponent("Basket");
        }
        public async Task<IActionResult>  MyBasket()
        {
            var basketItems = await _basketService.GetBasketItemsAsync();
            return View(basketItems);
        }
    }
}
