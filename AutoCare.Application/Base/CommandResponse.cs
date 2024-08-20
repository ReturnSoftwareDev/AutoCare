using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Base
{
    public class CommandResponse : Response
    {
        public CommandResponse(string message, int code)
        {
            Message = string.Empty;
            Code = 0;
        }

        public string Message { get; set; }
        public int Code { get; set; }
    }
}
