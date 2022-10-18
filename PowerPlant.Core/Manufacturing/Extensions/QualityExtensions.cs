using PowerPlant.Core.Manufacturing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Manufacturing.Extensions
{
    public static class QualityExtensions
    {
        
        private static Random _random = new Random();

        /// <summary>
        /// Generates a pseudo random quality with bias towards fair, good and perfect qualities.
        /// </summary>
        /// <param name="quality"></param>
        /// <returns></returns>
        public static Quality SimulateRandomProductionQuality(this Quality quality)
        {
            var randomItemToSelect = _random.Next(1, 100);

            //Aproximately a 2% chance of terrible quality.
            if (randomItemToSelect <= 2)
                return Quality.Terrible;

            //Approximately 3% chance of bad quality.
            if (randomItemToSelect > 2 && randomItemToSelect <=5)
                return Quality.Bad;

            //Approximately 40% chance of fair quality
            if (randomItemToSelect > 5 && randomItemToSelect <= 55)
                return Quality.Fair;

            //Approximately 30% chance of fair quality
            if (randomItemToSelect > 55 && randomItemToSelect <= 85)
                return Quality.Good;

            //Approximately 15% chance of fair quality
            if (randomItemToSelect > 85 && randomItemToSelect <= 100)
                return Quality.Perfect;

            //This should not be hit given random number 1 through 100 and all cases above.
            return Quality.Fair;
        }
    }
}
