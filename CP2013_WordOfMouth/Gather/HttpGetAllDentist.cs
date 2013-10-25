using CP2013_WordOfMouth.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAllDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAllDentists();
        private Http http;

        public HttpGetAllDentist()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = HttpRequestType.GetInstance();
        }

        public void SendRequest(string request)
        {
            
        }

        public string GetResponse()
        {
            return http.Get().Content;
        }
    }
}
