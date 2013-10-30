using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostEditDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetEditDentist();
        private Http http;
        private HttpResponse response;

        public HttpPostEditDentist()
        {
            http = new Http();
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            response = http.Post();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        #endregion
    }
}
