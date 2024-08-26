using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.ServiceCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.ServiceHandlers;
public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, CommandResponse>
{
    private readonly IServiceService _ServiceService;

    public UpdateServiceCommandHandler(IServiceService ServiceService)
    {
        _ServiceService = ServiceService;
    }

    public async Task<CommandResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        return await _ServiceService.UpdateService(request);
    }
}
