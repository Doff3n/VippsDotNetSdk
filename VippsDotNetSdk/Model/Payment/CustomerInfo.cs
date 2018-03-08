using Newtonsoft.Json;

namespace VippsDotNetSdk.Model.Payment
{
    public class CustomerInfo
    {
        [JsonProperty(PropertyName = "mobileNumber")]
        public string MobileNumber { get; set; }
    }
}
