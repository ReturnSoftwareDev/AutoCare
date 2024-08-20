using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, CommandResponse>
    {
        private readonly ISocialMediaService _service;

        public DeleteSocialMediaCommandHandler(ISocialMediaService service)
        {
            _service = service;
        }
        public async Task<CommandResponse> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteSocialMedia(request);
        }
    }
}
