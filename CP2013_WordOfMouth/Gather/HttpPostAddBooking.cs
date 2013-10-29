using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostAddBooking : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAddBooking();
        private Http http;
        private HttpResponse response;

        public HttpPostAddBooking()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = "application/json";
        }
        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            var response = http.Post();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        #endregion
    }
}
