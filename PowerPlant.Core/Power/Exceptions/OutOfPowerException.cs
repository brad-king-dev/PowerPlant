using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Core.Power.Exceptions
{

    [Serializable]
    public class OutOfPowerException : Exception
    {
        public OutOfPowerException() { }
        public OutOfPowerException(string message) : base(message) { }
        public OutOfPowerException(string message, Exception inner) : base(message, inner) { }
        protected OutOfPowerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
