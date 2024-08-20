using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities
{
    public class Newsletter:BaseEntity<int>
    {
        public string Email { get; set; }
    }
}
