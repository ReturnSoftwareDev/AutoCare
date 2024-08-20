using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities
{
    public class About: BaseEntity<short>
    {
        public string Title { get; set; }
        public string Description1 { get; set; }
        public string ImageUrl { get; set; }
        public string? Description2 { get; set; }
    }
}
