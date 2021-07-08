using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.ViewModels
{
    class AccountHandler
    {
        public static bool LogUserIn(string username, string password)
        {
            List<Hashtable> accountData = GetUserData(username, password);

            if (accountData.Count() > 0)
            {
                DateTime currentDate = DateTime.Now;

                Models.CurrentUser.UserId = (int)accountData[0][0];
                Models.CurrentUser.FirstName = accountData[0][1].ToString();
                Models.CurrentUser.LastName = accountData[0][2].ToString();
                Models.CurrentUser.Username = accountData[0][3].ToString();
                Models.CurrentUser.AccountType = accountData[0][4].ToString();
                Models.CurrentUser.Timezone = TimeZone.CurrentTimeZone.GetUtcOffset(currentDate).ToString().Substring(0, 6);

                Models.Log.LogEvent("logged in");

                return true;
            }

            return false;
        }

        public static void LogUserOut()
        {
            Models.Log.LogEvent("logged out");

            Models.CurrentUser.UserId = -1;
            Models.CurrentUser.FirstName = "";
            Models.CurrentUser.LastName = "";
            Models.CurrentUser.Username = "";
            Models.CurrentUser.AccountType = "";
            Models.CurrentUser.Timezone = "";
        }

        public static bool checkUserNameExists(string username)
        {
            Models.DatabaseHandler dbh = new Models.DatabaseHandler();

            string exists = dbh.GetSqlValue($"SELECT IFNULL(username, 'No') FROM account WHERE username = \"{username}\"");

            return (exists == "Yes") ? true : false;
        }

        private static List<Hashtable> GetUserData(string username, string password)
        {
            Models.DatabaseHandler dbh = new Models.DatabaseHandler();

            string sql = $"SELECT accountId, firstName, lastName, username, accountType FROM account WHERE username = \"{username}\" AND password = \"{password}\"" +
                " AND active = 'Yes'";

            return dbh.GetSqlList(sql);
        }
    }
}
