using EmployeeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApp.Services.Interfaces
{
    public interface ICalculationService
    {
        //int CountWorkingDays(DateTime startDay, DateTime endDay);
        int CountWorkingDays(DayCalculation day);
    }
}
