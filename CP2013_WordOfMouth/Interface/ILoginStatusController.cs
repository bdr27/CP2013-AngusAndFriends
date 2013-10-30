using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Interface
{
    public interface ILoginStatusController
    {
        LoginStatus GetLoginStatus();

        void SetLoginStatus(Session key);
    }
}
