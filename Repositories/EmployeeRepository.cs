using EmployeeWebApp.Models;
using EmployeeWebApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;

namespace EmployeeWebApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WaterlilyDBContext _context;

        public EmployeeRepository(WaterlilyDBContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployeeList()
        {
            //This is where we call the database/datastore for retreiving all employees
            return _context.Employees.ToList();
        }

        
        public Employee GetEmployeeById(int EmployeeId)
        {
            //This is where we call the database/datastore for getting any employee by id from DB
            return _context.Employees.Find(EmployeeId);     
        }

        
        public void AddEmployee(Employee employee)
        {
            //This is where we call the database/datastore for adding employee to the DB
            _context.Employees.Add(employee);
        }

        
        public void UpdateEmployee(Employee employee)
        {
            //This is where we call the database/datastore for updating employee in the DB
            _context.Entry(employee).State = EntityState.Modified;
        }

       
        public void DeleteEmployee(int EmployeeId)
        {
            //This is where we call the database/datastore for deleting employee from the DB
            Employee employee = _context.Employees.Find(EmployeeId);    //Find the employee whose ID matches with given Id
            _context.Employees.Remove(employee);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
}