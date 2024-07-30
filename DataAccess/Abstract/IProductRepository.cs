using Entities;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetByCategoryIdAsync(Guid categoryId);
    }
}
