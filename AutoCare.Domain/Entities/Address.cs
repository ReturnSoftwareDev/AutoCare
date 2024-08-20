using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class Address : BaseEntity
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Discrict { get; set; }
    public string Neighborhood { get; set; }
    public string BuildingNumber { get; set; }
    public string IndustrialArea { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public List<Mechanic> Mechanics { get; set; }
}
