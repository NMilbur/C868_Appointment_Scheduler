using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.Models
{
    class Meeting
    {
        public int MeetingId { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Approved { get; set; }
    }
}
