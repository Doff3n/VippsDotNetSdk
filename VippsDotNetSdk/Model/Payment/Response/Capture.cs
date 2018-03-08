namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Capture : BaseResponse
    {
        public TransactionInfo    TransactionInfo    { get; set; }
        public TransactionSummary TransactionSummary { get; set; }
    }
}