using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.MechanicQueries;
using AutoCare.Application.Mediator.Queries.MechanicServicesQueries;
using AutoCare.Application.Mediator.Results.MechanicResults;
using AutoCare.Application.Mediator.Results.MechanicServicesResults;
using AutoCare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.MechanicServicesHandlers;
public class GetMechanicServicesQueryHandler : IRequestHandler<GetMechanicServicesQuery, ResultResponse<List<GetMechanicServicesQueryResult>>>
{
    private readonly IMechanicServicesService _service;

    public GetMechanicServicesQueryHandler(IMechanicServicesService service)
    {
        _service = service;
    }

    public async Task<ResultResponse<List<GetMechanicServicesQueryResult>>> Handle(GetMechanicServicesQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetMechanicServices(request);
    }
}
