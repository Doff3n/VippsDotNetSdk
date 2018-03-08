using System;
using VippsDotNetSdk.Model.Error;

namespace VippsDotNetSdk.Exceptions
{
    public class VippsAuthorizationException : VippsException
    {
        public readonly AuthorizationError Error;
        public VippsAuthorizationException()
        { }

        public VippsAuthorizationException(AuthorizationError error) : base(error.ErrorDescription)
        {
            Error = error;
        }

        public VippsAuthorizationException(string message)
            : base(message)
        { }

        public VippsAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
