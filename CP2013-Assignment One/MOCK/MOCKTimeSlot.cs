using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Interface;

namespace CP2013_Assignment_One.MOCK
{
    public class MOCKTimeSlot : TimeSlot
    {
        int timeSlotID;
        DateTime startTime;
        DateTime endTime;
        int userID;

        public MOCKTimeSlot(DateTime startTime, DateTime endTime, int userID)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.userID = userID;
        }

        public MOCKTimeSlot(int timeSlotID, DateTime startTime, DateTime endTime, int userID)
        {
            this.timeSlotID = timeSlotID;
            this.startTime = startTime;
            this.endTime = endTime;
            this.userID = userID;
        }

        #region TimeSlot Members

        public int GetTimeSlotID()
        {
            return timeSlotID;
        }

        public DateTime GetStartTime()
        {
            return startTime;
        }

        public DateTime GetEndTime()
        {
            return endTime;
        }

        public int GetUserID()
        {
            return userID;
        }

        public int GetHoursBetween()
        {
            var between = endTime - startTime;
            return (int) between.TotalHours;
        }

        #endregion
    }
}
