using Core.Entities;
using Entities.Common;
using Entities.Identity;

namespace Entities
{
    public class Basket : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
