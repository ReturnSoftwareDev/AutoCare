using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.SocialMediaQueries;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetAboutByIdQueryResultHandler : IRequestHandler<GetByIdSocialMediaQuery, ResultResponse<GetByIdSocialMediaQueryResult>>
    {
        private readonly ISocialMediaService _service;

        public GetAboutByIdQueryResultHandler(ISocialMediaService service)
        {
            _service = service;
        }
        public async Task<ResultResponse<GetByIdSocialMediaQueryResult>> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdSocialMedia(request);
        }
    }
}
