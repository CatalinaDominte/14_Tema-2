using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{

    [Serializable]
    public class CustomProgramException : Exception
    {
        public CustomProgramException() { }

        public CustomProgramException(string message) : base(message) { }

        public CustomProgramException(string message, Exception inner) : base(message, inner) { }

        protected CustomProgramException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
