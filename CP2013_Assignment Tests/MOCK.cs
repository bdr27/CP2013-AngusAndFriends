using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.MOCK;
using CP2013_WordOfMouth.Interface;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class MOCK
    {
        [TestMethod]
        public void MOCKUserTests()
        {
            int userID = 1;
            string username = "johnSmith";
            UserType userType = UserType.ADMIN;
            var user = new MOCKUser(userID, username, userType);
            Assert.AreEqual(userID, user.GetUserID());
            Assert.AreEqual(username, user.GetUsername());
            Assert.AreEqual(userType, user.GetUserType());
        }

        [TestMethod]
        public void MOCKTimeSlotTests()
        {
            var timeSlotID = 1;
            var userID = 1;
            var year = 2013;
            var day = 2;
            var month = 12;
            var hourStart = 12;
            var hourEnd = 15;
            var startTime = new DateTime(year, month, day, hourStart, 0, 0);            
            var endTime = new DateTime(year, month, day, hourEnd, 0, 0);
            var mockTimeSlot = new MOCKTimeSlot(timeSlotID, startTime, endTime, userID);

            Assert.AreEqual(timeSlotID, mockTimeSlot.GetTimeSlotID());
            Assert.AreEqual(userID, mockTimeSlot.GetUserID());
            Assert.AreEqual(startTime, mockTimeSlot.GetStartTime());
            Assert.AreEqual(endTime, mockTimeSlot.GetEndTime());
            Assert.AreEqual(hourEnd - hourStart, mockTimeSlot.GetHoursBetween());
        }

        [TestMethod]
        public void MOCKFileHandlerAddDeleteDentistTests()
        {
            var mockFileHandler = new MOCKFileHandler();
            int userID = 100;
            string username = "johnSmith";
            UserType userType = UserType.ADMIN;
            User newUser = new MOCKUser(userID, username, userType);
            mockFileHandler.AddExistingUser(newUser);
            var user = mockFileHandler.GetDentist(userID);

            Assert.AreEqual(userID, user.GetUserID());
            Assert.AreEqual(username, user.GetUsername());
            Assert.AreEqual(userType, user.GetUserType());

            mockFileHandler.DeleteDentist(userID);
            var users = mockFileHandler.GetDentists();
            Assert.IsFalse(users.ContainsKey(userID));
        }

        [TestMethod]
        public void MOCKFileHandlerTestLoad()
        {
            var mockFileHandler = new MOCKFileHandler();
            var users = mockFileHandler.GetAllUsers();
            foreach (var id in users.Keys)
            {
                Assert.AreEqual(id, users[id].GetUserID());
            }
            var timeSlots = mockFileHandler.GetTimeSlots();
            foreach (var id in timeSlots.Keys)
            {
                Assert.AreEqual(id, timeSlots[id].GetTimeSlotID());
            }
        }

        [TestMethod]
        public void MOCKFileHandlerAddNewTimeSlots()
        {
            var startTime = 8;
            var endTime = 15;
            var fileHandler = new MOCKFileHandler();
            var times = fileHandler.GetTimeSlots();
            
            for (int i = 0; i < (startTime - endTime); i++)
            {
                Assert.AreEqual(startTime + (1 * i), times[i].GetStartHours());
            }
        }

        [TestMethod]
        public void MOCKFileHandlerAddDeleteTimeSlotsTests()
        {
            var timeSlotID = 100;
            var userID = 100;
            var year = 2013;
            var day = 2;
            var month = 12;
            var hourStart = 8;
            var hourEnd = 15;
            var startTime = new DateTime(year, month, day, hourStart, 0, 0);
            var endTime = new DateTime(year, month, day, hourEnd, 0, 0);
            var mockTimeSlot = new MOCKTimeSlot(timeSlotID, startTime, endTime, userID);
            var mockFileHandler = new MOCKFileHandler();
            mockFileHandler.AddExistingTimeSlot(mockTimeSlot);
            var timeSlots = mockFileHandler.GetTimeSlots();

            Assert.AreEqual(timeSlotID, timeSlots[timeSlotID].GetTimeSlotID());
            Assert.AreEqual(userID, timeSlots[timeSlotID].GetUserID());
            Assert.AreEqual(startTime, timeSlots[timeSlotID].GetStartTime());
            Assert.AreEqual(endTime, timeSlots[timeSlotID].GetEndTime());
            Assert.AreEqual(hourEnd - hourStart, timeSlots[timeSlotID].GetHoursBetween());
        }

        [TestMethod]
        public void MOCKBooking()
        {
            int bookingID = 12;
            int timeSlotID = 2;
            int userID = 3;
            AppointmentType appointmentType = AppointmentType.GENERAL;

            var booking = new MOCKBooking(bookingID, timeSlotID, userID, appointmentType);
            Assert.AreEqual(bookingID, booking.GetBookingID());
            Assert.AreEqual(timeSlotID, booking.GetTimeSlotID());
            Assert.AreEqual(userID, booking.GetUserID());
            Assert.AreEqual(appointmentType, booking.GetAppontmentType());
        }

        [TestMethod]
        public void MOCKFileHandlerAddBooking()
        {
            var bookingID = 50;
            var timeSlotID = 2;
            var userID = 10;
            var apType = AppointmentType.GENERAL;

            var booking = new MOCKBooking(bookingID, timeSlotID, userID, apType);
            var fileHandler = new MOCKFileHandler();
            fileHandler.AddExistingBooking(booking);
            var userBooking = fileHandler.GetUserBookings(userID);
            Assert.AreEqual(timeSlotID, userBooking[bookingID].GetTimeSlotID());
            Assert.AreEqual(userID, userBooking[bookingID].GetUserID());
            Assert.AreEqual(apType, userBooking[bookingID].GetAppontmentType());
        }

        [TestMethod]
        public void MOCKFileHandlerDeleteBooking()
        {
            var bookingID = 50;
            var timeSlotID = 2;
            var userID = 10;
            var apType = AppointmentType.GENERAL;

            var booking = new MOCKBooking(bookingID, timeSlotID, userID, apType);
            var fileHandler = new MOCKFileHandler();
            fileHandler.AddExistingBooking(booking);
            var userBooking = fileHandler.GetUserBookings(userID);
            Assert.AreEqual(timeSlotID, userBooking[bookingID].GetTimeSlotID());
            Assert.AreEqual(userID, userBooking[bookingID].GetUserID());
            Assert.AreEqual(apType, userBooking[bookingID].GetAppontmentType());

            fileHandler.DeleteBooking(userBooking[bookingID].GetBookingID());

            var newBooking = fileHandler.GetUserBookings(userID);
            Assert.AreEqual(0, newBooking.Count);
        }

        [TestMethod]
        public void MOCKFileHandlerTestAvaliableTimeSlots()
        {
            var fileHandler = new MOCKFileHandler();
            var totalTimeSlots = fileHandler.GetTimeSlots();
            var avaliableTimeSlots = fileHandler.GetAvaliableTimeSlots();
            var takenSlots = fileHandler.GetAllBookings();
            Assert.AreEqual(totalTimeSlots.Count - avaliableTimeSlots.Count, takenSlots.Count);
            foreach (var booking in takenSlots.Values)
            {
                Assert.IsFalse(avaliableTimeSlots.ContainsKey(booking.GetTimeSlotID()));
            }
        }
    }
}
