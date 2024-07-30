using Core.Entities;
using Entities.Common;

namespace Entities
{
    public class ProductImageFile : BaseFile,IEntity
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
