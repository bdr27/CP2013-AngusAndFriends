using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Controllers
{
    public class LoginStatusController : ILoginStatusController
    {
        private LoginStatus login;

        public LoginStatusController()
        {
            login = LoginStatus.LOGGED_OUT;
        }

        public LoginStatus GetLoginStatus()
        {
            return login;
        }

        public void SetLoginStatus(Session key)
        {
            if (key == null)
            {
                login = LoginStatus.LOGGED_OUT;
            }
            else if (key.GetAdmin())
            {
                login = LoginStatus.ADMIN;
            }
            else
            {
                login = LoginStatus.USER;
            }
        }
    }
}
