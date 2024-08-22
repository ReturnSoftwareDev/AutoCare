using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.MechanicCommands;
public class DeleteMechanicCommand : IRequest<CommandResponse>
{
    public short Id { get; set; }

    public DeleteMechanicCommand(short id)
    {
        Id = id;
    }
}
