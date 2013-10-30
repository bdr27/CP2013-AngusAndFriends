using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostDeleteAppointmentType : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetDeleteAppointmentType();
        private Http http;

        private HttpResponse response;

        public HttpPostDeleteAppointmentType()
        {
            http = new Http();
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + location + request);
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
