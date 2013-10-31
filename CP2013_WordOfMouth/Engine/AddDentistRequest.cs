using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Engine
{
    public class AddDentistRequest : IRequest
    {
        private object request;
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAllDentists();
        private Http http;
        private HttpResponse response;

        public AddDentistRequest()
        {
            http = new Http();
            http.RequestContentType = "application/json";
        }

        public void SendRequest()
        {
            http.Url = new Uri(baseUrl + location + request.ToString());
            response = http.Get();
        }

        public object GetResponse()
        {
            return response;
        }

        public void SetRequest(object o)
        {
            request = o;
        }
    }
}
