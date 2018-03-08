using System.Collections.Generic;

namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Details : BaseResponse
    {
        public TransactionSummary   TransactionSummary { get; set; }
        public IEnumerable<TransactionLog> TransactionLogHistory     { get; set; }
    }
}