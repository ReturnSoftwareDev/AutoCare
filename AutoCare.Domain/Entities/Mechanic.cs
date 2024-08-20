using AutoCare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities;
public class Mechanic : BaseEntity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public int AddressId { get; set; } 
    public Address Address { get; set; }
    public List<Service> Services { get; set; }
}
