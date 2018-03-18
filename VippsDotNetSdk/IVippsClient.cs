using System.Threading.Tasks;
using VippsDotNetSdk.Model.Payment.Response;

namespace VippsDotNetSdk
{
    /// <summary>
    /// Interface to use against vipps integration.
    /// This is going against v1 of vipps integration
    /// </summary>
    public interface IVippsClient
    {
        /// <summary>
        /// Initiate payment is used to create a payment order in Vipps. 
        /// In order to identify sales channel payments are coming from merchantSerialNumber is used to distinguish between them. 
        /// Merchant provided orderId must be unique per sales channel. 
        /// Please note that single payment is uniquely identified by composite of merchantSerialNumber and orderId
        /// </summary>
        /// <param name="orderId">OrderId uniquely identifies a payment.</param>
        /// <param name="mobilNumber">Mobile number of the user to receive payment request</param>
        /// <param name="amount">Amount in øre</param>
        /// <param name="description">Transaction text displayed to end user in app</param>
        /// <param name="callbackPrefix">This is to receive the callback after the payment request.
        /// Domain name and context path should be provided by merchant as the value for this parameter.
        /// The rest of  the URL will be appended by Vipps according to Vipps guidelines</param>
        /// <param name="fallBack">Vipps will use the fall back URL to redirect Merchant Page once Payment is completed in Vipps System</param>
        /// <param name="refOrderId">Identifies if the payment references to 
        /// some paste orders registered with Vipps. If defined, transactions for this payment will
        /// show up as child transactions of the specified order.</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.Initiate"/></returns>
        Initiate Initiate(
            string orderId,
            string mobilNumber,
            int    amount,
            string description,
            string callbackPrefix,
            string fallBack,
            string refOrderId = "");

        /// <inheritdoc cref="Initiate"/>
        Task<Initiate> InitiateAsync(
            string orderId,
            string mobilNumber,
            int    amount,
            string description,
            string callbackPrefix,
            string fallBack,
            string refOrderId = "");

        /// <summary>
        /// Initiate payment is used to create a payment order in Vipps. 
        /// In order to identify sales channel payments are coming from merchantSerialNumber is used to distinguish between them. 
        /// Merchant provided orderId must be unique per sales channel. 
        /// Please note that single payment is uniquely identified by composite of merchantSerialNumber and orderId
        /// </summary>
        /// <param name="orderId">OrderId uniquely identifies a payment.</param>
        /// <param name="mobilNumber">Mobile number of the user to receive payment request</param>
        /// <param name="amount">Amount in øre</param>
        /// <param name="description">Transaction text displayed to end user in app</param>
        /// <param name="callbackPrefix">This is to receive the callback after the payment request.
        /// Domain name and context path should be provided by merchant as the value for this parameter.
        /// The rest of  the URL will be appended by Vipps according to Vipps guidelines</param>
        /// <param name="fallBack">Vipps will use the fall back URL to redirect Merchant Page once Payment is completed in Vipps System</param>
        /// <param name="shippingDetailsPrefix">In case of express checkout payment, merchant should pass this prefix to let Vipps fetch shipping cost and method related details</param>
        /// <param name="consentRemovalPrefix"></param>
        /// <param name="refOrderId">Identifies if the payment references to 
        /// some paste orders registered with Vipps. If defined, transactions for this payment will
        /// show up as child transactions of the specified order.</param>
        /// <param name="authToken">Merchant should share this token if merchant has authentication mechanism in place which could be used for making callbacks secure</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.Initiate"/></returns>
        Initiate InitiateExpress(
            string orderId,
            int    amount,
            string description,
            string callbackPrefix,
            string fallBack,
            string shippingDetailsPrefix,
            string consentRemovalPrefix,
            string refOrderId  = "",
            string mobilNumber = "",
            string authToken   = ""
        );

        /// <inheritdoc cref="Initiate"/>
        Task<Initiate> InitiateExpressAsync(
            string orderId,
            int    amount,
            string description,
            string callbackPrefix,
            string fallBack,
            string shippingDetailsPrefix,
            string consentRemovalPrefix,
            string refOrderId  = "",
            string mobilNumber = "",
            string authToken   = ""
        );

        /// <summary>
        /// The API call allows merchant to capture the reserved amount. 
        /// Amount to capture cannot be higher than reserved. 
        ///  API also allows capturing partial amount of the reserved amount. 
        /// Partial capture can be called as many times as required so long there is reserved amount to capture. 
        /// Transaction text is not optional and is used as a proof of delivery (tracking code, consignment number etc.).
        /// </summary>
        /// <param name="orderId">Identifies a merchant sale unit -This value is in Application tab</param>
        /// <param name="description">Transaction text displayed to end user in app</param>
        /// <param name="amount">Amount in øre. If 0 then everything will be captured</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.Capture"/></returns>
        Capture Capture(string orderId, string description, int amount = 0);

        /// <inheritdoc cref="Capture"/>
        Task<Capture> CaptureAsync(string orderId, string description, int amount = 0);

        /// <summary>
        /// Cancels the specified order.The API call allows merchant to cancel the reserved transaction, The API will not allow partial cancellation which has a consequence that partially captured transactions cannot be cancelled.
        /// </summary>
        /// <param name="orderId">Id which uniquely identifies a payment. Maximum length is 30 alphanumeric characters</param>
        /// <param name="description">Transaction text displayed to end user in app</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.Cancel"/></returns>
        Cancel Cancel(string orderId, string description);

        /// <inheritdoc cref="Cancel"/>
        Task<Cancel> CancelAsync(string orderId, string description);

        /// <summary>
        /// The API allows a merchant to do a refund of already captured transaction. There is an option to do a partial refund of the captured amount. Refunded amount cannot be larger than captured.
        /// Timeframe for issuing a refund for a payment is 365 days from the date payment has been captured.If the refund payment service call is called after the refund timeframe, service call will respond with an error.
        /// Refunded funds will be transferred from the merchant account to the customer credit card that was used in payment flow.Pay attention that in order to perform refund, there must be enough fund at merchant settlements account.
        /// </summary>
        /// <param name="orderId">Id which uniquely identifies a payment. Maximum length is 30 alphanumeric characters</param>
        /// <param name="description">Transaction text displayed to end user in app</param>
        /// <param name="amount">Amount in øre. If 0 then everything will be refunded</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.Refund"/></returns>
        Refund Refund(string orderId, string description, int amount = 0);

        /// <inheritdoc cref="Refund"/>
        Task<Refund> RefundAsync(string orderId, string description, int amount = 0);

        /// <summary>
        /// The API allows merchant to get the details of a payment transaction. Service call returns detailed transaction history of given payment where events are sorted by the time single transaction occurred.
        /// </summary>
        /// <param name="orderId">Id which uniquely identifies a payment. Maximum length is 30 alphanumeric characters</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.Details"/></returns>
        Details GetDetails(string orderId);

        /// <inheritdoc cref="Details"/>
        Task<Details> GetDetailsAsync(string orderId);

        /// <summary>
        /// The API allows merchant to get the status of the last payment transaction. Primarily use of this service is meant for inApp where simple response to check order status is preferred. The call doesn't give any transaction history, but only a simple status of the last payment transaction.
        /// </summary>
        /// <param name="orderId">Id which uniquely identifies a payment. Maximum length is 30 alphanumeric characters</param>
        /// <returns><see cref="VippsDotNetSdk.Model.Payment.Response.OrderStatus"/></returns>
        OrderStatus GetOrderStatus(string orderId);

        /// <inheritdoc cref="OrderStatus"/>
        Task<OrderStatus> GetOrderStatusAsync(string orderId);
    }
}