using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.ViewModels
{
    class AppointmentFormHandler : Models.FormHandler
    {
        Models.DatabaseHandler dbh = new Models.DatabaseHandler();

        public List<Models.DropDown> getAccountDropdownOpts(string accountType) {
            List<Models.DropDown> accounts = new List<Models.DropDown>();

            List<Hashtable> results = dbh.GetSqlList($"SELECT CONCAT(firstName, ' ', lastName) AS name, accountId FROM account WHERE accountType = \"{accountType}\"" +
                " AND active = 'Yes'");

            accounts.Add(new Models.DropDown("Select...", -1));

            foreach (Hashtable result in results)
            {
                accounts.Add(new Models.DropDown(result[0].ToString(), Convert.ToInt32(result[1])));
            }

            return accounts;
        }

        public List<Hashtable> getMeetingInfo(int meetingId)
        {
            string sql = $"SELECT meetingId, employeeAccountId, clientAccountId, meetingType, DATE(CONVERT_TZ(startDate, '+00:00', \"{Models.CurrentUser.Timezone}\")) AS meetingDate, " +
                $"TIME(CONVERT_TZ(startDate, '+00:00', \"{Models.CurrentUser.Timezone}\")) AS startTime, TIME(CONVERT_TZ(endDate, '+00:00', \"{Models.CurrentUser.Timezone}\")) AS endTime, " +
                $"isApproved, isRequest FROM meeting WHERE meetingId = {meetingId}";

            return dbh.GetSqlList(sql);
        }

        public Dictionary<string, string> saveAppointmentForm(Dictionary<string, string> fieldDict)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            TimeZone timeZone = TimeZone.CurrentTimeZone;
            TimeZoneInfo central = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
           
            string dateFormatStr = "yyyy-MM-dd HH:mm:ss";

            // initializing response
            response.Add("status", "SUCCESS");
            response.Add("reason_code", "");
            response.Add("message", "");

            string employeeAccountId;
            string clientAccountId;
            int meetingId = (stringCheck(fieldDict["meetingId"])) ? Convert.ToInt32(fieldDict["meetingId"]) : -1;

            string startDate = $"{fieldDict["meetingDate"]} {fieldDict["startTime"]}";
            string endDate = $"{fieldDict["meetingDate"]} {fieldDict["endTime"]}";
            string businessStart = $"{fieldDict["meetingDate"]} 08:00:00";
            string businessEnd = $"{fieldDict["meetingDate"]} 18:00:00";

            string centralOffset = central.GetUtcOffset(DateTime.Parse(businessStart)).ToString().Substring(0, 6);

            if (Models.CurrentUser.AccountType == "Admin")
            {
                employeeAccountId = fieldDict["employeeAccountId"];
                clientAccountId = fieldDict["userAccountId"];

            }
            else if (Models.CurrentUser.AccountType == "Employee")
            {
                employeeAccountId = Models.CurrentUser.UserId.ToString();
                clientAccountId = fieldDict["userAccountId"];
            }
            else
            {
                employeeAccountId = fieldDict["userAccountId"];
                clientAccountId = Models.CurrentUser.UserId.ToString();
            }

            if (!validateTimes(DateTime.Parse(startDate), DateTime.Parse(endDate)))
            {
                response["status"] = "FAIL";
                response["reason_code"] = "INVALID_TIMES";
                response["message"] = "Start time must be before the end time";

                return response;
            } 

            if (!timesInBusinessHours(startDate, endDate, businessStart, businessEnd, centralOffset))
            {
                response["status"] = "FAIL";
                response["reason_code"] = "NOT_IN_RANGE";
                response["message"] = "Please be sure to enter times between 8 AM and 6 PM Central time.";

                return response;
            }

            if (!timesNotOverlapping(startDate, endDate, Convert.ToInt32(employeeAccountId), Convert.ToInt32(clientAccountId), centralOffset, meetingId))
            {
                response["status"] = "FAIL";
                response["reason_code"] = "TIME_TAKEN";
                response["message"] = "The appointment time specified has been taken. Please try a different time.";

                return response;
            }

            if (!(stringCheck(employeeAccountId) && stringCheck(clientAccountId) && stringCheck(fieldDict["meetingType"]) && stringCheck(fieldDict["meetingDate"]) &&
                stringCheck(fieldDict["startTime"]) && stringCheck(fieldDict["endTime"]))) {

                response["status"] = "FAIL";
                response["reason_code"] = "REQUIRED_MISSING";
                response["message"] = "Please fill out all fields.";

                return response;
            }

            if (meetingId != -1)
            {
                dbh.DictToSQLUpdate("meeting",
                    new Dictionary<string, string>()
                    {
                        ["employeeAccountId"] = employeeAccountId,
                        ["clientAccountId"] = clientAccountId,
                        ["meetingType"] = fieldDict["meetingType"],
                        ["startDate"] = $"{timeZone.ToUniversalTime(DateTime.Parse(startDate)).ToString(dateFormatStr)}",
                        ["endDate"] = $"{timeZone.ToUniversalTime(DateTime.Parse(endDate)).ToString(dateFormatStr)}",
                        ["isApproved"] = fieldDict["approved"],
                        ["updatedDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                        ["updatedById"] = Models.CurrentUser.UserId.ToString()
                    },
                    Convert.ToInt32(fieldDict["meetingId"]), "meetingId"
                );

                Models.Log.LogEvent($"edited meeting with meetingId {meetingId}");

            } else
            {
                string isApproved = (Models.CurrentUser.AccountType != "Client") ? "Yes" : "No";
                string isRequest = (isApproved == "No") ? "Yes" : "No";

                meetingId = dbh.DictToSQLInsert("meeting",
                    new Dictionary<string, string>()
                    {
                        ["employeeAccountId"] = employeeAccountId,
                        ["clientAccountId"] = clientAccountId,
                        ["meetingType"] = fieldDict["meetingType"],
                        ["startDate"] = $"{timeZone.ToUniversalTime(DateTime.Parse(startDate)).ToString(dateFormatStr)}",
                        ["endDate"] = $"{timeZone.ToUniversalTime(DateTime.Parse(endDate)).ToString(dateFormatStr)}",
                        ["isApproved"] = isApproved,
                        ["isRequest"] = isRequest,
                        ["createdDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                        ["createdById"] = Models.CurrentUser.UserId.ToString()
                    }
                );

                Models.Log.LogEvent($"created a meeting with meetingId {meetingId}");
            }

            return response;
        }

        private bool validateTimes(DateTime start, DateTime end)
        {
            return start < end;
        }

        private bool timesInBusinessHours(string start, string end, string businessStart, string businessEnd, string centralOffset)
        {
            string sql = "SELECT CASE " +
                $"WHEN CONVERT_TZ(\"{start}\", \"{centralOffset}\", \"{centralOffset}\") < CONVERT_TZ(\"{businessStart}\", \"{centralOffset}\", \"{centralOffset}\") " +
                "THEN 'No' " +
                $"WHEN CONVERT_TZ(\"{start}\", \"{centralOffset}\", \"{centralOffset}\") >= CONVERT_TZ(\"{businessEnd}\", \"{centralOffset}\", \"{centralOffset}\") " +
                "THEN 'No' " +
                $"WHEN CONVERT_TZ(\"{end}\", \"{centralOffset}\", \"{centralOffset}\") < CONVERT_TZ(\"{businessStart}\", \"{centralOffset}\", \"{centralOffset}\") " +
                "THEN 'No' " +
                "ELSE 'Yes' END AS valid FROM dual";

            return (dbh.GetSqlValue(sql) == "Yes");
        }

        private bool timesNotOverlapping(string start, string end, int employeeAccountId, int clientAccountId, string centralOffset, int meetingId)
        {
            string sql = "SELECT IFNULL(meetingId, -1) FROM meeting " +
                $"WHERE ((CONVERT_TZ(startDate, '+00:00', \"{centralOffset}\") >= CONVERT_TZ(\"{start}\", \"{centralOffset}\", \"{centralOffset}\") " +
                $"AND CONVERT_TZ(startDate, '+00:00', \"{centralOffset}\") < CONVERT_TZ(\"{end}\", \"{centralOffset}\", \"{centralOffset}\")) " +
                $"OR (CONVERT_TZ(endDate, '+00:00', \"{centralOffset}\") > CONVERT_TZ(\"{start}\", \"{centralOffset}\", \"{centralOffset}\") " +
                $"AND CONVERT_TZ(endDate, '+00:00', \"{centralOffset}\") <= CONVERT_TZ(\"{end}\", \"{centralOffset}\", \"{centralOffset}\")) " +
                $"OR (CONVERT_TZ(startDate, '+00:00', \"{centralOffset}\") <= CONVERT_TZ(\"{start}\", \"{centralOffset}\", \"{centralOffset}\") " +
                $"AND CONVERT_TZ(endDate, '+00:00', \"{centralOffset}\") >= CONVERT_TZ(\"{end}\", \"{centralOffset}\", \"{centralOffset}\"))) " +
                $"AND (employeeAccountId = {employeeAccountId} OR clientAccountId = {clientAccountId}) ";
                
            if (meetingId != -1)
            {
                sql += $"AND meetingId != {meetingId}";
            }

            string result = dbh.GetSqlValue(sql);
            
            return (String.IsNullOrWhiteSpace(result)) ? true : false;
        }
    }
}
