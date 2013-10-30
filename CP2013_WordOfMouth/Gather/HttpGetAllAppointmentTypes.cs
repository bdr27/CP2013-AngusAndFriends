using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAllAppointmentTypes : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAppointmentTypes();
        private Http http;
        private HttpResponse httpResponse;

        public HttpGetAllAppointmentTypes()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            httpResponse = http.Get();
        }

        public string GetResponse()
        {
            return httpResponse.Content;
        }

        #endregion


        public HttpResponse GetHttpResponse()
        {
            return httpResponse;
        }
    }
}
