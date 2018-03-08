namespace VippsDotNetSdk.Model.Payment
{
    public class TransactionSummary
    {
        public int CapturedAmount { get; set; }
        public int RemainingAmountToCapture { get; set; }
        public int RefundedAmount { get; set; }
        public int RemainingAmountToRefund { get; set; }
    }
}