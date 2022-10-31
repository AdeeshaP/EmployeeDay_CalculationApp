using EmployeeWebApp.Models;
using EmployeeWebApp.Repositories.Interfaces;
using EmployeeWebApp.Repositories;
using EmployeeWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Services
{
    //Implement the IHolidayService
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepo _repository;

        public HolidayService()
        {
            _repository = new HolidayRepo(new WaterlilyDBContext());
        }
        public HolidayService(IHolidayRepo repository)
        {
            _repository = repository;
        }

        public List<Holiday> GetHolidays() => _repository.GetAllHolidays();
    }
}