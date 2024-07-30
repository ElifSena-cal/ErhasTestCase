using Entities;

namespace DataAccess.Abstract
{
    public interface IBasketRepository : IEntityRepository<Basket>
    {
        //Task<Basket> GetActiveBasketByUserId(int userId);

    }
}
