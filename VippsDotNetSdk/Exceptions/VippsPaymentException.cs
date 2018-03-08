using System;
using VippsDotNetSdk.Model.Error;

namespace VippsDotNetSdk.Exceptions
{
    public class VippsPaymentException : VippsException
    {
        public readonly PaymentError Error;
        public VippsPaymentException()
        { }

        public VippsPaymentException(PaymentError error) : base(error.ErrorMessage)
        {
            Error = error;
        }

        public VippsPaymentException(string message)
            : base(message)
        { }

        public VippsPaymentException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
