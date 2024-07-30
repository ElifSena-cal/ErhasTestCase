using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.ViewModels.Baskets;
using Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class BasketService(IHttpContextAccessor httpContextAccessor,
                         UserManager<AppUser> userManager,
                         IBasketRepository basketRepository,
                         IBasketItemRepository basketItemRepository) : IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IBasketRepository _basketRepository = basketRepository;
        private readonly IBasketItemRepository _basketItemRepository = basketItemRepository;

        private async Task<Basket?> ContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users
                         .Include(u => u.Baskets)
                         .FirstOrDefaultAsync(u => u.UserName == username);

                Basket? targetBasket = user.Baskets.FirstOrDefault();

                if (targetBasket == null)
                {
                    targetBasket = new Basket();
                    user.Baskets.Add(targetBasket);
                    await _basketRepository.AddAsync(targetBasket);
                }

                return targetBasket;
            }
            else
            {
                return null;
            }

        }


        public async Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
        {
            Basket? basket = await ContextUser();
            if (basket != null)
            {
                BasketItem _basketItem = await _basketItemRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId));

                if (_basketItem != null)
                    _basketItem.Quantity++;
                else
                    await _basketItemRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(basketItem.ProductId),
                        Quantity = basketItem.Quantity
                    });
                await _basketItemRepository.UpdateAsync(_basketItem);
            }
        }


        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            if (basket == null)
            {
                return new List<BasketItem>();
            }
            return await _basketItemRepository.GetBasketItemsAsync(basket.Id);
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem? basketItem = await _basketItemRepository.GetByIdAsync(Guid.Parse(basketItemId));
            if (basketItem != null)
            {
                _basketItemRepository.DeleteAsync(basketItem);
            }
        }

        public async Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
        {
            BasketItem? _basketItem = await _basketItemRepository.GetByIdAsync(basketItem.BasketItemId);
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                if (_basketItem.Quantity == 0)
                {
                    await _basketItemRepository.DeleteAsync(_basketItem);
                }
                await _basketItemRepository.UpdateAsync(_basketItem);
            }
        }

        public Basket? GetUserActiveBasket
        {
            get
            {
                Basket? basket = ContextUser().Result;
                return basket;
            }
        }
    }
}
