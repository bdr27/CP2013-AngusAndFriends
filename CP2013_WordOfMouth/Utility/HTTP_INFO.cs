﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Utility
{
    public static class HTTP_INFO
    {
        private static string urlBase = "https://fast-taiga-8503.herokuapp.com/";
        private static string allDentists = "get/all/dentists";
        private static string dentist = "get/dentist/";
        private static string deleteDentist = "/delete/dentist/";

        public static string GetUrlBase()
        {
            return urlBase;
        }

        public static string GetAllDentists()
        {
            return allDentists;
        }

        public static string GetDentist()
        {
            return dentist;
        }

        public static string GetDeleteDentist()
        {
            return deleteDentist;
        }
    }
}
