using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.MOCK;

namespace CP2013_Assignment_Tests
{
    [TestClass]
    public class Utility
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
    }
}
