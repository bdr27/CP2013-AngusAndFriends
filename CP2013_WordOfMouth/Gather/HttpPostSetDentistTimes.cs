using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;

namespace CP2013_WordOfMouth.Gather
{
    class HttpPostSetDentistTimes : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetSetTimeForDentist();

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


        public RestSharp.HttpResponse GetHttpResponse()
        {
            throw new NotImplementedException();
        }
    }
}
