using System.Collections;
using System.Collections.Generic;

namespace VippsDotNetSdk.Model.Callback.Shipping
{
    public class ShippingResponse
    {
        public int                    AddressId       { get; set; }
        public string                 OrderId         { get; set; }
        public IList<ShippingDetails> ShippingDetails { get; set; }
    }
}