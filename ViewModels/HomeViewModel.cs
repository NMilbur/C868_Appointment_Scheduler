using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.ViewModels
{
    class HomeViewModel
    {
        private Models.DatabaseHandler dbh = new Models.DatabaseHandler();

        public List<Models.Meeting> getDataSource(string dateFilter, string pastFilter)
        {
            List<Models.Meeting> meetings = new List<Models.Meeting>();

            string sql = "SELECT meeting.meetingId, CONCAT(employee.firstName, ' ', employee.lastName) AS employeeName, CONCAT(client.firstName, ' ', client.lastName) AS clientName, " +
                $"DATE_FORMAT(CONVERT_TZ(meeting.startDate, '+00:00', \"{Models.CurrentUser.Timezone}\"), '%m/%d/%Y %h:%i %p') AS startDatetime, " +
                $"DATE_FORMAT(CONVERT_TZ(meeting.endDate, '+00:00', \"{Models.CurrentUser.Timezone}\"), '%m/%d/%Y %h:%i %p') AS endDatetime, " +
                "meeting.isApproved, meeting.meetingType FROM meeting " +
                "LEFT JOIN account employee ON (meeting.employeeAccountId = employee.accountId) " +
                "LEFT JOIN account client ON (meeting.clientAccountId = client.accountId) " +
                "WHERE IFNULL(meeting.isDeleted, 'No') != 'Yes' AND IFNULL(client.active, 'Yes') = 'Yes' AND IFNULL(employee.active, 'Yes') = 'Yes' ";

            if (dateFilter == "Month")
            {
                sql += "AND MONTH(startDate) = MONTH(NOW()) ";
            
            } else if (dateFilter == "Week")
            {
                sql += "AND WEEK(startDate) = WEEK(NOW()) ";
            }

            if (pastFilter != "Yes")
            {
                sql += $"AND CONVERT_TZ(meeting.endDate, '+00:00', \"{Models.CurrentUser.Timezone}\") >= CONVERT_TZ(NOW(), '+00:00', \"{Models.CurrentUser.Timezone}\") ";
            }

            if (Models.CurrentUser.AccountType == "Employee")
            {
                sql += $"AND meeting.employeeAccountId = {Models.CurrentUser.UserId} ";
            
            } else if (Models.CurrentUser.AccountType == "Client")
            {
                sql += $"AND meeting.clientAccountId = {Models.CurrentUser.UserId} ";
            }

            sql += "ORDER BY meeting.startDate";

            List<Hashtable> results = dbh.GetSqlList(sql);

            foreach (Hashtable result in results)
            {
                meetings.Add(new Models.Meeting
                {
                    MeetingId = Convert.ToInt32(result[0]),
                    EmployeeName = result[1].ToString(),
                    ClientName = result[2].ToString(),
                    Start = result[3].ToString(),
                    End = result[4].ToString(),
                    Approved = result[5].ToString(),
                    Type = result[6].ToString()
                });
            }

            return meetings;
        }

        public void removeMeeting(int meetingId)
        {
            dbh.DictToSQLUpdate("meeting",
                new Dictionary<string, string>() {
                    ["isDeleted"] = "Yes",
                    ["updatedDate"] = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    ["updatedById"] = Models.CurrentUser.UserId.ToString()
                },
                meetingId, "meetingId"
            );

            Models.Log.LogEvent($"removed meeting with meetingId {meetingId}");
        }
    }
}
