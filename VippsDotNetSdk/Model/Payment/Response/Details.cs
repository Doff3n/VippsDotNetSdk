using System.Collections.Generic;

namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Details : BaseResponse
    {
        public ShippingDetails             ShippingDetails       { get; set; }
        public TransactionSummary          TransactionSummary    { get; set; }
        public IEnumerable<TransactionLog> TransactionLogHistory { get; set; }
        public UserDetails                 UserDetails           { get; set; }
    }
}