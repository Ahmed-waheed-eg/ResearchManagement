using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.ResponseBases
{
    public class MyResponse<T>
    {
        public MyResponse()
        {

        }
        public MyResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public MyResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public MyResponse(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        //public Dictionary<string, List<string>> ErrorsBag { get; set; }
        public T Data { get; set; }

    }
}
