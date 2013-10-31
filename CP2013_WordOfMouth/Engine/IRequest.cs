using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Engine
{
    public interface IRequest
    {
        void SendRequest();

        object GetResponse();

        void SetRequest(object o);
    }
}
