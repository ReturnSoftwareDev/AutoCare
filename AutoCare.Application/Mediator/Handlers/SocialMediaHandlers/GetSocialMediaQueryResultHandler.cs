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
    public class GetSocialMediaQueryResultHandler : IRequestHandler<GetSocialMediasQuery, ResultResponse<List<GetSocialMediasQueryResult>>>
    {
        private readonly ISocialMediaService _service;

        public GetSocialMediaQueryResultHandler(ISocialMediaService service)
        {
            _service = service;
        }

        public async Task<ResultResponse<List<GetSocialMediasQueryResult>>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetSocialMedias(request);
        }
    }
}
