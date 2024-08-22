using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.AboutQueries;
using AutoCare.Application.Mediator.Results.AboutResults;
using AutoCare.Domain.Entities;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, ResultResponse<GetAboutByIdQueryResult>>
    {
        private readonly IAboutService _AboutService;

        public GetAboutByIdQueryHandler(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        public async Task<ResultResponse<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            return await _AboutService.GetByIdAbout(request);
        }
    }
}
