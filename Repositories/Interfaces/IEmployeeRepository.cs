using EmployeeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeList();      // return all the Employee entities as an collection (list)
        Employee GetEmployeeById(int EmployeeId);          // produces a single Employee entity that matches the given                                                      Employee ID after accepting an integer parameter representing the Employee ID
                                                           
        void AddEmployee(Employee employee);    //accepts an Employee object as the parameter and adds that Employee object to DB.
        void UpdateEmployee(Employee employee);   //accepts an Employee object as a parameter and marks that Employee object as a modified Employee in the DbSet.

        void DeleteEmployee(int EmployeeId);   //removes the specified Employee object from the Employees DbSet by accepting an EmployeeId as a parameter.
        
        void SaveAll();     //saves changes to the database.
    }
}
