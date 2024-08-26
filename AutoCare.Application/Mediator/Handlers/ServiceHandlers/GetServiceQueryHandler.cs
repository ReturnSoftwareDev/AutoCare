using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.ServiceQueries;
using AutoCare.Application.Mediator.Results.ServiceResults;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.ServiceHandlers;
public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, ResultResponse<List<GetServiceQueryResult>>>
{
    private readonly IServiceService _serviceService;

    public GetServiceQueryHandler(IServiceService ServiceService)
    {
        _serviceService = ServiceService;
    }

    public async Task<ResultResponse<List<GetServiceQueryResult>>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        return await _serviceService.GetServices(request);
    }
}
