﻿using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities
{
    public class Banner:BaseEntity<short>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
