using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Power.Interfaces
{
    public enum PollutionRate { Low, Medium, High }
    public interface IPowerPlant
    {
        public PollutionRate GetPollutionRate();
        public void GenerateKilowattsForHour();
    }
}
