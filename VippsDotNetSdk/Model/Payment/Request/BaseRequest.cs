using Newtonsoft.Json;

namespace VippsDotNetSdk.Model.Payment.Request
{
    public abstract class BaseRequest
    {
        [JsonProperty(PropertyName = "merchantInfo")]
        public MerchantInfo MerchantInfo { get; set; }

        [JsonProperty(PropertyName = "transaction")]
        public Transaction Transaction { get; set; }
    }
}