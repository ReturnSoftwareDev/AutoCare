using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.AboutResults;
using AutoCare.Application.Mediator.Results.MechanicResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.MechanicQueries;
public class GetMechanicQuery : IRequest<ResultResponse<List<GetMechanicQueryResult>>>
{
}
