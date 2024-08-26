using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.ServiceCommands;
public class UpdateServiceCommand : IRequest<CommandResponse>
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
