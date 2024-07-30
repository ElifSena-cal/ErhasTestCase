using Core.Entities;
using Entities.Common;
using Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string StockCode { get; set; }
        public float Price { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
  
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
