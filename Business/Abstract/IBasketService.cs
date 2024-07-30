using DataAccess.ViewModels.Baskets;
using Entities;

namespace Business.Abstract
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
        public Task RemoveBasketItemAsync(string productId);
        public Basket? GetUserActiveBasket { get; }
    }
}
