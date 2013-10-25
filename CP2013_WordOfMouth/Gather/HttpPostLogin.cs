using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostLogin : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetLogin();
        private Http http;
        private HttpResponse httpResponse;

        public HttpPostLogin()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = RequestType.GetInstance();
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            httpResponse = http.Post();
        }

        public string GetResponse()
        {
            return httpResponse.Content;
        }

        #endregion
    }
}
