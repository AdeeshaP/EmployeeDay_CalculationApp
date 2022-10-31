using EmployeeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApp.Repositories.Interfaces
{
    public interface IHolidayRepo
    {
        List<Holiday> GetAllHolidays();
    }
}
