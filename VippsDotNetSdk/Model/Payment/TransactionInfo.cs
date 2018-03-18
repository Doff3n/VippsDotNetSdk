using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VippsDotNetSdk.Model.Payment
{
    public class TransactionInfo
    {
        public int Amount { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

        public string   TransactionText { get; set; }
        public string   TransactionId   { get; set; }
        public DateTime TimeStamp       { get; set; }
    }
}