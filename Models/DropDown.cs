using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.Models
{
    class DropDown
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int ID { get; set; }

        public DropDown(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public DropDown(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
