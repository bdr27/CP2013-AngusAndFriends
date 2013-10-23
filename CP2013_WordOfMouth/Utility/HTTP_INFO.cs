using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Utility
{
    public static class HTTP_INFO
    {
        public static string urlBase = "https://fast-taiga-8503.herokuapp.com/";
        public static string allDentists = "get/all/dentists";

        public static string GetUrlBase()
        {
            return urlBase;
        }

        public static string GetAllDentists()
        {
            return allDentists;
        }
    }
}
