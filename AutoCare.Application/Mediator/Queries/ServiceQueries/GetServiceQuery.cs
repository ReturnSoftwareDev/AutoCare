using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.ServiceQueries;
public class GetServiceQuery : IRequest<ResultResponse<List<GetServiceQueryResult>>>
{
}
