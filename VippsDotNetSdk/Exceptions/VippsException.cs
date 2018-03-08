using System;
using VippsDotNetSdk.Model.Error;

namespace VippsDotNetSdk.Exceptions
{
    [Serializable]
    public class VippsException : Exception
    {
        public VippsException()
        { }

        public VippsException(string message)
            : base(message)
        { }

        public VippsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
