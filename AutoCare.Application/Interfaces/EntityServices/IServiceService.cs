using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Commands.ServiceCommands;
using AutoCare.Application.Mediator.Queries.ServiceQueries;
using AutoCare.Application.Mediator.Results.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.EntityServices;
public interface IServiceService
{
    Task<ResultResponse<List<GetServiceQueryResult>>> GetServices(GetServiceQuery getServiceQuery);
    Task<ResultResponse<GetServiceByIdQueryResult>> GetByIdService(GetServiceByIdQuery getByIdServiceQuery);
    Task<CommandResponse> CreateService(CreateServiceCommand createServiceCommand);
    Task<CommandResponse> UpdateService(UpdateServiceCommand updateServiceCommand);
    Task<CommandResponse> DeleteService(DeleteServiceCommand deleteServiceCommand);
}
