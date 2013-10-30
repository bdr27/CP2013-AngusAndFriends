using CP2013_WordOfMouth.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAllDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAllDentists();
        private Http http;
        private HttpResponse httpResponse;

        public HttpGetAllDentist()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = "application/json";
        }

        public void SendRequest(string request)
        {
            httpResponse = http.Get();
        }

        public string GetResponse()
        {
            return httpResponse.Content;
        }


        public HttpResponse GetHttpResponse()
        {
            return httpResponse;
        }
    }
}
