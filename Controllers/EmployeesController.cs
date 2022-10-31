using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeWebApp.Models;
using EmployeeWebApp.Repositories;
using EmployeeWebApp.Services;
using EmployeeWebApp.Services.Interfaces;

namespace EmployeeWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;

        //parameterless construnctor - 
        public EmployeesController()
        {
            _service = new EmployeeService(new EmployeeRepository(new WaterlilyDBContext()));  
        }

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        // Render the View Page for Employee List
        // GET: Employees
        [OutputCache(Duration = 300)] 
        public ActionResult Index()
        {
            var employees = _service.GetAllEmployees();
            return View(employees);
        }

        // Render the View Page for Add Employee
        [HttpGet]
        [OutputCache(Duration = 300)]
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST Action Method for Add Employee
        //Add Employee view submits data to this method. It receives the data as an Employee instance and then inserts an Employee using the service.
        [HttpPost]
        [OutputCache(Duration = 300, VaryByParam = "model")]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _service.AddEmployee(model);
                _service.Save();
                return RedirectToAction("Index", "Employees");      // return to the Employee List 
            }
            return View();
        }

        // Render the View Page for Update Employee
        [HttpGet]
        [OutputCache(Duration = 300, VaryByParam = "EmployeeId")]
        public ActionResult EditEmployee(int EmployeeId)
        {
            Employee model = _service.GetEmployeeById(EmployeeId);
            return View(model);
        }

        // POST Action Method for Update Employee
        //Edit Employee view submits the data to this method. It receives the data as an Employee instance and then updates the Employee using the service.
        [HttpPost]
        [OutputCache(Duration = 300, VaryByParam = "model")]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateEmployee(model);
                _service.Save();
                return RedirectToAction("Index", "Employees");      // return to the Employee List 
            }
            else
            {
                return View(model);
            }
        }

        // Render the View Page for Delete Employee
        [HttpGet]
        [OutputCache(Duration = 300, VaryByParam = "EmployeeId")]
        public ActionResult DeleteEmployee(int EmployeeId)
        {
            Employee model = _service.GetEmployeeById(EmployeeId);
            return View(model);
        }

        // POST Action Method for Delete Confirmation of Employee
        //Delete Employee view submits the data to this action method. The action then deletes the Employee using the service.
        [HttpPost]
        [OutputCache(Duration = 300, VaryByParam = "model")]
        public ActionResult DeleteConfirmed(Employee model)
        {
            try
            {
                _service.DeleteEmployee(model.EmpId);
                _service.Save();
            }
            catch (DataException)
            {
                return View();
            }

            return RedirectToAction("Index", "Employees");       // return to the Employee List 
        }

     }
}
