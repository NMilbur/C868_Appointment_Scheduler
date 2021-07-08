using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Milburn_Appointment_Scheduler.ViewModels
{
    class AccountFormHandler : Models.FormHandler
    {
        Models.DatabaseHandler dbh = new Models.DatabaseHandler();

        public List<Hashtable> getStoredAccountValues(int accountId)
        {
            string sql = "SELECT account.accountId, account.username, account.password, account.firstName, account.lastName, account.phone, account.email, " +
                "account_address.address, account_address.address2, account_address.city, IFNULL(account_address.stateId, -1) AS stateId, account_address.postalCode, account.accountType, account.addressId " +
                "FROM account " +
                "LEFT JOIN account_address ON (account.addressId = account_address.addressId) " +
                $"WHERE account.accountId = {accountId}";

            List<Hashtable> results = dbh.GetSqlList(sql);

            return results;
        }

        public Dictionary<string, string> saveAccountForm(Dictionary<string, string> fieldDict)
        {
            int addressId = -1;
            int accountId = (stringCheck(fieldDict["accountId"])) ? Convert.ToInt32(fieldDict["accountId"]) : -1;
            string dateFormatStr = "yyyy-MM-dd HH:mm:ss";
            string accountType = stringCheck(fieldDict["accountType"]) ? fieldDict["accountType"] : "Client";

            Dictionary<string, string> response = new Dictionary<string, string>();

            // initializing response
            response.Add("status", "SUCCESS");
            response.Add("reason_code", "");
            response.Add("message", "");

            if (!hasRequiredFieldsFilled(fieldDict))
            {
                response["status"] = "FAIL";
                response["reason_code"] = "MISSING_REQUIRED";
                response["message"] = "Please fill out the required fields marked with an asterisk (*).";

                return response;
            }

            if (AccountHandler.checkUserNameExists(fieldDict["username"]))
            {
                response["status"] = "FAIL";
                response["reason_code"] = "USERNAME_TAKEN";
                response["message"] = "This username is taken.";

                return response;
            }

            if (!hasValidEmail(fieldDict["email"]))
            {
                response["status"] = "FAIL";
                response["reason_code"] = "INVALID_EMAIL";
                response["message"] = "The email entered is not formatted properly.";

                return response;
            }

            if (accountId != -1)
            {
                addressId = (stringCheck(fieldDict["addressId"])) ? Int32.Parse(fieldDict["addressId"]) : -1;

                if (hasAddressFieldEntered(fieldDict) && addressId == -1)
                {
                    Dictionary<string, string> insertDict = new Dictionary<string, string>()
                    { 
                        ["address"] = fieldDict["address"],
                        ["address2"] = fieldDict["address2"],
                        ["city"] = fieldDict["city"],
                        ["stateId"] = fieldDict["stateId"],
                        ["postalCode"] = fieldDict["postalCode"],
                        ["createdDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                        ["createdById"] = Models.CurrentUser.UserId.ToString()
                    };

                    addressId = dbh.DictToSQLInsert("account_address", insertDict);
                
                } else if (addressId != -1)
                {
                    Dictionary<string, string> updateDict = new Dictionary<string, string>()
                    {
                        ["address"] = fieldDict["address"],
                        ["address2"] = fieldDict["address2"],
                        ["city"] = fieldDict["city"],
                        ["stateId"] = fieldDict["stateId"],
                        ["postalCode"] = fieldDict["postalCode"],
                        ["updatedDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                        ["updatedById"] = Models.CurrentUser.UserId.ToString()
                    };

                    dbh.DictToSQLUpdate("account_address", updateDict, addressId, "addressId");
                }

                Dictionary<string, string> accountUpdateDict = new Dictionary<string, string>() { 
                    ["username"] = fieldDict["username"],
                    ["password"] = fieldDict["password"],
                    ["firstName"] = fieldDict["firstName"],
                    ["lastName"] = fieldDict["lastName"],
                    ["phone"] = fieldDict["phone"],
                    ["email"] = fieldDict["email"],
                    ["accountType"] = accountType,
                    ["addressId"] = addressId.ToString(),
                    ["updatedDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                    ["updatedById"] = Models.CurrentUser.UserId.ToString()
                };

                dbh.DictToSQLUpdate("account", accountUpdateDict, accountId, "accountId");

                Models.Log.LogEvent($"updated account table for accountId {accountId}");

            } else
            {
                Dictionary<string, string> accountInsertDict = new Dictionary<string, string>()
                {
                    ["username"] = fieldDict["username"],
                    ["password"] = fieldDict["password"],
                    ["firstName"] = fieldDict["firstName"],
                    ["lastName"] = fieldDict["lastName"],
                    ["phone"] = fieldDict["phone"],
                    ["email"] = fieldDict["email"],
                    ["accountType"] = accountType,
                    ["addressId"] = addressId.ToString(),
                    ["createdDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                    ["updatedById"] = Models.CurrentUser.UserId.ToString(),
                    ["active"] = "Yes"
                };

                accountId = dbh.DictToSQLInsert("account", accountInsertDict);

                if (hasAddressFieldEntered(fieldDict))
                {
                    Dictionary<string, string> insertDict = new Dictionary<string, string>()
                    {
                        ["address"] = fieldDict["address"],
                        ["address2"] = fieldDict["address2"],
                        ["city"] = fieldDict["city"],
                        ["stateId"] = fieldDict["stateId"],
                        ["postalCode"] = fieldDict["postalCode"],
                        ["createdDate"] = DateTime.UtcNow.ToString(dateFormatStr),
                        ["createdById"] = Models.CurrentUser.UserId.ToString()
                    };

                    addressId = dbh.DictToSQLInsert("account_address", insertDict);

                    Dictionary<string, string> updateAccountDict = new Dictionary<string, string>() { 
                        ["addressId"] = addressId.ToString(),
                        ["createdById"] = accountId.ToString(),
                    };

                    dbh.DictToSQLUpdate("account", updateAccountDict, accountId, "accountId");
                }

                Models.Log.LogEvent($"created account table for accountId {accountId}");
            }
            
            return response;
        }

        private bool hasAddressFieldEntered(Dictionary<string, string> fieldDict)
        {
            return stringCheck(fieldDict["addressId"]) || stringCheck(fieldDict["address"]) || stringCheck(fieldDict["address2"]) || 
                stringCheck(fieldDict["city"]) || stringCheck(fieldDict["stateId"]) || stringCheck(fieldDict["postalCode"]);
        }

        private bool hasRequiredFieldsFilled(Dictionary<string, string> fieldDict)
        {
            return stringCheck(fieldDict["username"]) && stringCheck(fieldDict["password"]) &&  stringCheck(fieldDict["firstName"]) &&
                stringCheck(fieldDict["lastName"]) && stringCheck(fieldDict["phone"]) && stringCheck(fieldDict["email"]);
        }

        public List<Models.DropDown> getStateDropdownOpts()
        {
            List<Models.DropDown> states = new List<Models.DropDown>();

            List<Hashtable> results = dbh.GetSqlList("SELECT stateName, stateId FROM state ORDER BY stateName");

            states.Add(new Models.DropDown("Select...", -1));

            foreach (Hashtable result in results)
            {
                states.Add(new Models.DropDown(result[0].ToString(), (int)result[1]));
            }

            return states;
        }

        public List<Models.DropDown> getAccountTypeDropdownOpts()
        {
            List<Models.DropDown> accountTypes = new List<Models.DropDown>();

            accountTypes.Add(new Models.DropDown("Select...", ""));
            accountTypes.Add(new Models.DropDown("Admin", "Admin"));
            accountTypes.Add(new Models.DropDown("Client", "Client"));
            accountTypes.Add(new Models.DropDown("Employee", "Employee"));

            return accountTypes;
        }
    }
}
