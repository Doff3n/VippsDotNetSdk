using System;
using Newtonsoft.Json;

namespace VippsDotNetSdk.Model.Payment
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "orderId")]
        public string OrderId { get; set; }

        [JsonProperty(PropertyName = "refOrderId", NullValueHandling = NullValueHandling.Ignore)]
        public string RefOrderId { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        [JsonProperty(PropertyName = "transactionText")]
        public string TransactionText { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }
    }
}