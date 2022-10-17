using PowerPlant.Core.Manufacturing.Interfaces;
using PowerPlant.Core.Manufacturing.Models;
using PowerPlant.Core.Power.Exceptions;
using PowerPlant.Core.Power.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Models
{
    /// <summary>
    /// A next generation manufacturing plant that creates widgets from energy
    /// </summary>
    public class WidgetManufacturingPlant : IManufacturingPlant
    {
        private IEnergyProvider _energyProvider;
        private const int KWH_NEEDED_PER_WIDGET = 75;
        private const int WIDGET_PER_HOUR_RATE = 2;

        public WidgetManufacturingPlant(IEnergyProvider energyProvider)
        {
            _energyProvider = energyProvider;
        }

        /// <summary>
        /// Generates Widgets at rate of 2 per hour, requiring 75 KWH per widget.
        /// If there is not enough power supply to create a widget, no widget is created 
        /// </summary>
        /// <param name="timeStamp">The time when widgets should be created (and stamped)</param>
        /// <returns></returns>
        public IEnumerable<Widget> ConstructWidgetsForHour(DateTime timeStamp)
        {
            var createdWidgets = new List<Widget>();
            for(int i = 0; i < WIDGET_PER_HOUR_RATE; i++) 
            { 
                if (PowerIsAvilableToConstructWidget())
                {
                    _energyProvider.ProvideEnergy(KWH_NEEDED_PER_WIDGET);
                    createdWidgets.Add(new Widget(timeStamp));
                }
            }
            return createdWidgets;
        }

        /// <summary>
        /// Returns true if there is enough power to construct a single widget
        /// </summary>
        /// <returns></returns>
        public bool PowerIsAvilableToConstructWidget()
        {
            return _energyProvider.ReportAvailableKilowatts() > KWH_NEEDED_PER_WIDGET;
        }


    }
}
