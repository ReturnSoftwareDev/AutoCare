using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.MechanicCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.MechanicHandlers;
public class DeleteMechanicCommandHandler : IRequestHandler<DeleteMechanicCommand, CommandResponse>
{
    private readonly IMechanicService _service;

    public DeleteMechanicCommandHandler(IMechanicService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(DeleteMechanicCommand request, CancellationToken cancellationToken)
    {
        return await _service.DeleteMechanic(request);
    }
}
