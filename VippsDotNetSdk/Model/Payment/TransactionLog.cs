using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VippsDotNetSdk.Model.Payment
{
    public class TransactionLog
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

        public DateTime TimeStamp       { get; set; }
        public int      Amount          { get; set; }
        public string   Transactionid   { get; set; }
    }
}