namespace VippsDotNetSdk.Model.Callback.Shipping
{
    public class ShippingDetails
    {
        public YesNo   IsDefault        { get; set; }
        public int     Priority         { get; set; }
        public decimal ShippingCost     { get; set; }
        public string  ShippingMethod   { get; set; }
        public string  ShippingMethodId { get; set; }
    }
}