using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.Models
{
    class CurrentUser
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string UserType { get; set; }
        public static string Username { get; set; }
        public static int UserId { get; set; }
        public static string AccountType { get; set; }
        public static string Timezone { get; set; }
    }
}
