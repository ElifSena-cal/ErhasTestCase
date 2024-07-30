
using Entities;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBasketItemRepository : IEntityRepository<BasketItem>
    {
        Task<List<BasketItem>> GetBasketItemsAsync(Guid basketId);
        Task<BasketItem> GetSingleAsync(Expression<Func<BasketItem, bool>> filter);
        Task<BasketItem> GetByProductIdAsync(Guid productId);

    }
}
