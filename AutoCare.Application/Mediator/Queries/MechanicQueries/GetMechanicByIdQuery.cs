using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.MechanicResults;
using MediatR;

namespace AutoCare.Application.Mediator.Queries.MechanicQueries;
public class GetMechanicByIdQuery : IRequest<ResultResponse<GetMechanicByIdQueryResult>>
{
    public short Id { get; set; }
    public GetMechanicByIdQuery(short id)
    {
        Id = id;
    }
}
