using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Http;

namespace CP2013_Assignment_One.Interface
{
    public interface RequestResponse
    {
        List<Dentist> GetAllDentists();
        Dentist GetDentist(int id);
        void AddDentist(Dentist dentist);
        List<TimeSlots> GetAllTimeSlots();
        List<TimeSlots> GetTimeSlotsForDentist(int id);
    }
}
