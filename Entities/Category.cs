using Core.Entities;
using Entities.Common;

namespace Entities
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
