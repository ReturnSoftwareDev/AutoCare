using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Results.AboutResults;
public class GetAboutQueryResult
{
    public short Id { get; set; }
    public string Title { get; set; }
    public string Description1 { get; set; }
    public string ImageUrl { get; set; }
    public string? Description2 { get; set; }
}
