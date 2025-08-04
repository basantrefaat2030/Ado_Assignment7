// See https://aka.ms/new-console-template for more information

using ADO_Assignment7;
using ADO_Assignment7.Models;

#region GetAllEmployees

Console.WriteLine("Hello From Ado.net");
var Employees = BLL.GetAllEmployees();

foreach (var employee in Employees)
{
    Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}, Department: {employee.Department}");
}
#endregion

#region InsertEmployee
// Example of inserting a new employee
var newEmployee = new Employees
{
    Name = "Sofia Mohammed",
    Age = 20,
    Department = "Engineering"
};
var InsertedResult = BLL.InsertEmployee(newEmployee);
if (InsertedResult > 0)
    Console.WriteLine("New employee inserted successfully.");
else
    Console.WriteLine("Failed to insert new employee.");

#endregion

#region UpdateDepartment
// Example of updating an employee's department
int employeeIdToUpdate = 2; // Assuming an employee with ID 1 exists
string UpdateDepartment = "Marketing";
var UpdatedResult = BLL.UpdateDepartment(employeeIdToUpdate, UpdateDepartment);
if (UpdatedResult > 0)
    Console.WriteLine($"Employee with ID {employeeIdToUpdate} updated successfully.");
else
    Console.WriteLine($"Employee with ID {employeeIdToUpdate} updated to department {UpdateDepartment}.");
#endregion

#region DeleteEmployee
// Example of deleting an employee  
int employeeIdToDelete = 3; // Assuming an employee with ID 2 exists        
var DeletedResult = BLL.DeleteEmployee(employeeIdToDelete);
if (DeletedResult > 0)
    Console.WriteLine($"Employee with ID {employeeIdToDelete} deleted successfully.");
else
    Console.WriteLine($"Employee with ID {employeeIdToDelete} deleted successfully.");
#endregion