using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class BasketViewComponent(IBasketService basketService) : ViewComponent
{
    private readonly IBasketService _basketService = basketService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var basketItems = await _basketService.GetBasketItemsAsync(); 
        return View(basketItems);
    }

}
