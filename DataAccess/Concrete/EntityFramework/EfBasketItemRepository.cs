using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketItemRepository : EfEntityRepositoryBase<BasketItem>, IBasketItemRepository
    {
        private readonly AppDbContext _context;

        public EfBasketItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync(Guid basketId)
        {
            var result = await _context.Set<Basket>()
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .ThenInclude(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(b => b.Id == basketId);

            return result?.BasketItems.ToList() ?? new List<BasketItem>();
        }
        public async Task<BasketItem> GetByProductIdAsync(Guid productId)
        {
            return await _context.Set<BasketItem>()
                .Include(bi => bi.Product)
                .FirstOrDefaultAsync(bi => bi.Product.Id == productId);
        }


        public async Task<BasketItem> GetSingleAsync(Expression<Func<BasketItem, bool>> filter)
        {
            return await _context.Set<BasketItem>().SingleOrDefaultAsync(filter);
        }
    }
}
