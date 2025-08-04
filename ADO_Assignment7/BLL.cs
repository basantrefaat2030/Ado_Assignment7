using ADO_Assignment7.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment7
{
    public class BLL
    {

        public static List<Employees> GetAllEmployees()
        {
            List<Employees> employees = new List<Employees>();

            using (SqlDataReader reader = DAL.GetAllEmployees())
            {
                while (reader.Read())
                {
                    employees.Add(new Employees
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = reader["Age"] is null ? 0 : (int)reader["Age"],
                        Department = reader["Department"].ToString(),
                    });
                }
            } 

            return employees;
        }

        public static int InsertEmployee(Employees employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
            }
            return DAL.InsertEmployee(employee.Name, employee.Age, employee.Department);
        }

        public static int  UpdateDepartment(int id, string DepartmentName)
        {
            if (string.IsNullOrWhiteSpace(DepartmentName))
            {
                throw new ArgumentException("Department name cannot be null or empty", nameof(DepartmentName));
            }
            return DAL.UpdateDepartment(id, DepartmentName);
        }

        public static int DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
            }
            return DAL.DeleteEmployee(id);
        }
    }
}
