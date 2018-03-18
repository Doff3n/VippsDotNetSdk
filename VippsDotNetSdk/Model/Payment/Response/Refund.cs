namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Refund : BaseResponse
    {
        public TransactionInfo    Transaction        { get; set; }
        public TransactionSummary TransactionSummary { get; set; }
    }
}