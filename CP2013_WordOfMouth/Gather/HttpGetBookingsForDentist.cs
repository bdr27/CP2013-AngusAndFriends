using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetBookingsForDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetBookingsForDentist();
        private Http http;
        private HttpResponse response;

        public HttpGetBookingsForDentist()
        {
            http = new Http();
            http.RequestContentType = "application/json";
        }
        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + location + request);
            response = http.Get();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        public RestSharp.HttpResponse GetHttpResponse()
        {
            return response;
        }
    }
}
