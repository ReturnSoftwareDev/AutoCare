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
public class GetMechanicByIdQuery : IRequest<ResultResponse<GetMechanicByIdQueryResult>>
{
    public short Id { get; set; }
    public GetMechanicByIdQuery(short id)
    {
        Id = id;
    }
}
