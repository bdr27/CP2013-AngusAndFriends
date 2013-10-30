using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetDentist();
        private Http http;
        //private string response;

        public HttpGetDentist()
        {
            http = new Http();
            http.RequestContentType = "application/json";
        }
        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + location + request);
            http.RequestBody = request;
        }

        public string GetResponse()
        {
            return http.Get().Content;
        }

        #endregion
    }
}
