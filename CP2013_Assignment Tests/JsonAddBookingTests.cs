using System;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;
using CP2013_WordOfMouth.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonAddBookingTests
    {
        private string correctJson = "{\"seshID\":40,\"appointment_type\":2,\"dentist\":1,\"day\":0,\"time\":\"14:00\"}";

        private int sesseionID = 40;
        private int apt = 2;
        private int den = 1;
        private int day = 0;
        private string time = "14:00";

        [TestMethod]
        public void JsonAddBookingObjectToJsonTest()
        {
            TemplateJson tl = new JsonAddBooking();
            var dentists = new Booking(sesseionID, apt, den, day, time);
            var json = tl.GetJson(dentists);
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonAddBookingJsonToObjectTest()
        {
            TemplateJson tl = new JsonAddBooking();
            var o = tl.GetObject(correctJson) as Booking;
            Assert.AreEqual(sesseionID, o.GetSessionID());
            Assert.AreEqual(apt, o.GetAppointmentType());
            Assert.AreEqual(den, o.GetDentist());
            Assert.AreEqual(day, o.GetDay());
            Assert.AreEqual(time, o.GetTime());
        }

        [TestMethod]
        public void JsonAddBookingObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonAddBooking();
            try
            {
                var json = tl.GetJson("I am the wrong object");
            }
            catch (InvalidLoginObjectException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }

        [TestMethod]
        public void JsonAddBookingJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonAddBooking();
            try
            {
                var o = tl.GetObject(incorrect) as Booking;
            }
            catch (Exception)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
