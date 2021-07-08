using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.Models
{
    class FormHandler
    {
        public bool stringCheck(string val)
        {
            return !String.IsNullOrWhiteSpace(val);
        }
        public bool hasValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);

                return true;

            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
