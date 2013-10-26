using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Controllers
{
    public class UserController : IUserController
    {

        private StateOfSystem systemState;
        private LoginStatus loginStatus;

        public UserController()
        {
            systemState = StateOfSystem.HOME_PAGE_NLI;
            loginStatus = LoginStatus.LOGGED_OUT;
        }

        public StateOfSystem GetSystemState()
        {
            return systemState;
        }

        public bool SetSystemState(Enum.UserActions action)
        {
            if (action == UserActions.HOME_CLICK)
            {
                if (loginStatus == LoginStatus.LOGGED_OUT)
                {
                    systemState = StateOfSystem.HOME_PAGE_NLI;
                }
                else if (loginStatus == LoginStatus.ADMIN)
                {
                    systemState = StateOfSystem.HOME_PAGE_ADMIN;
                }
                else
                {
                    systemState = StateOfSystem.HOME_PAGE_USER;
                }
                return true;
            }

            if (action == UserActions.LOGIN_LOGOUT_CLICK)
            {
                if (loginStatus == LoginStatus.LOGGED_OUT)
                {
                    systemState = StateOfSystem.LOGIN_PAGE;
                }
                else
                {
                    systemState = StateOfSystem.HOME_PAGE_NLI;
                }
                return true;
            }

            if (systemState == StateOfSystem.LOGIN_PAGE && action == UserActions.JOIN_CLICK)
            {
                systemState = StateOfSystem.JOIN_PAGE;
                return true;
            }
            else if (systemState == StateOfSystem.JOIN_PAGE && action == UserActions.CANCEL_CLICK)
            {
                systemState = StateOfSystem.LOGIN_PAGE;
                return true;
            }

            return false;
        }

        public object GetInformation()
        {
            throw new NotImplementedException();
        }

        public bool SetInformation(object o)
        {
            throw new NotImplementedException();
        }
    }
}
