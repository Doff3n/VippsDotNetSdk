namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Cancel : BaseResponse
    {
        public TransactionInfo    TransactionInfo    { get; set; }
        public TransactionSummary TransactionSummary { get; set; }
    }
}