using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Manufacturing.Models
{
    public enum Quality
    {
        //Note by setting the first value of enum to 1 then every enum value after increments from 1.
        Terrible = 1,
        Bad,
        Fair,
        Good,
        Perfect
    }
}
