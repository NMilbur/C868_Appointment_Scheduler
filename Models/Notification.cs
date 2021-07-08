using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milburn_Appointment_Scheduler.Models
{
    class Notification
    {
        DatabaseHandler dbh = new DatabaseHandler();

        public void checkMeetingReminder()
        {
            string sql = "SELECT CONCAT(employee.firstName, ' ', employee.lastName) AS employeeName, CONCAT(client.firstName, ' ', client.lastName) AS clientName, " +
                $"DATE_FORMAT(CONVERT_TZ(startDate, '+00:00', \"{CurrentUser.Timezone}\"), '%l:%i %p') AS meetingTime FROM meeting " +
                "LEFT JOIN account employee ON (meeting.employeeAccountId = employee.accountId) " +
                "LEFT JOIN account client ON (meeting.clientAccountId = client.accountId) " +
                $"WHERE (meeting.employeeAccountId = {CurrentUser.UserId} OR meeting.clientAccountId = {CurrentUser.UserId}) " +
                "AND meeting.startDate BETWEEN UTC_TIMESTAMP() AND DATE_ADD(UTC_TIMESTAMP(), INTERVAL 15 MINUTE) AND IFNULL(meeting.isDeleted, 'No') != 'Yes' " +
                "AND IFNULL(isApproved, 'No') = 'Yes' LIMIT 1";

            List<Hashtable> results = dbh.GetSqlList(sql);

            string message = "";

            if (results.Count() > 0)
            {
                if (CurrentUser.AccountType == "Client")
                {
                    message = $"You have a meeting with {results[0][0].ToString()} at {results[0][2].ToString()}";

                }
                else
                {
                    message = $"You have a meeting with {results[0][1].ToString()} at {results[0][2].ToString()}";
                }

                MessageBox.Show(message);
            }
        }

        public void checkRequests() 
        {
            string sql = "SELECT COUNT(meetingId) FROM meeting WHERE IFNULL(isRequest, 'No') = 'Yes' AND IFNULL(isApproved, 'No') = 'No' AND IFNULL(isDeleted, 'No') != 'Yes' " +
                "AND startDate > UTC_TIMESTAMP() ";

            if (CurrentUser.AccountType == "Employee")
            {
                sql += $"AND employeeAccountId = {CurrentUser.UserId}";
            }

            string requestCount = dbh.GetSqlValue(sql);

            if (Convert.ToInt32(requestCount) > 0)
            {
                MessageBox.Show("There are meeting requests to view.");
            }
        }
    }
}
