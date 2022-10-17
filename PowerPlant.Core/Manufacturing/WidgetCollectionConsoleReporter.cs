using PowerPlant.Core.Manufacturing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Manufacturing
{
    public class WidgetCollectionConsoleReporter
    {
        private readonly IEnumerable<Widget> _widgets;
        public WidgetCollectionConsoleReporter(IEnumerable<Widget> widgets)
        {
            this._widgets = widgets;
        }

        public void WriteTotal()
        {
            Console.WriteLine($"Total Created Widgets: {_widgets.Count()}");
        }

        public void WriteQualitySummary()
        {
            var qualitySummary = _widgets.GroupBy(x => x.Quality)
            .Select(x => new
            {
                Quality = x.Key,
                PercentageOfTotal = Math.Round(((double)x.Count() * 100) / _widgets.Count(), 2),
                Total = x.Count()
            });

            Console.WriteLine("Quality Report:");
            foreach (var summaryLine in qualitySummary)
            {
                Console.WriteLine($"{summaryLine.Quality} - {summaryLine.Total} ({summaryLine.PercentageOfTotal}%)");
            }
        }
    }
}
