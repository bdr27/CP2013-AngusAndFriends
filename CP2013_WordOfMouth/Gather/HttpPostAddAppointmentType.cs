using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    class HttpPostAddAppointmentType : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAddAppointmentType();
        
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


        public HttpResponse GetHttpResponse()
        {
            throw new NotImplementedException();
        }
    }
}
