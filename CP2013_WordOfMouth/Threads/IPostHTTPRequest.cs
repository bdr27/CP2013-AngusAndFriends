using CP2013_WordOfMouth.Gather;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    public interface IPostHTTPRequest
    {
        HttpResponse PostHttpRequest(IRequestResponse h, object o);
    }
}
