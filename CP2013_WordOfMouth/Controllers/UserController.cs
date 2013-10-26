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
    public class StateMachine : IStateMachine
    {

        private StateOfSystem state;
        private LoginStatus loginStatus;

        public StateMachine()
        {
            state = StateOfSystem.HOME_PAGE_NLI;
            loginStatus = LoginStatus.LOGGED_OUT;
        }

        public StateOfSystem GetSystemState()
        {
            return state;
        }

        public bool SetSystemState(UserActions action)
        {
            if (action == UserActions.HOME_CLICK)
            {
                if (loginStatus == LoginStatus.LOGGED_OUT)
                {
                    state = StateOfSystem.HOME_PAGE_NLI;
                }
                else if (loginStatus == LoginStatus.ADMIN)
                {
                    state = StateOfSystem.HOME_PAGE_ADMIN;
                }
                else
                {
                    state = StateOfSystem.HOME_PAGE_USER;
                }
                return true;
            }

            if (action == UserActions.LOGIN_LOGOUT_CLICK)
            {
                if (loginStatus == LoginStatus.LOGGED_OUT)
                {
                    state = StateOfSystem.LOGIN_PAGE;
                }
                else
                {
                    state = StateOfSystem.HOME_PAGE_NLI;
                }
                return true;
            }

            if (state == StateOfSystem.LOGIN_PAGE && action == UserActions.JOIN_CLICK)
            {
                state = StateOfSystem.JOIN_PAGE;
                return true;
            }
            else if (state == StateOfSystem.JOIN_PAGE && action == UserActions.JOIN_CLICK)
            {
                state = StateOfSystem.VERIFY_JOIN;
                return true;
            }
            else if (state == StateOfSystem.JOIN_PAGE && action == UserActions.CANCEL_CLICK)
            {
                state = StateOfSystem.LOGIN_PAGE;
                return true;
            }
            else if (state == StateOfSystem.VERIFY_JOIN && action == UserActions.SUCCESS)
            {
                state = StateOfSystem.LOGIN_PAGE;
                return true;
            }
            else if (state == StateOfSystem.VERIFY_JOIN && action == UserActions.FAILURE)
            {
                state = StateOfSystem.JOIN_PAGE;
                return true;
            }

            return false;
        }
    }
}
