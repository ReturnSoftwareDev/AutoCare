using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class MechanicServices
{
    public int MechanicId { get; set; } 
    public Mechanic Mechanic { get; set; }

    public int ServiceId { get; set; } 
    public Service Service { get; set; }
}
