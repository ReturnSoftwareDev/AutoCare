using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Base
{
    public class Response
    {
        public List<string>? Errors { get; set; }
        public Response()
        {
            Errors = new List<string>();
        }
    }
}
