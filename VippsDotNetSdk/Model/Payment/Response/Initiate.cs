namespace VippsDotNetSdk.Model.Payment.Response
{
    public class Initiate : BaseResponse
    {
        /// <summary>
        /// URL to redirect to after a Initiate is successfull
        /// </summary>
        public string Url { get; set; }
    }
}