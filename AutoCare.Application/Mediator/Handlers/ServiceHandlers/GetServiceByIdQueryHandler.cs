using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.ServiceQueries;
using AutoCare.Application.Mediator.Results.ServiceResults;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.ServiceHandlers;
public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ResultResponse<GetServiceByIdQueryResult>>
{
    private readonly IServiceService _serviceService;

    public GetServiceByIdQueryHandler(IServiceService ServiceService)
    {
        _serviceService = ServiceService;
    }

    public async Task<ResultResponse<GetServiceByIdQueryResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        return await _serviceService.GetByIdService(request);
    }
}
