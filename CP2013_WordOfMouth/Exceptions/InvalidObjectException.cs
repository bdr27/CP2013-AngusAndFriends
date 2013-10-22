using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.Exceptions
{
    public class InvalidLoginObjectException : Exception
    {
        private int errorCode = 1;

        public int GetErrorCode()
        {
            return errorCode;
        }

        public string GetErrorMessage()
        {
            return "object passed in was not a login object";
        }
    }
}
