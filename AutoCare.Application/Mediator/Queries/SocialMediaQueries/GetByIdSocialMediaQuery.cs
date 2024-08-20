using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.SocialMediaQueries
{
    public class GetByIdSocialMediaQuery:IRequest<ResultResponse<GetByIdSocialMediaQueryResult>>
    {
        public short Id { get; set; }

        public GetByIdSocialMediaQuery(short id)
        {
            Id = id;
        }
    }
}
