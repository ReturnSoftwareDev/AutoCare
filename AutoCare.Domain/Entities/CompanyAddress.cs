using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities
{
    public class CompanyAddress:BaseEntity<short>
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
