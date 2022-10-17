using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Power.Interfaces
{
    public interface IDepositEnergy
    {
        public void DepositEnergy(int kilowatts);
    }
}
