using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Exceptions
{

    [Serializable]
    public class InvalidProviderException : ApplicationException
    {
        public InvalidProviderException() { }
        public InvalidProviderException(string message) : base(message) { }
        public InvalidProviderException(string message, Exception inner) : base(message, inner) { }
        protected InvalidProviderException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
