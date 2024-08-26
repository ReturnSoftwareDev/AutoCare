using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Results.ServiceResults;
public class GetServiceByIdQueryResult
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
