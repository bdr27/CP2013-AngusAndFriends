using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostEditDentistTimeslots : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetSetTimeForDentist();
        private Http http;
        private HttpResponse response;

        public HttpPostEditDentistTimeslots(object o)
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location + o.ToString());
            http.RequestContentType = "application/json";
        }

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            response = http.Post();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        public HttpResponse GetHttpResponse()
        {
            return response;
        }
    }
}
