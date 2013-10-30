using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;
using CP2013_WordOfMouth.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonAppointmentsTests
    {
        private int idJson = 1;
        private AppointmentType apt;
        private TimeSlot ts;
        private Dentist den;
        private long ed;
        private Appointment app;
        //private string anotherTest = "[{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},{\"id\":2,\"name\":\"Dr. John Smith\",\"phone\":\"04 2977 9889\",\"email\":\"john.smith@wordofmouth.com\"},{\"id\":3,\"name\":\"Dr. Bob\",\"phone\":\"04 2977 9890\",\"email\":\"bob@wordofmouth.com\"},{\"id\":4,\"name\":\"Dr. Harry\",\"phone\":\"04 2977 9891\",\"email\":\"harry@wordofmouth.com\"},{\"id\":5,\"name\":\"Dr. Phil\",\"phone\":\"04 2977 9891\",\"email\":\"phil@wordofmouth.com\"}]";
        private string testJson = "{\"id\":1,\"type\":{\"id\":1,\"description\":\"Check Up\",\"cost\":50.0},\"timeSlot\":{\"id\":19,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"email\":\"smile@wordofmouth.com\",\"phone\":\"04 2977 9888\"},\"hour\":9,\"minute\":0,\"day\":3},\"expectedDate\":1383346800000}";
        private string correctJson = "[{\"id\":1,\"type\":{\"id\":1,\"description\":\"Check Up\",\"cost\":50.0},\"timeSlot\":{\"id\":19,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"email\":\"smile@wordofmouth.com\",\"phone\":\"04 2977 9888\"},\"hour\":9,\"minute\":0,\"day\":3},\"expectedDate\":1383346800000}]";

        public JsonAppointmentsTests()
        {
            idJson = 1;
            ed = 1383346800000;
            den = new Dentist(1, "Dr. Smile", "smile@wordofmouth.com", "04 2977 9888");
            apt = new AppointmentType(1, "Check Up", 50.0);
            ts = new TimeSlot(19, den, 9, 0, 3);
            app = new Appointment(1, apt, ts, ed);
        }

        [TestMethod]
        public void JsonAppointmentsObjectToJsonTest()
        {
            TemplateJson tl = new JsonAppointments();
            var json = tl.GetJson(app);
            Assert.AreEqual(testJson, json);
        }

        [TestMethod]
        public void JsonAppointmentsJsonToObjectTest()
        {
            TemplateJson tl = new JsonAppointments();
            var o = tl.GetObject(correctJson) as List<Appointment>;
            Assert.AreEqual(idJson, o[0].GetID());
            Assert.AreEqual(ed, o[0].GetExpectedDate());
        }

        [TestMethod]
        public void JsonAppointmentsObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonAppointments();
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
        public void JsonAppointmentsJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonAppointments();
            try
            {
                var o = tl.GetObject(incorrect) as List<Appointment>;
            }
            catch (Exception)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }

    }
}
