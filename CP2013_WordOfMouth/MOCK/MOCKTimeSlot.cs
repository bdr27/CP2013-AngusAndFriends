using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Interface;

namespace CP2013_WordOfMouth.MOCK
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

        public int GetStartHours()
        {
            return startTime.Hour;
        }

        public int GetEndHours()
        {
            return endTime.Hour;
        }

        public int GetHoursBetween()
        {
            var between = endTime - startTime;
            return (int) between.TotalHours;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("ID: {0}, Start Time: {1}, End Time: {2}, User ID: {3}", timeSlotID, startTime, endTime, userID);
        }
    }
}
