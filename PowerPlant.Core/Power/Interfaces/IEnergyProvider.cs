using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Power.Interfaces
{
    public interface IEnergyProvider
    {
        public void ProvideEnergy(int kilowatts);
        public int ReportAvailableKilowatts();
        public int GetStorageLimit();
        public bool StorageIsFull();
    }
}
