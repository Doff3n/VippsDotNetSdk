using Newtonsoft.Json;

namespace VippsDotNetSdk.Model.Payment
{
    public class MerchantInfo
    {
        [JsonProperty(PropertyName = "merchantSerialNumber")]
        public string MerchantSerialNumber { get; set; }
        [JsonProperty(PropertyName = "callBack")]
        public string CallBack { get; set; }
    }
}
