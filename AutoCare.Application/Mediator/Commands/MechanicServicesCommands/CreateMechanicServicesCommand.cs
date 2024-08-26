using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.MechanicServicesCommands;
public class CreateMechanicServicesCommand : IRequest<CommandResponse>
{
    public short MechanicId { get; set; }
    public short ServiceId { get; set; }

    public CreateMechanicServicesCommand(short mechanicId, short serviceId)
    {
        MechanicId = mechanicId;
        ServiceId = serviceId;
    }
}
