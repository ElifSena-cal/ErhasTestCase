using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public EfProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {

            return await _context.Products
                .Include(p => p.Category)
                .Include(p=>p.ProductImageFiles)
                .Include(p => p.Brand)
                .ToListAsync();
        }

        public async Task<List<Product>> GetByCategoryIdAsync(Guid categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
