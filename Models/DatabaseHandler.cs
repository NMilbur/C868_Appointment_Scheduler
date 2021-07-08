using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milburn_Appointment_Scheduler.Models
{
    class DatabaseHandler
    {
        private string connectionString = @"server=wgudb.ucertify.com;userid=U08N7j;password=53689336285;database=U08N7j";

        public DatabaseHandler() { }

        // Gets value from passed in query from first column, so should only pass in 1 column. Also Limits the results to 1 row.
        public string GetSqlValue(string sql)
        {
            string returnVal = "";

            if (!sql.Contains("LIMIT 1"))
            {
                sql += " LIMIT 1";
            }

            Console.WriteLine(sql);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    returnVal = reader[0].ToString();
                }
            }

            reader.Close();
            connection.Close();

            return returnVal;
        }

        // Returns a list of hashtables to allow for larger datasets, requires the sql to be passed in
        public List<Hashtable> GetSqlList(string sql)
        {
            List<Hashtable> returnList = new List<Hashtable>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Hashtable resultHash = new Hashtable();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        resultHash.Add(i, reader[i]);
                    }

                    returnList.Add(resultHash);
                }
            }

            reader.Close();
            connection.Close();

            return returnList;
        }

        public int InsertRecordGetID(string sql) {
            UpdateInsertRecord(sql);
            return Int32.Parse(GetSqlValue("SELECT LAST_INSERT_ID()"));
        }

        public void UpdateInsertRecord(string sql)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);
            
            command.ExecuteNonQuery();
            connection.Close();
        }

        // This takes in 4 parameters: Table Name, a Dictionary with the field names as the Keys and values as the Values,
        // the id of the row being updated, and the field name for the id
        public void DictToSQLUpdate(string tableName, Dictionary<string, string> fieldDict, int tableId, string tableIdField)
        {
            string sql = $"UPDATE {tableName} SET ";

            List<string> updateFields = new List<string>();

            foreach (KeyValuePair<string, string> entry in fieldDict)
            {
                updateFields.Add($"{entry.Key} = \"{entry.Value}\"");
            }

            sql += $"{String.Join(", ", updateFields)} WHERE {tableIdField} = {tableId}";

            UpdateInsertRecord(sql);
        }

        // always returns an ID, takes 2 parameters: Table Name, a Dictionary with the field names as the Keys and values as the Values
        public int DictToSQLInsert(string tableName, Dictionary<string, string> fieldDict)
        {
            string sql = $"INSERT INTO {tableName} ";
            List<string> fieldsList = new List<string>();
            List<string> valuesList = new List<string>();

            foreach (KeyValuePair<string, string> entry in fieldDict)
            {
                fieldsList.Add(entry.Key);
                valuesList.Add($"\"{entry.Value}\"");
            }

            sql += $"({String.Join(", ", fieldsList)}) VALUES ({String.Join(", ", valuesList)})";

            return InsertRecordGetID(sql);
        }
    }
}
