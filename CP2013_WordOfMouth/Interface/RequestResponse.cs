using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using CP2013_WordOfMouth.DTO;

namespace CP2013_WordOfMouth.Interface
{
    public interface RequestResponse
    {
        List<Dentist> GetAllDentists();
        Dentist GetDentist(int id);
        void AddDentist(Dentist dentist);
        void DeleteDentist(int id);
        List<TimeSlots> GetAllTimeSlots();
        List<TimeSlots> GetTimeSlotsForDentist(int id);
        Session Login(OldLogin login);
    }
}
