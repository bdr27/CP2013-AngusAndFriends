using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.DTO
{
    public class AppointmentType
    {
        private int id;
        private string description;
        private double cost;

        public AppointmentType(int id, string description, double cost)
        {
            this.id = id;
            this.description = description;
            this.cost = cost;
        }

        public int GetID()
        {
            return id;
        }

        public string GetDescription()
        {
            return description;
        }

        public double GetCost()
        {
            return cost;
        }
    }
}
