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
public class UpdateMechanicCommandHandler : IRequestHandler<UpdateMechanicCommand, CommandResponse>
{
    private readonly IMechanicService _MechanicService;

    public UpdateMechanicCommandHandler(IMechanicService MechanicService)
    {
        _MechanicService = MechanicService;
    }

    public async Task<CommandResponse> Handle(UpdateMechanicCommand request, CancellationToken cancellationToken)
    {
        return await _MechanicService.UpdateMechanic(request);
    }
}
