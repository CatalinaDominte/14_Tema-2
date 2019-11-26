using System;

namespace Exceptions
{
    [Serializable]
    public class BothArgsAreZeroException : Exception
    {
        public BothArgsAreZeroException() { }
        public BothArgsAreZeroException(string message) : base(message) { }
        public BothArgsAreZeroException(string message, Exception inner) : base(message, inner) { }
        protected BothArgsAreZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
