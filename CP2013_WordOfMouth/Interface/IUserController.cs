using CP2013_WordOfMouth.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Interface
{
    public interface IUserController
    {
        StateOfSystem GetSystemState();

        bool SetSystemState(UserActions action);

        object GetInformation();

        bool SetInformation(object o);
    }
}
