using PowerPlant.Core.Manufacturing.Interfaces;
using PowerPlant.Core.Manufacturing.Models;
using PowerPlant.Core.Power.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.TimeSimulation
{
    public class DaySimulator
    {
        private readonly IPowerPlant _powerPlant;
        private readonly IManufacturingPlant _manufacturingPlant;

        public DaySimulator(IPowerPlant powerPlant, IManufacturingPlant manufacturingPlant)
        {
            this._powerPlant = powerPlant;
            this._manufacturingPlant = manufacturingPlant;
        }


        /// <summary>
        /// Simulates the generation of power & manufacturing for X amount of days
        /// </summary>
        /// <param name="forDays">The amount of days (from today) you'd like to run the simulation for.</param>
        /// <param name="manufacturingDaysOff">The days of the week the manufacturing plant should not operate</param>
        /// <param name="powerDaysOff">The days of the week the power plant should not operate</param>
        /// <returns></returns>
        public IEnumerable<Widget> SimulateProductionForDays(int forDays, 
            IEnumerable<DayOfWeek> manufacturingDaysOff, IEnumerable<DayOfWeek> powerDaysOff)
        {
            DateTime startOfToday = GetTodaysDateAtMidnight();

            //LINQ Statement where we do a loop for 0 through forDays
            //The AddDays method returns a new date time a date for X many days in future
            //So output is a list of date time objects each representing a consecutive day.
            var daysToSimulate = Enumerable.Range(0, forDays)
                .Select(d => startOfToday.AddDays(d));

            var createdWidgets = new List<Widget>();
            foreach (var day in daysToSimulate)
            {
                foreach (var hour in Enumerable.Range(0, 24))
                {
                    //if today is a day off for power plant staff, don't run power plant.
                    if (!powerDaysOff?.Contains(day.DayOfWeek) ?? false)
                    {
                        _powerPlant.GenerateKilowattsForHour();
                    }

                    //if today is a day off for manufacturing plant, don't run manufacturing plant
                    if (!manufacturingDaysOff?.Contains(day.DayOfWeek) ?? false)
                    {
                        //Our ConstructWidgetsForHour method requires a timestamp that is saved on each widget.
                        //Similar to AddDays method above, AddHours returns a new Date X hours in the future.
                        var simulatedTimeStamp = day.AddHours(hour);
                        var generatedWidgets = _manufacturingPlant.ConstructWidgetsForHour(simulatedTimeStamp);

                        createdWidgets.AddRange(generatedWidgets);
                    }
                }
            }

            return createdWidgets;
        }

        private static DateTime GetTodaysDateAtMidnight()
        {
            //DateTime.Now returns the exact time in current timezone down to current milisecond
            var dateTimeNow = DateTime.Now;

            //For purpose of simulation, we are assuming the start of each day is at midnight.
            //So we pass in the Day, Month and Year of current date and let it default to midnight.
            var startOfToday = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);
            return startOfToday;
        }
    }
}
