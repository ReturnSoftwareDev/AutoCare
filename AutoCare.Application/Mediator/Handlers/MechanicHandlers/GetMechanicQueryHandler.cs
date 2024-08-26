using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.MechanicQueries;
using AutoCare.Application.Mediator.Results.MechanicResults;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.MechanicHandlers;
public class GetMechanicQueryHandler : IRequestHandler<GetMechanicQuery, ResultResponse<List<GetMechanicQueryResult>>>
{
    private readonly IMechanicService _MechanicService;

    public GetMechanicQueryHandler(IMechanicService MechanicService)
    {
        _MechanicService = MechanicService;
    }

    public async Task<ResultResponse<List<GetMechanicQueryResult>>> Handle(GetMechanicQuery request, CancellationToken cancellationToken)
    {
        return await _MechanicService.GetMechanics(request);
    }
}
