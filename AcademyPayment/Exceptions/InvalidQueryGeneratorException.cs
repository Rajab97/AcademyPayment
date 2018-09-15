using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Exceptions
{

    [Serializable]
    public class InvalidQueryGeneratorException : ApplicationException
    {
        public InvalidQueryGeneratorException() { }
        public InvalidQueryGeneratorException(string message) : base(message) { }
        public InvalidQueryGeneratorException(string message, Exception inner) : base(message, inner) { }
        protected InvalidQueryGeneratorException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
