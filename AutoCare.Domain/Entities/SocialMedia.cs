using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities
{
    public class SocialMedia:BaseEntity<short>
    {
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
