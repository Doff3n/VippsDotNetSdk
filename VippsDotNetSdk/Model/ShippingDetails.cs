namespace VippsDotNetSdk.Model
{
    public class ShippingDetails
    {
        public Address Address          { get; set; }
        public decimal ShippingCost     { get; set; }
        public string  ShippingMethod   { get; set; }
        public string  ShippingMethodId { get; set; }
    }
}