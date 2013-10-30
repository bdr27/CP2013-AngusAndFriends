using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostSession : IRequestResponse 
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetPoll();
        private Http http;
        private HttpResponse httpResponse;

        public HttpPostSession()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = "application/json";
        }
        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            httpResponse = http.Post();
        }

        public string GetResponse()
        {
            return httpResponse.StatusCode.ToString();
        }

        #endregion


        public HttpResponse GetHttpResponse()
        {
            return httpResponse;
        }
    }
}
