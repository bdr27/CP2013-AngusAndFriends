using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAllAvaliableTimes : IRequestResponse
    {
        public string baseUrl = HTTP_INFO.GetUrlBase();
        public string location = HTTP_INFO.GetAllAvliableTimes();

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
