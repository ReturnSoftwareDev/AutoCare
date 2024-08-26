using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class MechanicBrands
{
    public short MechanicId { get; set; }
    public Mechanic Mechanic { get; set; }

    public short BrandId { get; set; }
    public Brand Brand { get; set; }
}
