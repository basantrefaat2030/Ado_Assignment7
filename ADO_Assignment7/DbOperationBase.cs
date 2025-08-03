using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment7
{
    public abstract class DbOperationBase
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdbDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //for retrieving data
        public DataTable ExecuteQuery(string quary , params SqlParameter[] paramters)
        {
            var dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(quary, sqlConnection))
                {
                    if (paramters != null && paramters.Length > 0)
                        command.Parameters.AddRange(paramters);

                    sqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }

                }

                return dataTable;
            }
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
          
        }
    }
}
