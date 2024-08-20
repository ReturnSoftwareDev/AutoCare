using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class Service : BaseEntity<short>
{
    public string Name { get; set; }
    public List<Mechanic> Mechanics { get; set; }
}
