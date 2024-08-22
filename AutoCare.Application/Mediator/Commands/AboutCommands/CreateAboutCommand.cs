using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.AboutCommands;
public class CreateAboutCommand : IRequest<CommandResponse>
{
    public string Title { get; set; }
    public string Description1 { get; set; }
    public string ImageUrl { get; set; }
    public string? Description2 { get; set; }
}
