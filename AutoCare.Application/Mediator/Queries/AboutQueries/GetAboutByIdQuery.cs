using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.AboutResults;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.AboutQueries;
public class GetAboutByIdQuery : IRequest<ResultResponse<GetAboutByIdQueryResult>>
{
    public short Id { get; set; }

    public GetAboutByIdQuery(short id)
    {
        Id = id;
    }
}
