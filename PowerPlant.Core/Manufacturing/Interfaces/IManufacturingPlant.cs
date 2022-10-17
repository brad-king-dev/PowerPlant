using PowerPlant.Core.Manufacturing.Models;

namespace PowerPlant.Core.Manufacturing.Interfaces
{
    public interface IManufacturingPlant
    {
        IEnumerable<Widget> ConstructWidgetsForHour(DateTime timeStamp);
        bool PowerIsAvilableToConstructWidget();
    }
}
