﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Utility
{
    public static class HTTP_INFO
    {
        private static string urlBase = "http://infinite-eyrie-6084.herokuapp.com/";
        private static string allDentists = "get/all/dentists";
        private static string dentist = "get/dentist/";
        private static string deleteDentist = "/delete/dentist/";
        private static string login = "/secure/login";
        private static string signUp = "/secure/signup";
        private static string poll = "/secure/poll";
        private static string appointments = "/get/bookings/for/";
        private static string timeSlotsBegining = "/get/times/for/dentist/";
        private static string timeSlotsEnding = "/which/are/avaliable";
        private static string addDentist = "/add/dentist";
        private static string addBooking = "/add/bookings";
        private static string appointmentTypes = "/get/all/appointment-types";
        private static string deleteBooking = "/delete/booking/";

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

        public static string GetLogin()
        {
            return login;
        }

        public static string GetSignUp()
        {
            return signUp;
        }

        public static string GetPoll()
        {
            return poll;
        }

        public static string GetAppointments()
        {
            return appointments;
        }

        public static string GetTimeSlotsBegining()
        {
            return timeSlotsBegining;
        }

        public static string GetTimeSlotsEnd()
        {
            return timeSlotsEnding;
        }

        public static string GetAddDentist()
        {
            return addDentist;
        }

        public static string GetAddBooking()
        {
            return addBooking;
        }

        public static string GetAppointmentTypes()
        {
            return appointmentTypes;
        }

        public static string GetDeleteBooking()
        {

            return deleteBooking;
        }
    }
}
