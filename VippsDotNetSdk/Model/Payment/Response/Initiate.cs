namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Initiate : BaseResponse
    {
        public string          MerchantSerianNumber { get; set; }
        public TransactionInfo TransactionInfo      { get; set; }
    }
}