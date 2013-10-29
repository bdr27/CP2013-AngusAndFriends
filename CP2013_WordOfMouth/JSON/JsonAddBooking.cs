using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAddBooking : TemplateJson
    {
        public override string GetJson(object o)
        {
            var book = o as Booking;
            CheckNull(book);
            var b = new ConverterBooking(book.GetSessionID(), book.GetAppointmentType(), book.GetDentist(), book.GetDay(), book.GetTime());
            return JsonConvert.SerializeObject(b);
        }

        public override object GetObject(string json)
        {
            var cb = JsonConvert.DeserializeObject<ConverterBooking>(json);
            CheckValidParams(cb.time);
            return new Booking(cb.seshID, cb.appointment_type, cb.dentist, cb.day, cb.time);
        }
    }
}
