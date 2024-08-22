using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.AboutCommands;
using AutoCare.Application.Mediator.Commands.MechanicCommands;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.AboutHandlers;
public class CreateMechanicCommandHandler : IRequestHandler<CreateMechanicCommand, CommandResponse>
{
    private readonly IMechanicService _service;

    public CreateMechanicCommandHandler(IMechanicService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(CreateMechanicCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateMechanic(request);
    }
}
