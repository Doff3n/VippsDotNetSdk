using Newtonsoft.Json;

namespace VippsDotNetSdk.Model.Payment.Request
{
    public class Initiate : BaseRequest
    {
        [JsonProperty(PropertyName = "customerInfo")]
        public CustomerInfo CustomerInfo { get; set; }
    }
}