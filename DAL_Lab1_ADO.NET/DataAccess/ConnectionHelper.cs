using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL_Lab1_ADO.NET.DataAccess
{
    public static class ConnectionHelper
    {
        private static string _machineName = Environment.MachineName;
        private static string GetConnectionString()
        {
            // Allow me to use my home server for the database connection and let my colleagues use their local database
            if (_machineName == "ALEXANDRE")
            {
                return ConfigurationManager.ConnectionStrings["SchoolDbConnection"].ConnectionString;
            }
            else
            {
                return ConfigurationManager.ConnectionStrings["SchoolDbConnection_HomeServer"].ConnectionString;
            }
        }

        public static bool TestConnection()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}
