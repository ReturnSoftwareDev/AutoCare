using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class Brand : BaseEntity<short>
{
    public string Name { get; set; }
    public List<MechanicBrands> MechanicBrands { get; set; }
}
