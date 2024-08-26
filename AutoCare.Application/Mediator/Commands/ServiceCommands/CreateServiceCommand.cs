using AutoCare.Application.Base;
using MediatR;

namespace AutoCare.Application.Mediator.Commands.ServiceCommands;
public class CreateServiceCommand : IRequest<CommandResponse>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}
