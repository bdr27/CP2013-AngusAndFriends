using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Utility
{
    public class HttpRequestType
    {
        private static string instance = null;
        public HttpRequestType()
        {
        }

        public static string GetInstance()
        {
            if (instance == null)
            {
                instance = "application/json";
            }
            return instance;
        }
    }
}
