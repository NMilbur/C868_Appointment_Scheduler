using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.Models
{
    class Log
    {
        public static void LogEvent(string actionTaken)
        {
            File.AppendAllText("access_log.txt", $"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}] User \"{CurrentUser.Username}\" {actionTaken}\n");
        }
    }
}
