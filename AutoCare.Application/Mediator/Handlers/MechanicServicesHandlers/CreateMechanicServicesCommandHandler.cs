using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.MechanicCommands;
using AutoCare.Application.Mediator.Commands.MechanicServicesCommands;
using AutoCare.Application.Mediator.Handlers.AboutHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.MechanicServicesHandlers;
public class CreateMechanicServicesCommandHandler : IRequestHandler<CreateMechanicServicesCommand, CommandResponse>
{
    private readonly IMechanicServicesService _service;

    public CreateMechanicServicesCommandHandler(IMechanicServicesService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(CreateMechanicServicesCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateMechanicServices(request);
    }
}
