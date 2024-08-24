using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.UserResults;
using AutoCare.Application.Tools;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.UserQueries
{
    public class UserLoginQuery:IRequest<ResultResponse<JwtResponseModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
