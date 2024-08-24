using AutoCare.Application.Base;
using AutoCare.Application.Tools;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Queries.UserQueries
{
    public class RefreshTokenLoginQuery:IRequest<ResultResponse<JwtResponseModel>>
    {
        public string RefreshToken { get; set; }
    }
}
