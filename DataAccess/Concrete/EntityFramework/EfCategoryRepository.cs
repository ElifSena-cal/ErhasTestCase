using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
