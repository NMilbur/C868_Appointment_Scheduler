using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.Models
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountType { get; set; }
        public string Active { get; set; }
        public int AccountId { get; set; }
    }
}
