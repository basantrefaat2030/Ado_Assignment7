using ADO_Assignment7.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment7
{
    public class DbOperationBase 
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdbDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //for retrieving data
        public static SqlDataReader ExecuteQuery(string query, params SqlParameter[] paramters)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = null;
            //SqlDataReader reader = null;
            try
            {
                command = new SqlCommand(query, sqlConnection);
                if (paramters != null && paramters.Length > 0)
                    command.Parameters.AddRange(paramters);

                sqlConnection.Open();

                return command.ExecuteReader();

            }

            catch
            {
                // Cleanup if error occurs before returning reader
                command?.Dispose();
                sqlConnection?.Dispose();
                throw;
            }
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null && parameters.Length > 0)
                            command.Parameters.AddRange(parameters);


                        sqlConnection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing the non-query: {ex.Message}");
                return -1; // Indicating failure
            }
        }
    }
}
