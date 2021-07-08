using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.ViewModels
{
    class ReportViewModel
    {
        private Models.DatabaseHandler dbh = new Models.DatabaseHandler();

        public List<Models.Report> getReport(string reportType)
        {
            List<Models.Report> reportRows = new List<Models.Report>();
            TimeZoneInfo central = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            string centralOffset = central.GetUtcOffset(DateTime.UtcNow).ToString().Substring(0, 6);

            string sql = "";

            if (reportType == "meetings_per_month")
            {
                sql = $"SELECT COUNT(meetingId),  DATE_FORMAT(CONVERT_TZ(startDate, '+00:00', \"{centralOffset}\"), '%m/%Y') AS month_year FROM meeting GROUP BY month_year ORDER BY month_year";

            }
            else if (reportType == "appointments_per_user")
            {
                sql = "SELECT CONCAT(employee.firstName, ' ', employee.lastName) AS employeeName, CONCAT(client.firstName, ' ', client.lastName) AS clientName, " +
                    $"DATE_FORMAT(CONVERT_TZ(meeting.startDate, '+00:00', \"{centralOffset}\"), '%m/%d/%Y %h:%i %p') AS startDatetime, " +
                    $"DATE_FORMAT(CONVERT_TZ(meeting.endDate, '+00:00', \"{centralOffset}\"), '%m/%d/%Y %h:%i %p') AS endDatetime " +
                    "FROM meeting " +
                    "LEFT JOIN account employee ON (meeting.employeeAccountId = employee.accountId) " +
                    "LEFT JOIN account client ON (meeting.clientAccountId = client.accountId) " +
                    "WHERE IFNULL(meeting.isDeleted, 'No') != 'Yes' ORDER BY employeeName, startDateTime ";

            }
            else if (reportType == "requests_per_month")
            {
                sql = $"SELECT COUNT(meetingId), DATE_FORMAT(CONVERT_TZ(startDate, '+00:00', \"{centralOffset}\"), '%m/%Y') AS month_year FROM meeting " +
                    $"WHERE IFNULL(isRequest, 'No') = 'Yes' GROUP BY month_year ORDER BY month_year";
            }

            List<Hashtable> results = dbh.GetSqlList(sql);

            foreach (Hashtable result in results)
            {
                if (reportType == "meetings_per_month" || reportType == "requests_per_month")
                {
                    reportRows.Add(new Models.Report { 
                        Column1 = result[0].ToString(),
                        Column2 = result[1].ToString()
                    });

                } else
                {
                    reportRows.Add(new Models.Report
                    {
                        Column1 = result[0].ToString(),
                        Column2 = result[1].ToString(),
                        Column3 = result[2].ToString(),
                        Column4 = result[3].ToString()
                    });
                }
            }

            return reportRows;
        }
    }
}
