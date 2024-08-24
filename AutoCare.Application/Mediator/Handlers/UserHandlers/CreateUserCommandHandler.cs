using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Mediator.Commands.UserCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterUser(request);
        }
    }
}
