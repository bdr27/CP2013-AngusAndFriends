using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    interface IGetJsonResponse
    {
        string GetJsonResponse(TemplateJson tj, IRequestResponse irr, object o);
    }
}
