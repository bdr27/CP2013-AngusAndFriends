using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Engine
{
    public interface IActiveObjectEngine
    {
        void Run();

        bool Cancel();

        bool AddRequest(IRequest request);
    }
}
