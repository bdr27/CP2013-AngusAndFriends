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
            var prevState = state;

            // NAV bar doesn't work during verifying states
            if (!IsInVerifingState())
            {
                // NAV home page clicks >> returns user to home page
                if (action == UserActions.HOME_CLICK && !IsInVerifingState())
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
                }

                // NAV logout button clicks >> logs user out
                if (action == UserActions.LOGIN_LOGOUT_CLICK && !IsInVerifingState())
                {
                    if (loginStatus == LoginStatus.LOGGED_OUT)
                    {
                        state = StateOfSystem.LOGIN_PAGE;
                    }
                    else
                    {
                        state = StateOfSystem.HOME_PAGE_NLI;
                        loginStatus = LoginStatus.LOGGED_OUT;
                    }
                }

                // NAV admin button clicks >> takes user to admin panel if user is an admin
                if (action == UserActions.ADMIN_CLICK && loginStatus == LoginStatus.ADMIN)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }

                // NAV appointments button clicks >> takes user to appointments page if user is not an admin
                if (action == UserActions.APPOINTMENTS_CLICK && loginStatus == LoginStatus.USER)
                {
                    state = StateOfSystem.APPOINTMENTS_PAGE;
                }

                // login page state | Possible actions >> Join, Login
                if (state == StateOfSystem.LOGIN_PAGE && action == UserActions.JOIN_CLICK)
                {
                    state = StateOfSystem.JOIN_PAGE;
                }
                else if (state == StateOfSystem.LOGIN_PAGE && action == UserActions.LOGIN_CLICK)
                {
                    state = StateOfSystem.VERIFY_LOGIN;
                }

                // join page state | Possible actions >> Join, Cancel
                else if (state == StateOfSystem.JOIN_PAGE && action == UserActions.JOIN_CLICK)
                {
                    state = StateOfSystem.VERIFY_JOIN;
                }
                else if (state == StateOfSystem.JOIN_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.LOGIN_PAGE;
                }

                // appointments page state | Possible actions >> Create, Remove
                else if (state == StateOfSystem.APPOINTMENTS_PAGE && action == UserActions.CREATE_CLICK)
                {
                    state = StateOfSystem.CREATE_APPOINT_PAGE;
                }
                else if (state == StateOfSystem.APPOINTMENTS_PAGE && action == UserActions.REMOVE_CLICK)
                {
                    state = StateOfSystem.VERIFY_APPOINT_REMOVE;
                }

                // new appointment page state | Possible actions >> Create, Cancel
                else if (state == StateOfSystem.CREATE_APPOINT_PAGE && action == UserActions.CREATE_CLICK)
                {
                    state = StateOfSystem.VERIFY_APPOINT_CREATE;
                }
                else if (state == StateOfSystem.CREATE_APPOINT_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.APPOINTMENTS_PAGE;
                }

                // admin page state | Possible actions >> Add Dentist, Edit Dentist, Remove Dentist, Add App Type, Remove App Type
                else if (state == StateOfSystem.ADMIN_PAGE && action == UserActions.ADD_DEN_CLICK)
                {
                    state = StateOfSystem.ADD_DENTIST_PAGE;
                }
                else if (state == StateOfSystem.ADMIN_PAGE && action == UserActions.EDIT_DEN_CLICK)
                {
                    state = StateOfSystem.EDIT_DENTIST_PAGE;
                }
                else if (state == StateOfSystem.ADMIN_PAGE && action == UserActions.REMOVE_DEN_CLICK)
                {
                    state = StateOfSystem.REMOVE_DENTIST_PAGE;
                }
                else if (state == StateOfSystem.ADMIN_PAGE && action == UserActions.ADD_APP_TYPE_CLICK)
                {
                    state = StateOfSystem.ADD_APPOINT_TYPE_PAGE;
                }
                else if (state == StateOfSystem.ADMIN_PAGE && action == UserActions.REMOVE_APP_TYPE_CLICK)
                {
                    state = StateOfSystem.REMOVE_APPOINT_TYPE_PAGE;
                }

                // add dentist page state | Possible actions >> Create, Cancel
                else if (state == StateOfSystem.ADD_DENTIST_PAGE && action == UserActions.CREATE_CLICK)
                {
                    state = StateOfSystem.VERIFY_ADD_DENTIST;
                }
                else if (state == StateOfSystem.ADD_DENTIST_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }

                // edit dentist page state | Possible actions >> Update, Cancel
                else if (state == StateOfSystem.EDIT_DENTIST_PAGE && action == UserActions.UPDATE_CLICK)
                {
                    state = StateOfSystem.VERIFY_EDIT_DENTIST;
                }
                else if (state == StateOfSystem.EDIT_DENTIST_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }

                // remove dentist page state | Possible actions >> Remove, Cancel
                else if (state == StateOfSystem.REMOVE_DENTIST_PAGE && action == UserActions.REMOVE_CLICK)
                {
                    state = StateOfSystem.VERIFY_REMOVE_DENTIST;
                }
                else if (state == StateOfSystem.REMOVE_DENTIST_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }

                // add appointment type page | Possible actions >> Create, Cancel
                else if (state == StateOfSystem.ADD_APPOINT_TYPE_PAGE && action == UserActions.CREATE_CLICK)
                {
                    state = StateOfSystem.VERIFY_ADD_APPOINT_TYPE;
                }
                else if (state == StateOfSystem.ADD_APPOINT_TYPE_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }

                // remove appointment type page | Possible actions >> Remove, Cancel
                else if (state == StateOfSystem.REMOVE_APPOINT_TYPE_PAGE && action == UserActions.REMOVE_CLICK)
                {
                    state = StateOfSystem.VERIFY_REMOVE_APPOINT_TYPE;
                }
                else if (state == StateOfSystem.REMOVE_APPOINT_TYPE_PAGE && action == UserActions.CANCEL_CLICK)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }
            }
            
            // verify join states | Possible actions >> Success, Failure
            if (state == StateOfSystem.VERIFY_JOIN && action == UserActions.SUCCESS)
            {
                state = StateOfSystem.LOGIN_PAGE;
            }
            else if (state == StateOfSystem.VERIFY_JOIN && action == UserActions.FAILURE)
            {
                state = StateOfSystem.JOIN_PAGE;
            }

            // verify login states | Possible actions >> Success, Failure
            else if (state == StateOfSystem.VERIFY_LOGIN && action == UserActions.SUCCESS)
            {
                if (loginStatus == LoginStatus.ADMIN)
                {
                    state = StateOfSystem.ADMIN_PAGE;
                }
                else if (loginStatus == LoginStatus.USER)
                {
                    state = StateOfSystem.APPOINTMENTS_PAGE;
                }
            }
            else if (state == StateOfSystem.VERIFY_LOGIN && action == UserActions.FAILURE)
            {
                state = StateOfSystem.LOGIN_PAGE;
            }

            // verify logout states | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_LOGOUT)
            {
                state = StateOfSystem.HOME_PAGE_NLI;
                loginStatus = LoginStatus.LOGGED_OUT;
            }

            // verify creating appointments | Possible actions >> Success, Failure
            else if (state == StateOfSystem.VERIFY_APPOINT_CREATE && action == UserActions.SUCCESS)
            {
                state = StateOfSystem.APPOINTMENTS_PAGE;
            }
            else if (state == StateOfSystem.VERIFY_APPOINT_CREATE && action == UserActions.FAILURE)
            {
                state = StateOfSystem.CREATE_APPOINT_PAGE;
            }

            // verify removing appointments | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_APPOINT_REMOVE)
            {
                state = StateOfSystem.APPOINTMENTS_PAGE;
            }

            // verify adding a new dentist | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_ADD_DENTIST)
            {
                state = StateOfSystem.ADD_DENTIST_PAGE;
            }

            // verify editing an existing dentist | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_EDIT_DENTIST)
            {
                state = StateOfSystem.EDIT_DENTIST_PAGE;
            }

            // verify removing a dentist | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_REMOVE_DENTIST)
            {
                state = StateOfSystem.REMOVE_DENTIST_PAGE;
            }

            // verify adding an appointment type | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_ADD_APPOINT_TYPE)
            {
                state = StateOfSystem.ADD_APPOINT_TYPE_PAGE;
            }

            // verify removing an appointment type | Possible actions >> None
            else if (state == StateOfSystem.VERIFY_REMOVE_APPOINT_TYPE)
            {
                state = StateOfSystem.VERIFY_REMOVE_APPOINT_TYPE;
            }

            return prevState != state;
        }

        public void SetLoginStatus(Session key)
        {
            if (key == null)
            {
                loginStatus = LoginStatus.LOGGED_OUT;
            }
            else if (key.GetAdmin())
            {
                loginStatus = LoginStatus.ADMIN;
            }
            else
            {
                loginStatus = LoginStatus.USER;
            }
        }

        public LoginStatus GetLoginStatus()
        {
            return loginStatus;
        }

        private bool IsInVerifingState()
        {
            switch (state)
            {
                case StateOfSystem.VERIFY_ADD_APPOINT_TYPE:
                case StateOfSystem.VERIFY_ADD_DENTIST:
                case StateOfSystem.VERIFY_APPOINT_CREATE:
                case StateOfSystem.VERIFY_APPOINT_REMOVE:
                case StateOfSystem.VERIFY_EDIT_DENTIST:
                case StateOfSystem.VERIFY_JOIN:
                case StateOfSystem.VERIFY_LOGIN:
                case StateOfSystem.VERIFY_LOGOUT:
                case StateOfSystem.VERIFY_REMOVE_APPOINT_TYPE:
                case StateOfSystem.VERIFY_REMOVE_DENTIST:
                    {
                        return true;
                    }
            }
            return false;
        }
    }
}
