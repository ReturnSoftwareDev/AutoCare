using AutoCare.Application.Mediator.Results.UserResults;
using AutoCare.Application.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.TokenServices
{
    public interface ITokenService
    {
        Task<JwtResponseModel> GenerateToken(UserLoginQueryResult model);
        Task<string> RefreshToken();
    }
}
