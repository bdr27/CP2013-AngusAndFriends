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
    public class StateController : IStateController
    {
        private IStateMachine stateMachine;
        private ILoginStatusController loginController;

        public StateController()
        {
            stateMachine = new StateMachine();
            loginController = new LoginStatusController();
        }

        public StateOfSystem GetSystemState()
        {
            return stateMachine.GetSystemState();
        }

        public bool SetSystemState(UserActions action)
        {
            var prevState = stateMachine.GetSystemState();

            if (prevState == StateOfSystem.VERIFY_LOGOUT)
            {
                loginController.SetLoginStatus(null);
                stateMachine.SetSystemState(action, loginController.GetLoginStatus());
            }
            else if (action == UserActions.LOGIN_LOGOUT_CLICK)
            {
                stateMachine.SetSystemState(action, loginController.GetLoginStatus());
                if (stateMachine.GetSystemState() == StateOfSystem.HOME_PAGE_NLI)
                {
                    loginController.SetLoginStatus(null);
                }
            }
            else
            {
                stateMachine.SetSystemState(action, loginController.GetLoginStatus());
            }

            return stateMachine.GetSystemState() != prevState;

        }

        public void SetLoginStatus(Session key)
        {
            loginController.SetLoginStatus(key);
        }

        public LoginStatus GetLoginStatus()
        {
            return loginController.GetLoginStatus();
        }
    }
}
