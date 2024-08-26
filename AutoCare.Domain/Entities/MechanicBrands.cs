using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class MechanicBrands : BaseEntity<short>
{
    public short MechanicId { get; set; }
    public Mechanic Mechanic { get; set; }

    public short BrandId { get; set; }
    public Brand Brand { get; set; }

    public bool IsActive { get; set; }
}
