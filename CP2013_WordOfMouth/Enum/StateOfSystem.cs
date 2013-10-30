using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Enum
{
    public enum StateOfSystem
    {
        // User is not logged in states
        HOME_PAGE_NLI,
        LOGIN_PAGE,
        JOIN_PAGE,

        // User is logged in and is not an admin states
        HOME_PAGE_USER,
        APPOINTMENTS_PAGE,
        CREATE_APPOINT_PAGE,

        // Admin states
        HOME_PAGE_ADMIN,
        ADMIN_PAGE,
        ADD_DENTIST_PAGE,
        EDIT_DENTIST_PAGE,
        REMOVE_DENTIST_PAGE,
        ADD_APPOINT_TYPE_PAGE,
        REMOVE_APPOINT_TYPE_PAGE,
        EDIT_DENTIST_DETAILS_PAGE,
        
        // Verification states
        VERIFY_LOGIN,
        VERIFY_JOIN,
        VERIFY_LOGOUT,
        VERIFY_APPOINT_CREATE,
        VERIFY_APPOINT_REMOVE,
        VERIFY_ADD_DENTIST,
        VERIFY_EDIT_DENTIST,
        VERIFY_REMOVE_DENTIST,
        VERIFY_ADD_APPOINT_TYPE,
        VERIFY_REMOVE_APPOINT_TYPE,
        VERIFY_EDIT_DENTIST_DETAILS
    }
}
