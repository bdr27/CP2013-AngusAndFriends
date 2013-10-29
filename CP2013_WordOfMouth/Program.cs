using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Utility;
using CP2013_WordOfMouth.Interface;
using CP2013_WordOfMouth.MOCK;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.DTO;

namespace CP2013_WordOfMouth
{
    class Program
    {
        const string MENU = "Where do you wish to do\n\t1. User UI\n\t2. Admin UI\n\t(Q)uit";
        const string ADMIN_MENU = "Do you want to\n\t1. Add Booking\n\t2. Add Dentist\n\t3. Remove Dentist\n\t(Q)uit";
        const string USER_MENU = "Do you want to\n\t1. View Bookings\n\t2. Add Booking\n\t3. Remove Booking\n\t(Q)uit";
        private static FileHandler fileHandler;
        private static RequestResponse rr = new HttpRequests("https://fast-taiga-8503.herokuapp.com/");
        public static void Main(string[] args)
        {
            var Login = new Login("test.user@domain.com", "Password");
            var json = new JsonLogin().GetJson(Login);
            var something = PostRequests(new HttpPostLogin(), json);
            var newSession = new JsonSession().GetObject(something) as Session;
            GetRequests(new HttpGetAllDentist(), new JsonAllDentists(), "");
            GetRequests(new HttpGetDentist(), new JsonDentist(), 1.ToString());
            GetRequests(new HttpGetAppointments(), new JsonAppointments(), newSession.GetSessionID().ToString());
            //var Login = new Login("test.user@domain.com", "Password");
            //var json = new JsonLogin().GetJson(Login);

            
            PostRequests(new HttpPostDeleteDentist(), 37.ToString());
            #region OLDMAIN
            var login = new OldLogin("test.user@domain.com", "Password");
            var session = rr.Login(login);
            var dentists = rr.GetAllDentists();
            var dentist = rr.GetDentist(dentists[0].id);
            var timeSlots = rr.GetAllTimeSlots();

            Console.WriteLine(timeSlots);
            rr.GetTimeSlotsForDentist(dentists[0].id);
            Console.WriteLine(dentists);


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
            #endregion
        }

        private static void GetRequests(IRequestResponse irr, TemplateJson ts, string message)
        {
            irr.SendRequest(message);
            var json = irr.GetResponse();
            var objects = ts.GetObject(json);
        }

        private static string PostRequests(IRequestResponse irr, string message)
        {
            irr.SendRequest(message);
            var response = irr.GetResponse();
            return response;
        }
        private static void GetAllDentists()
        {
            IRequestResponse irr = new HttpGetAllDentist();
            TemplateJson ts = new JsonAllDentists();
            var test = irr.GetResponse();
            var dentistser = ts.GetObject(test);
        }

        private static void GetDentist(int id)
        {
            IRequestResponse irr = new HttpGetDentist();
            TemplateJson ts = new JsonDentist();
            irr.SendRequest(id.ToString());
            var json = irr.GetResponse();
            var objects = ts.GetObject(json);
        }

        private static string GetStringFromOutput(string menu)
        {
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
            var key = GetStringFromOutput(ADMIN_MENU);
            while (key != "q")
            {
                switch (key)
                {
                    case "1":
                        printTimeSlots();
                        AddBookingUI();
                        break;
                    case "2":
                        printDentists();
                        AddDentistUI();
                        break;
                    case "3":
                        RemoveDentistUI();
                        break;
                    default:
                        break;
                }
                key = GetStringFromOutput(ADMIN_MENU);
            }
        }

        private static void printTimeSlots()
        {
            foreach (var timeSlot in fileHandler.GetTimeSlots())
            {
                Console.WriteLine(timeSlot);
            }
        }

        private static void printDentists()
        {
            foreach (var dentist in fileHandler.GetDentists())
            {
                Console.WriteLine(dentist);
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
            Console.WriteLine("Please enter your dentist number");
            var dentistID = GetDentistID(dentists);
            
            var startTime = new DateTime(year, month, day, hourStart, 0, 0);
            var endTime = new DateTime(year, month, day, hourEnd, 0, 0);
            var timeSlot = new MOCKTimeSlot(startTime, endTime, dentistID);
            fileHandler.AddNewTimeSlot(timeSlot);
        }

        private static int GetDentistID(Dictionary<int, User> dentists)
        {
            foreach (var dentist in dentists.Values)
            {
                var ID = dentist.GetUserID();
                Console.WriteLine(dentist.GetUserID() + ". " + dentist.ToString());
            }
            var dentistID = 0;
            do
            {
                dentistID = GetIntFromOutput(": ");
            } while (!dentists.Keys.Contains(dentistID));
            return dentistID;
        }

        private static void AddDentistUI()
        {
            Console.WriteLine("Add Dentists");
            var username = GetStringFromOutput("Please enter dentist name: ");
            fileHandler.AddNewUser(new MOCKUser(username, UserType.DENTIST));
        }
        
        private static void RemoveDentistUI()
        {
            Console.WriteLine("Remove Dentists");
            var dentistID = GetDentistID(fileHandler.GetDentists());
            fileHandler.DeleteDentist(dentistID);
        }

        private static void UserUI()
        {
            var key = GetStringFromOutput(USER_MENU);
            while (key != "q")
            {
                switch (key)
                {
                    case "1":
                        ViewBookings();
                        break;
                    case "2":
                        AddBookings();
                        break;
                    case "3":
                        RemoveBooking();
                        break;
                    default:
                        break;
                }
                key = GetStringFromOutput(USER_MENU);
            }
        }

        private static void RemoveBooking()
        {
            var userID = GetUserID();
            var appointment = GetAppointment(userID);
            fileHandler.DeleteBooking(appointment);
        }

        private static int GetAppointment(int userID)
        {
            var bookings = fileHandler.GetUserBookings(userID);
            foreach (var book in bookings)
            {
                Console.WriteLine(book.ToString());
            }
            var num = 0;
            while (true)
            {            
                if(Int32.TryParse(Console.ReadLine(), out num))
                {
                    if (bookings.ContainsKey(num))
                    {
                        break;
                    }
                }                
            }
            return num;
        }

        private static void AddBookings()
        {
            var result = 0;
            var avaliableTimes = fileHandler.GetAvaliableTimeSlots();
            foreach (var time in avaliableTimes.Values)
            {
                Console.WriteLine(time.GetTimeSlotID() + ". " + time.ToString());
            }
            while (true)
            {
                var query = Console.ReadLine();
                if (Int32.TryParse(query, out result) && avaliableTimes.Keys.Contains(result))
                {
                    break;
                }
            }
            var userID = GetUserID();
           // var booking = new MOCKBooking(result, userID, AppointmentType.GENERAL);
           // fileHandler.AddNewBooking(booking);
        }

        private static void ViewBookings()
        {
            var userID = GetUserID();
            var bookings = fileHandler.GetUserBookings(userID);
            foreach (var book in bookings)
            {
                Console.WriteLine(book.ToString());
            }
        }

        private static int GetUserID()
        {
            int result = 0;
            var query = "";
            var users = fileHandler.GetAllUsers();
            do
            {
                foreach (var user in users.Values)
                {
                    Console.WriteLine(user.GetUserID() + ". " + user.GetUsername());
                }
                query = Console.ReadLine();
                if (Int32.TryParse(query, out result) && users.Keys.Contains(result))
                {
                    break;                    
                }
            } while (true);
            return result;
        }
    }
}
