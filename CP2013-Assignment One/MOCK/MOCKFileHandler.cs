using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.Interface;

namespace CP2013_Assignment_One.MOCK
{
    public class MOCKFileHandler : FileHandler
    {
        int timeSlotsID;
        int usersID;
        int bookingID;
        Dictionary<int, TimeSlot> timeSlots;
        Dictionary<int, User> users;
        Dictionary<int, Booking> bookings;

        public MOCKFileHandler()
        {
            usersID = 1;
            timeSlotsID = 1;
            bookingID = 1;
            users = new Dictionary<int, User>();
            timeSlots = new Dictionary<int, TimeSlot>();
            bookings = new Dictionary<int, Booking>();
            LoadUsers();
            LoadTimeSlots();
            LoadBookings();
        }

        public void LoadBookings()
        {
            AddNewBooking(new MOCKBooking(2, 4, AppointmentType.GENERAL));
            AddNewBooking(new MOCKBooking(3, 3, AppointmentType.GENERAL));
            AddNewBooking(new MOCKBooking(4, 2, AppointmentType.GENERAL));
            AddNewBooking(new MOCKBooking(5, 1, AppointmentType.GENERAL));
        }

        public void LoadUsers()
        {
            AddNewUser(new MOCKUser("John Smith", UserType.ADMIN));
            AddNewUser(new MOCKUser("Pen Vide", UserType.DENTIST));
            AddNewUser(new MOCKUser("Home River", UserType.DENTIST));
            AddNewUser(new MOCKUser("First Person", UserType.USER));
        }

        public void LoadTimeSlots()
        {
            var day = 8;
            var month = 10;
            var year = 2013;
            var startTime = 8;
            var endTime = 15;

            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, endTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, endTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, endTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, endTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, endTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, endTime, 0, 0), 2));
        }

        #region FileHandler Members        

        public void AddExistingUser(User user)
        {
            users.Add(user.GetUserID(), user);
        }

        public void AddNewUser(User user)
        {
            var ID = usersID++;
            var newUser = new MOCKUser(ID, user.GetUsername(), user.GetUserType());
            users.Add(ID, newUser);
        }

        public void DeleteDentist(int userID)
        {
            users.Remove(userID);
        }

        public void AddNewTimeSlot(TimeSlot timeSlot)
        {
            var difference = timeSlot.GetHoursBetween();
            for (int i = 0; i < difference; i++)
            {
                var ID = timeSlotsID++;
                var time = timeSlot.GetStartTime();
                var year = time.Year;
                var day = time.Day;
                var month = time.Month;
                var hourStart = time.Hour + (i * 1);
                var endHour = hourStart + 1;
                var startTime = new DateTime(year, month, day, hourStart, 0, 0);
                var endTime = new DateTime(year, month, day, endHour, 0, 0);

                var newTimeSlot = new MOCKTimeSlot(ID, startTime, endTime, timeSlot.GetUserID());
                timeSlots.Add(ID, newTimeSlot);
            }
        }

        public void AddExistingTimeSlot(TimeSlot timeSlot)
        {
            timeSlots.Add(timeSlot.GetTimeSlotID(), new MOCKTimeSlot(timeSlot.GetTimeSlotID(), timeSlot.GetStartTime(), timeSlot.GetEndTime(), timeSlot.GetUserID()));
        }

        public void AddNewBooking(Booking booking)
        {
            var newBook = new MOCKBooking(bookingID, booking.GetTimeSlotID(), booking.GetUserID(), booking.GetAppontmentType());
            bookings.Add(bookingID++, newBook);
        }

        public void AddExistingBooking(Booking booking)
        {
            bookings.Add(booking.GetBookingID(), new MOCKBooking(booking.GetBookingID(), booking.GetTimeSlotID(), booking.GetUserID(), booking.GetAppontmentType()));
        }

        public void DeleteBooking(int bookingID)
        {
            bookings.Remove(bookingID);
        }

        public Dictionary<int, User> GetDentists()
        {
            var dentists = new Dictionary<int, User>();
            foreach (int userID in users.Keys)
            {
                var user = users[userID];
                if (user.GetUserType().Equals(UserType.DENTIST))
                {
                    dentists.Add(userID, user);
                }
            }
            return dentists;
        }

        public Dictionary<int, TimeSlot> GetAvaliableTimeSlots()
        {
            var ats = new Dictionary<int, TimeSlot>();
            foreach (var ts in timeSlots.Keys)
            {
                var taken = false;
                foreach (var book in bookings.Values)
                {
                    if (book.GetTimeSlotID() == ts)
                    {
                        taken = true;
                        break;
                    }
                }
                if (!taken)
                {
                    ats.Add(ts, timeSlots[ts]);
                }
            }
            return ats;
        }

        public Dictionary<int, TimeSlot> GetTimeSlots()
        {
            return timeSlots;
        }

        public Dictionary<int, User> GetAllUsers()
        {
            return users;
        }

        public Dictionary<int, Booking> GetAllBookings()
        {
            return bookings;
        }

        public Dictionary<int, TimeSlot> GetUserTimeSlots(int userID)
        {
            var bookings = GetUserBookings(userID);
            var ts = new Dictionary<int, TimeSlot>();
            foreach (var booking in bookings.Values)
            {
                ts.Add(booking.GetTimeSlotID(), timeSlots[booking.GetTimeSlotID()]);
            }
            return ts;
        }

        public Dictionary<int, Booking> GetUserBookings(int userID)
        {
            var b = new Dictionary<int, Booking>();
            foreach (var booking in bookings.Values)
            {
                if (booking.GetUserID() == userID)
                {
                    b.Add(booking.GetBookingID(), booking);
                }
            }
            return b;
        }

        public User GetDentist(int userID)
        {
            return users[userID];
        }

        #endregion
    }
}
