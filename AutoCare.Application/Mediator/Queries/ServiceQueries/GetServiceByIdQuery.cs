using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.ServiceResults;
using MediatR;

namespace AutoCare.Application.Mediator.Queries.ServiceQueries;
public class GetServiceByIdQuery : IRequest<ResultResponse<GetServiceByIdQueryResult>>
{
    public short Id { get; set; }
    public GetServiceByIdQuery(short id)
    {
        Id = id;
    }
}
