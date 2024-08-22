using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.MechanicCommands;
public class UpdateMechanicCommand : IRequest<CommandResponse>
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public int AddressId { get; set; }
}
