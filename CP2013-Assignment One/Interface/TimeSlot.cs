using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.Interface
{
    public interface TimeSlot
    {
        int GetTimeSlotID();
        DateTime GetStartTime();
        DateTime GetEndTime();
        int GetUserID();
        int GetHoursBetween();
    }
}
