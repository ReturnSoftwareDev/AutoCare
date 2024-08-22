using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Base
{
    public class ResultResponse<T> 
    {
        public ResultResponse(T data, string message, int code)
        {
            Data = data;
            Message = message;
            Code = code;
        }

        public T? Data { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
