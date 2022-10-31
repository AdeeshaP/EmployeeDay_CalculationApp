using EmployeeWebApp.Models;
using EmployeeWebApp.Repositories;
using EmployeeWebApp.Repositories.Interfaces;
using EmployeeWebApp.Services.Interfaces;
using System.Collections.Generic;
using System;

namespace EmployeeWebApp.Services
{
    //Implement the IEmployeeService 
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository(new WaterlilyDBContext());
        }
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public List<Employee> GetAllEmployees() => _repository.GetEmployeeList();

        public Employee GetEmployeeById(int EmployeeId) => _repository.GetEmployeeById(EmployeeId);

        public void AddEmployee(Employee employee) => _repository.AddEmployee(employee);

        public void DeleteEmployee(int EmployeeId) => _repository.DeleteEmployee(EmployeeId);

        public void UpdateEmployee(Employee employee) => _repository.UpdateEmployee(employee);

        public void Save() => _repository.SaveAll();
    }
}