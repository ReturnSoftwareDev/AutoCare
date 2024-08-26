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
public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CommandResponse>
{
    private readonly IServiceService _service;

    public CreateServiceCommandHandler(IServiceService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateService(request);
    }
}
