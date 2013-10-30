using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAllAvaliableTimes : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAllAvliableTimes();
        private Http http;
        private HttpResponse response;

        public HttpGetAllAvaliableTimes()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            response = http.Get();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        #endregion
    }
}
