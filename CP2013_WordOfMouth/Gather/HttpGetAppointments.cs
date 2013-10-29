using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAppointments : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAppointments();
        private Http http;

        public HttpGetAppointments()
        {
            http = new Http();
        }

        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + location + request);
        }

        public string GetResponse()
        {
            return http.Get().Content;
        }
    }
}
