using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Queries.UserQueries;
using AutoCare.Application.Tools;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.UserHandlers
{
    public class RefreshTokenQueryResultHandler : IRequestHandler<RefreshTokenLoginQuery, ResultResponse<JwtResponseModel>>
    {
        private readonly IUserService _userService;

        public RefreshTokenQueryResultHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResultResponse<JwtResponseModel>> Handle(RefreshTokenLoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.RefreshTokenLoginUser(request);
        }
    }
}
