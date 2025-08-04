using Azure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment7
{
    public class DAL 
    {

        public static SqlDataReader GetAllEmployees()
        {
            string query = "SELECT * FROM Employees";
            return DbOperationBase.ExecuteQuery(query);
        }

        public static int InsertEmployee(string name, int age, string department)
        {
            string query = "INSERT INTO Employees (Name, Age, Department) VALUES (@Name, @Age, @Department)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Age", age),
                new SqlParameter("@Department", department)
            };
            return DbOperationBase.ExecuteNonQuery(query, parameters);
        }

        public static int UpdateDepartment(int id , string department)
        {
            string query = "UPDATE Employees SET Department = @department WHERE Id = @employeeId";
            SqlParameter[] parameters = new SqlParameter[]
{
                new SqlParameter("@employeeId", id),
                new SqlParameter("@department", department),
};
            return DbOperationBase.ExecuteNonQuery(query, parameters);
        }

        public static int DeleteEmployee(int id)
        {
            string query = "DELETE FROM Employees WHERE Id = @employeeId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", id)
            };
            return DbOperationBase.ExecuteNonQuery(query, parameters);

        }


    }
}
