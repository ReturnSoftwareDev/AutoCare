using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Commands.MechanicServicesCommands;
using AutoCare.Application.Mediator.Queries.MechanicServicesQueries;
using AutoCare.Application.Mediator.Results.MechanicServicesResults;

namespace AutoCare.Application.Interfaces.EntityServices;
public interface IMechanicServicesService
{
    Task<ResultResponse<List<GetMechanicServicesQueryResult>>> GetMechanicServices(GetMechanicServicesQuery getMechanicQuery);
    Task<CommandResponse> CreateMechanicServices(CreateMechanicServicesCommand createMechanicCommand);
}
