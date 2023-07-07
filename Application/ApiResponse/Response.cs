using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApiResponse
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, bool succeeded, string message = null)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }
        public Response(bool succeeded, string message = null)
        {
            Succeeded = succeeded;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
