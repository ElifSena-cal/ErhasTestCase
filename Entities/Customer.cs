﻿using Core.Entities;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
