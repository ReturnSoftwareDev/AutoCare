using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.MechanicQueries;
using AutoCare.Application.Mediator.Results.MechanicResults;
using MediatR;

namespace AutoCare.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetMechanicByIdQueryHandler : IRequestHandler<GetMechanicByIdQuery, ResultResponse<GetMechanicByIdQueryResult>>
    {
        private readonly IMechanicService _MechanicService;

        public GetMechanicByIdQueryHandler(IMechanicService MechanicService)
        {
            _MechanicService = MechanicService;
        }

        public async Task<ResultResponse<GetMechanicByIdQueryResult>> Handle(GetMechanicByIdQuery request, CancellationToken cancellationToken)
        {
            return await _MechanicService.GetByIdMechanic(request);
        }
    }
}
