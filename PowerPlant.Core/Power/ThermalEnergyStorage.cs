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
    /// This stores energy...thermally. (i guess)
    /// </summary>
    public class ThermalEnergyStorage : IEnergyStore
    {
        private int _storedEnergy = 0;
        private const int MAX_KWH_STORAGE = 10000;
        /// <summary>
        /// Consumes amount of kilowatts requested
        /// </summary>
        /// <param name="kilowatts">Amount of kilowatts to use</param>
        /// <exception cref="OutOfPowerException">
        /// Throws OutOfPowerException if no power remaining
        /// </exception>
        public void ProvideEnergy(int kilowatts)
        {
            if((_storedEnergy - kilowatts) <= 0)
            {
                _storedEnergy = 0;
                throw new OutOfPowerException("Energy has been depleted from store. " +
                    "Meltdown imminent.");
            }
            _storedEnergy = _storedEnergy - kilowatts;
        }
        /// <summary>
        /// Deposits amount of given kilowatts. 
        /// Amount of storage cannot exceed max storage capacity.
        /// </summary>
        /// <param name="kilowatts"></param>
        public void DepositEnergy(int kilowatts)
        {
            if ((_storedEnergy + kilowatts) > MAX_KWH_STORAGE)
                _storedEnergy = MAX_KWH_STORAGE;
            else
                _storedEnergy += kilowatts;
        }

        /// <summary>
        /// Returns maximum amount kilowatts that can be stored
        /// </summary>
        /// <returns></returns>
        public int GetStorageLimit()
        {
            return MAX_KWH_STORAGE;
        }

        /// <summary>
        /// Returns current amount of Kilowatts in storage
        /// </summary>
        /// <returns></returns>
        public int ReportAvailableKilowatts()
        {
            return _storedEnergy;
        }

        /// <summary>
        /// Returns true if amount of storage is equal to maximum capacity.
        /// </summary>
        /// <returns></returns>
        public bool StorageIsFull()
        {
            return _storedEnergy == MAX_KWH_STORAGE;
        }
    }
}
