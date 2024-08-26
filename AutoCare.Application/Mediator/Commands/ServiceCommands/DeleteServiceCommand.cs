using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.ServiceCommands;
public class DeleteServiceCommand : IRequest<CommandResponse>
{
    public short Id { get; set; }

    public DeleteServiceCommand(short id)
    {
        Id = id;
    }
}
