using Core.Entities;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BasketItem : BaseEntity, IEntity
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
