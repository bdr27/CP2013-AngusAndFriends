using CP2013_WordOfMouth.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetAllDentist : IRequestResponse
    {
        private string baseURL = HTTP_INFO.GetUrlBase();
        private string url = HTTP_INFO.GetAllDentists();

        static public void SendRequest(string request)
        {
            throw new NotImplementedException();
        }

        static public string GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
