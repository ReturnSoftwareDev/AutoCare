﻿using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.SocialMediaCommands
{
    public class DeleteSocialMediaCommand:IRequest<CommandResponse>
    {
        public short Id { get; set; }

        public DeleteSocialMediaCommand(short id)
        {
            Id = id;
        }
    }
}
