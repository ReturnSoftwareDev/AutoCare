using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.AboutCommands;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.AboutHandlers;
public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, CommandResponse>
{
    private readonly IAboutService _service;

    public CreateAboutCommandHandler(IAboutService service)
    {
        _service = service;
    }

    public async Task<CommandResponse> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateAbout(request);
    }
}
