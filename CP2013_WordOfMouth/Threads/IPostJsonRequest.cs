using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    public interface IPostJsonRequest
    {
        string PostJsonResponse(TemplateJson tj, IRequestResponse irr, object o);
    }
}
