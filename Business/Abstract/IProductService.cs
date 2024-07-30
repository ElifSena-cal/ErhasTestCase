using Entities;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetByCategoryIdAsync(Guid categoryId);
    }

}
