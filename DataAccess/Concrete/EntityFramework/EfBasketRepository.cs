using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketRepository : EfEntityRepositoryBase<Basket>, IBasketRepository
    {
        public EfBasketRepository(AppDbContext context) : base(context)
        {
        }

    }
}
