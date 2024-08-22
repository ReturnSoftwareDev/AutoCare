using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.AboutQueries;
using AutoCare.Application.Mediator.Results.AboutResults;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.AboutHandlers;
public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, ResultResponse<List<GetAboutQueryResult>>>
{
    private readonly IAboutService _aboutService;

    public GetAboutQueryHandler(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<ResultResponse<List<GetAboutQueryResult>>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
    {
        return await _aboutService.GetAbouts(request);
    }
}
