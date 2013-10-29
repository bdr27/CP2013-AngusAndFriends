using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostDeleteAppointment : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetDeleteBooking();
        private Http http;
        private HttpResponse response;

        public HttpPostDeleteAppointment()
        {
            http = new Http();
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + location + request);
        }

        public string GetResponse()
        {
            response = http.Post();
            return response.Content;
        }

        #endregion

        public HttpResponse GetHttpResponse()
        {
            return response;
        }
    }
}
