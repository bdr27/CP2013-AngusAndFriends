using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public interface IRequestResponse
    {
        void SendRequest(string request);

        string GetResponse();

        HttpResponse GetHttpResponse();
    }
}
