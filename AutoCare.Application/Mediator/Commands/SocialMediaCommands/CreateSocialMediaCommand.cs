using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand:IRequest<CommandResponse>
    {
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
