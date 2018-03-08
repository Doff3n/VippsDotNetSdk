using System;

namespace VippsDotNetSdk.Model.Payment
{
    public class TransactionLog
    {
        public DateTime TimeStamp       { get; set; }
        public string   Operation       { get; set; }
        public int      Amount          { get; set; }
        public string   Transactionid   { get; set; }
        public string   TransactionText { get; set; }
        public string   RequestId       { get; set; }
    }
}