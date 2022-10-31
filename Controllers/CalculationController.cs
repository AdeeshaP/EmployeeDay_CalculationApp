using EmployeeWebApp.Models;
using EmployeeWebApp.Repositories;
using EmployeeWebApp.Services;
using EmployeeWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace EmployeeWebApp.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calService;


        public CalculationController()
        {
            _calService = new CalculationService(new HolidayRepo(new WaterlilyDBContext()));
        }
        public CalculationController(ICalculationService calService)
        {
            _calService = calService;   
        }

        [HttpGet]
        public ActionResult CountWorkingDays()
        {
            DayCalculation dc = new DayCalculation();   
            return View(dc);
        }


        [HttpPost]
        public ActionResult CountWorkingDays(DayCalculation dc)
        {
            int val =  _calService.CountWorkingDays(dc);
            TempData["Data"] = val;
            return View(dc);
        }


    }
}