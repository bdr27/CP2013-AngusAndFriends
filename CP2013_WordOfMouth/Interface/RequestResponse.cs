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
        List<OldDentist> GetAllDentists();
        OldDentist GetDentist(int id);
        void AddDentist(OldDentist dentist);
        void DeleteDentist(int id);
        List<OldTimeSlots> GetAllTimeSlots();
        List<OldTimeSlots> GetTimeSlotsForDentist(int id);
        Session Login(OldLogin login);
    }
}
