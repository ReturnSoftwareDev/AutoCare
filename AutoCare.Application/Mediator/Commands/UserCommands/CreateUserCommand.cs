using AutoCare.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Commands.UserCommands
{
    public class CreateUserCommand: IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? MailApproved { get; set; }
        public bool? MailConfirmed { get; set; }
        public string Password { get; set; }

        public CreateUserCommand()
        {
            MailApproved = false;
            MailConfirmed = false;
        }
    }
}
