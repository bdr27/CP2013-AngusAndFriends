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
        private string location = HTTP_INFO.GetAddDentist();
        private Http http;

        public HttpPostDentist()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
        }
        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            throw new NotImplementedException();
        }

        public string GetResponse()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
