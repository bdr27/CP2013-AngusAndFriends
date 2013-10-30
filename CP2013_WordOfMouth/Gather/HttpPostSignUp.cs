using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostSignUp : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetSignUp();
        private Http http;
        private HttpResponse httpResponse;

        public HttpPostSignUp()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = "application/json";
        }

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            httpResponse = http.Post();
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
