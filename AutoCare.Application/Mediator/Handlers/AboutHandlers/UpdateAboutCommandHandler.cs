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
public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, CommandResponse>
{
    private readonly IAboutService _aboutService;

    public UpdateAboutCommandHandler(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<CommandResponse> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
    {
        return await _aboutService.UpdateAbout(request);
    }
}
