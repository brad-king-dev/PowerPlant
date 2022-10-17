using PowerPlant.Core.Manufacturing.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Manufacturing.Models
{
    public class Widget
    {
        public Guid WidgetId { get; private set; }
        public DateTime WidgetCreationDate { get; private set; }
        public Quality Quality { get; private set; }
        public Widget(DateTime timeStamp)
        {
            WidgetCreationDate = timeStamp;
            WidgetId = Guid.NewGuid();
            Quality = Quality.SimulateRandomProductionQuality();
        }
    }
}
