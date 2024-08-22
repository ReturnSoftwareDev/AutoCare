using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Commands.MechanicCommands;
using AutoCare.Application.Mediator.Queries.MechanicQueries;
using AutoCare.Application.Mediator.Results.MechanicResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.EntityServices;
public interface IMechanicService
{
    Task<ResultResponse<List<GetMechanicQueryResult>>> GetMechanics(GetMechanicQuery getMechanicQuery);
    Task<ResultResponse<GetMechanicByIdQueryResult>> GetByIdMechanic(GetMechanicByIdQuery getByIdMechanicQuery);
    Task<CommandResponse> CreateMechanic(CreateMechanicCommand createMechanicCommand);
    Task<CommandResponse> UpdateMechanic(UpdateMechanicCommand updateMechanicCommand);
    Task<CommandResponse> DeleteMechanic(DeleteMechanicCommand deleteMechanicCommand);
}
