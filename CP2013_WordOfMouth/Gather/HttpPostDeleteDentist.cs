using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostDeleteDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetDeleteDentist();
        private Http http;
        private HttpResponse httpResponse;

        public HttpPostDeleteDentist()
        {
            http = new Http();
            http.RequestContentType = HttpRequestType.GetInstance();
        }
        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + location + request);
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
