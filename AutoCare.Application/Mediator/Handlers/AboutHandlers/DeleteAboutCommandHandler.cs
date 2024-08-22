using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.AboutCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.AboutHandlers;
public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, CommandResponse>
{
    private readonly IAboutService _service;

    public DeleteAboutCommandHandler(IAboutService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
    {
        return await _service.DeleteAbout(request);
    }
}
