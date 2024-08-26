using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class Mechanic : BaseEntity<short>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public string? Street { get; set; }
    public string City { get; set; }
    public string Discrict { get; set; }
    public string Neighborhood { get; set; }
    public string? BuildingNumber { get; set; }
    public string? IndustrialArea { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public List<MechanicServices> MechanicServices { get; set; }
    public List<MechanicBrands> MechanicBrands { get; set; }
}
