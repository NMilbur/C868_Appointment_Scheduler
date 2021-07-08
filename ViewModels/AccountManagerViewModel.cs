using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.ViewModels
{
    class AccountManagerViewModel
    {
        private Models.DatabaseHandler dbh = new Models.DatabaseHandler();

        public List<Models.User> getDataSource(string typeFilter, string inactiveFilter, string nameSearch)
        {
            List<Models.User> accountList = new List<Models.User>();

            string sql = "SELECT CONCAT(firstName, ' ', lastName) AS accountName, phone, email, accountType, active, accountId FROM account WHERE 1 = 1 ";

            if (Models.CurrentUser.AccountType == "Employee")
            {
                sql += "AND accountType = 'Client' ";
            }

            if (!String.IsNullOrWhiteSpace(typeFilter) && typeFilter != "All")
            {
                sql += $"AND accountType = \"{typeFilter}\" ";
            }

            if (inactiveFilter == "No")
            {
                sql += "AND active = 'Yes' ";
            }

            if (!String.IsNullOrWhiteSpace(nameSearch))
            {
                sql += $"AND LOWER(CONCAT(firstName,lastName)) LIKE '%{nameSearch.ToLower()}%' ";
            }

            sql += "ORDER BY accountName";

            List<Hashtable> results = dbh.GetSqlList(sql);

            foreach (Hashtable result in results)
            {
                accountList.Add(new Models.User { 
                    Name = result[0].ToString(),
                    Phone = result[1].ToString(),
                    Email = result[2].ToString(),
                    AccountType = result[3].ToString(),
                    Active = result[4].ToString(),
                    AccountId = Convert.ToInt32(result[5])
                });
            }

            return accountList;
        }

        public void updateAccountActivity(int accountId, string isActive)
        {
            string action = (isActive == "Yes") ? "activated" : "deactivated";

            Models.Log.LogEvent($"{action} accountId {accountId}");

            dbh.DictToSQLUpdate("account",
                new Dictionary<string, string>()
                {
                    ["active"] = isActive,
                    ["updatedDate"] = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    ["updatedById"] = Models.CurrentUser.UserId.ToString()
                }, 
                accountId, "accountId"
            );
        }
    }
}
