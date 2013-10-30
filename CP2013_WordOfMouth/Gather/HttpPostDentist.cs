using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostDentist : IRequestResponse
    {
        //TODO THIS WHOLE CLASS
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetEditDentist();
        private Http http;
        private HttpResponse response;

        public HttpPostDentist()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
        }
        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.RequestBody = (request);
            response = http.Post();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        #endregion


        public HttpResponse GetHttpResponse()
        {
            return response;
        }
    }
}
