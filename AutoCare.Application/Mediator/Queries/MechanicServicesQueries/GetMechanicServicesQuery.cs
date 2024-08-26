
using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.MechanicResults;
using AutoCare.Application.Mediator.Results.MechanicServicesResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.MechanicServicesQueries;
public class GetMechanicServicesQuery : IRequest<ResultResponse<List<GetMechanicServicesQueryResult>>>
{
}
