using EmployeeWebApp.Models;
using EmployeeWebApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Repositories
{
    public class HolidayRepo : IHolidayRepo
    {
        private readonly WaterlilyDBContext _context;

        public HolidayRepo(WaterlilyDBContext context)
        {
            _context = context;
        }

        public List<Holiday> GetAllHolidays()
        {
            return _context.Holidays.ToList();
        }

    }
}