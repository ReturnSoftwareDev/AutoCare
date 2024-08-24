using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Commands.UserCommands;
using AutoCare.Application.Mediator.Queries.UserQueries;
using AutoCare.Application.Mediator.Results.UserResults;
using AutoCare.Application.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.EntityServices
{
    public interface IUserService
    {
        Task<CommandResponse> RegisterUser(CreateUserCommand createUserCommand);
        Task<ResultResponse<JwtResponseModel>> LoginUser(UserLoginQuery userLoginQuery);
    }
}
