using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Common;

namespace Entities
{
    public class Brand : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
