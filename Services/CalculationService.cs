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
    //Implemenet the ICalculationService 
    public class CalculationService : ICalculationService
    {
        private readonly IHolidayRepo _holidayRepository;

        public CalculationService(IHolidayRepo holidayRepository)
        {
            _holidayRepository = holidayRepository; 
        }

        //Count the number of all days

        public int CountAllDays(DayCalculation day)
        {
            var startDay = day.StartingDate;
            var endDay = day.EndDate;
            TimeSpan difference = endDay - startDay;
            int allDays = difference.Days + 1;
            return allDays;
        }


        //Count the all holidays
        public int CountHolidays(DayCalculation day)
        {
            int allPublicHolidays = CountAllDays(day) - CountWorkingDays(day);
            return allPublicHolidays;
        }

        //Count the all working days
        public int CountWorkingDays(DayCalculation dayCalculation)
        {
            var startDay = dayCalculation.StartingDate;
            var endDay = dayCalculation.EndDate;

            var allPublicHolidays = _holidayRepository.GetAllHolidays();

            // find out if there are weekends during the time exceedng the full weeks
            if (startDay > endDay)
                throw new ArgumentException("End day should come after the start day.");

            //check if there is a one day or two days weekend
            TimeSpan difference = endDay - startDay;
            int workingDays = difference.Days + 1;
            int fullWeekCount = workingDays / 7;        //count the number of weeks between given two dates

            if (workingDays > fullWeekCount * 7)
            {
                int firstDayOfWeek = (int)startDay.DayOfWeek;      
                int lastDayOfWeek = (int)endDay.DayOfWeek;           

                if (lastDayOfWeek < firstDayOfWeek)
                {
                    lastDayOfWeek += 7;         
                }
                  
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)  // Saturday and Sunday are also in the remaining time period
                        workingDays -= 2;

                    else if (lastDayOfWeek >= 6)  // Only Saturday is in the remaining time period
                        workingDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Only Sunday is in the remaining time period
                    workingDays -= 1;
            }

            // subtract the weekends during the full weeks in the period
            workingDays -= fullWeekCount + fullWeekCount;

            // check the public holidays and subtract them from working days if so.
            foreach (Holiday publicHoliday in allPublicHolidays)
            {
                DateTime ph = (DateTime)publicHoliday.Holiday1;
                if (startDay <= ph && ph <= endDay && (int)ph.DayOfWeek != 6 && (int)ph.DayOfWeek != 0)
                {
                    workingDays = --workingDays;
                }

            }
            return workingDays;
        }

    }
}