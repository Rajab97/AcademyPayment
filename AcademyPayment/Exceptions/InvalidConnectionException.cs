using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Exceptions
{
    [Serializable]
    public class InvalidConnectionException : ApplicationException
    {
        public InvalidConnectionException() { }
        public InvalidConnectionException(string message) : base(message) { }
        public InvalidConnectionException(string message, Exception inner) : base(message, inner) { }
        protected InvalidConnectionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
