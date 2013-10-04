using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Utility;

namespace CP2013_Assignment_One.Interface
{
    public interface RequestResponse
    {
        List<Dentist> GetAllDentists();
        Dentist GetDentist(int id);
        void AddDentist(Dentist dentist);
        void DeleteDentist(int id);
        List<TimeSlots> GetAllTimeSlots();
        List<TimeSlots> GetTimeSlotsForDentist(int id);
    }
}
