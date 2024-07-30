using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Common
{
    public  class BaseEntity
    {
     
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
