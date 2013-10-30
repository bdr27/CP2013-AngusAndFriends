using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;

namespace CP2013_WordOfMouth.Gather
{
    class HttpGetAllDentistTimes : IRequestResponse
    {
        private string urlBase = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetDentistTimes();

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
