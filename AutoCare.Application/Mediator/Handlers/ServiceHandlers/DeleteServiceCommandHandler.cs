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
public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, CommandResponse>
{
    private readonly IServiceService _service;

    public DeleteServiceCommandHandler(IServiceService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        return await _service.DeleteService(request);
    }
}
