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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, CommandResponse>
    {
        private readonly ISocialMediaService _service;

        public UpdateSocialMediaCommandHandler(ISocialMediaService service)
        {
            _service = service;
        }
        public async Task<CommandResponse> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateSocialMedia(request);
        }
    }
}
