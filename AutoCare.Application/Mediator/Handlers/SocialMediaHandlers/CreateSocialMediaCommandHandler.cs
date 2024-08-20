using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CommandResponse>
    {
        private readonly ISocialMediaService _service;

        public CreateSocialMediaCommandHandler(ISocialMediaService service)
        {
            _service = service;
        }

        public async Task<CommandResponse> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateSocialMedia(request);   
        }
    }
}
