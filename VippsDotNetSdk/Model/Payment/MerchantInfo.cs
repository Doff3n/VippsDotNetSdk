using Newtonsoft.Json;

namespace VippsDotNetSdk.Model.Payment
{
    public class MerchantInfo
    {
        [JsonProperty("merchantSerialNumber")]
        public string MerchantSerialNumber { get; set; }

        [JsonProperty("callbackPrefix")]
        public string CallbackPrefix { get; set; }

        [JsonProperty("fallBack")]
        public string Fallback { get; set; }

        [JsonProperty("shippingDetailsPrefix")]
        public string ShippingDetailsPrefix { get; set; }

        [JsonProperty("autoToken")]
        public string AuthToken { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("consentRemovalPrefix")]
        public string ConsentRemovalPrefix { get; set; }

        [JsonProperty("isApp")]
        public bool IsApp { get; set; }
    }
}