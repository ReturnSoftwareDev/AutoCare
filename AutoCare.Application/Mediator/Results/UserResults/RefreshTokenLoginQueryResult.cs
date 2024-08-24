using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mediator.Results.UserResults
{
    public class RefreshTokenLoginQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? MailApproved { get; set; }
        public bool? MailConfirmed { get; set; }
    }
}
