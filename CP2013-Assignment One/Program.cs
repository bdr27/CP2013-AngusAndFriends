﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.Interface;
using CP2013_Assignment_One.MOCK;

namespace CP2013_Assignment_One
{
    class Program
    {
        const string MENU = "Where do you wish to do\n\t1. User UI\n\t2. Admin UI\n\t(Q)uit";
        const string ADMIN_MENU = "Do you want to\n\t1. Add Booking\n\t2. Add Dentist\n\t3. Remove Dentist\n\t(Q)uit";
        private static FileHandler fileHandler;

        public static void Main(string[] args)
        {
            fileHandler = new MOCKFileHandler();
            var key = GetStringFromOutput(MENU);
            while (key != "q")
            {
                switch (key)
                {
                    case "1":
                        UserUI();
                        break;
                    case "2":
                        AdminUI();
                        break;
                    default:
                        Console.WriteLine("unknown error");
                        break;
                }
                key = GetStringFromOutput(MENU);
            }
        }

        private static string GetStringFromOutput(string menu)
        {
           // Console.Clear();
            Console.WriteLine(menu);
            return Console.ReadLine().ToLower();
        }

        private static int GetIntFromOutput(string question)
        {
            var error = true;
            var num = 0;
            do
            {                
                Console.Write(question);
                var result = Console.ReadLine();
                error = Int32.TryParse(result, out num);
            } while (!error);

            return num;
        }

        private static void AdminUI()
        {
            //Add new dentist
            var key = GetStringFromOutput(ADMIN_MENU);
            while (key != "q")
            {
                switch (key)
                {
                    case "1":
                        AddBookingUI();
                        break;
                    case "2":
                        AddDentistUI();
                        break;
                    case "3":
                        RemoveDentistUI();
                        break;
                    default:
                        break;
                }
                key = GetStringFromOutput(MENU);
            }
        }

        private static void AddBookingUI()
        {
            Console.WriteLine("Bookings");
            var year = GetIntFromOutput("Please enter year: ");
            var day = GetIntFromOutput("Please enter day: ");
            var month = GetIntFromOutput("Please enter month: ");
            var hourStart = GetIntFromOutput("Please enter start time: ");
            var hourEnd = GetIntFromOutput("Please enter end time: ");
            var dentists = fileHandler.GetDentists();
            var dentistIDs = new List<int>();
            Console.WriteLine("Please enter your dentist number");
            foreach (var dentist in dentists.Values)
            {
                var ID = dentist.GetUserID();
                dentistIDs.Add(ID);
                Console.WriteLine(dentist.GetUserID() + ". " + dentist.ToString());
            }
            var dentistID = 0;
            do
            {
                dentistID = GetIntFromOutput(": ");
            } while (!dentistIDs.Contains(dentistID));
            var startTime = new DateTime(year, month, day, hourStart, 0, 0);
            var endTime = new DateTime(year, month, day, hourEnd, 0, 0);
            var timeSlot = new MOCKTimeSlot(startTime, endTime, dentistID);
        }

        private static void AddDentistUI()
        {
            Console.WriteLine("Add Dentists");
        }
        
        private static void RemoveDentistUI()
        {
            Console.WriteLine("Remove Dentists");
        }

        private static void UserUI()
        {
            Console.WriteLine("User UI");
        }
    }
}
