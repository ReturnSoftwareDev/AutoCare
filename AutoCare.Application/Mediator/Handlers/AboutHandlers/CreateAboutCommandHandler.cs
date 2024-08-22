using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.AboutCommands;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.AboutHandlers;
public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, CommandResponse>
{
    private readonly IAboutService _aboutService;

    public CreateAboutCommandHandler(IAboutService service)
    {
        _aboutService = service;
    }

    public async Task<CommandResponse> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
    {
        return await _aboutService.CreateAbout(request);
    }
}
