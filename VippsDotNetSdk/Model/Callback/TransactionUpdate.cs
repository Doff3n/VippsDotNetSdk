using VippsDotNetSdk.Model.Error;
using VippsDotNetSdk.Model.Payment;

namespace VippsDotNetSdk.Model.Callback
{
    public class TransactionUpdate
    {
        public string          MerchantSerialNumber { get; set; }
        public string          OrderId              { get; set; }
        public ShippingDetails ShippingDetails      { get; set; }
        public TransactionInfo TransactionInfo      { get; set; }
        public UserDetails     UserDertails         { get; set; }
        public PaymentError    Error                { get; set; }
    }
}