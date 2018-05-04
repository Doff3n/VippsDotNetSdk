using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using VippsDotNetSdk.Exceptions;
using VippsDotNetSdk.Model.Authorization;
using VippsDotNetSdk.Model.Error;
using VippsDotNetSdk.Model.Payment;
using VippsDotNetSdk.Model.Payment.Request;
using VippsDotNetSdk.Model.Payment.Response;
using Cancel = VippsDotNetSdk.Model.Payment.Response.Cancel;
using Capture = VippsDotNetSdk.Model.Payment.Response.Capture;
using Initiate = VippsDotNetSdk.Model.Payment.Response.Initiate;
using Refund = VippsDotNetSdk.Model.Payment.Response.Refund;

namespace VippsDotNetSdk
{
    public class VippsClient : IVippsClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _accessSubscriptionKey;
        private readonly string _ecommerceSubscriptionKey;
        private readonly string _orderUrl;
        private readonly string _merchantSerialNumber;
        private readonly bool   _isApp;
        private readonly Token  _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="VippsClient" /> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="accessSubscriptionKey">The access subscription key.</param>
        /// <param name="ecommerceSubscriptionKey">The ecommerce subscription key.</param>
        /// <param name="orderUrl">The order URL.</param>
        /// <param name="merchantSerialNumber">The merchant serial number.</param>
        public VippsClient(
            string clientId,
            string clientSecret,
            string accessSubscriptionKey,
            string ecommerceSubscriptionKey,
            string orderUrl,
            string merchantSerialNumber,
            bool   isApp = false)
        {
            _clientId                 = clientId;
            _clientSecret             = clientSecret;
            _accessSubscriptionKey    = accessSubscriptionKey;
            _orderUrl                 = orderUrl;
            _merchantSerialNumber     = merchantSerialNumber;
            _ecommerceSubscriptionKey = ecommerceSubscriptionKey;
            _token                    = GetToken();
            _isApp                    = isApp;
        }

        public Initiate Initiate(string orderId,
            string                      mobilNumber,
            int                         amount,
            string                      description,
            string                      callbackPrefix,
            string                      fallBack,
            string                      refOrderId = "")
        {
            RestRequest request =
                CreateInitiateRequest(orderId, mobilNumber, amount, description, callbackPrefix, fallBack);
            return Execute<Initiate>(request);
        }

        public Task<Initiate> InitiateAsync(string orderId,
            string                                 mobilNumber,
            int                                    amount,
            string                                 description,
            string                                 callbackPrefix,
            string                                 fallBack,
            string                                 refOrderId = "")
        {
            RestRequest request =
                CreateInitiateRequest(orderId, mobilNumber, amount, description, callbackPrefix, fallBack);
            return ExecuteAsync<Initiate>(request);
        }

        private RestRequest CreateInitiateRequest(string orderId,
            string                                       mobilNumber,
            int                                          amount,
            string                                       description,
            string                                       callbackUrl,
            string                                       fallback,
            string                                       refOrderId = "")
        {
            var request = MakeBaseRestRequest(Constants.UrlPaths.Initiate, Method.POST);

            var paymentRequest = MakeBaseRequest<Model.Payment.Request.Initiate>(fallback, callbackUrl);

            paymentRequest.CustomerInfo              = new CustomerInfo();
            paymentRequest.CustomerInfo.MobileNumber = mobilNumber;

            var transaction             = new Transaction();
            transaction.TransactionText = description;
            transaction.Amount          = amount;
            transaction.OrderId         = orderId;
            if (!string.IsNullOrEmpty(refOrderId))
            {
                transaction.RefOrderId = refOrderId;
            }

            paymentRequest.Transaction = transaction;

            request.AddBody(paymentRequest);
            return request;
        }

        public Initiate InitiateExpress(string orderId,
            int                                amount,
            string                             description,
            string                             callbackPrefix,
            string                             fallBack,
            string                             shippingDetailsPrefix,
            string                             consentRemovalPrefix,
            string                             refOrderId  = "",
            string                             mobilNumber = "",
            string                             authToken   = "")
        {
            RestRequest request =
                CreateInitiateExpressRequest(orderId, amount,               description, callbackPrefix, fallBack,
                    shippingDetailsPrefix,            consentRemovalPrefix, refOrderId,  mobilNumber,    authToken);
            return Execute<Initiate>(request);
        }

        public Task<Initiate> InitiateExpressAsync(string orderId,
            int                                           amount,
            string                                        description,
            string                                        callbackPrefix,
            string                                        fallBack,
            string                                        shippingDetailsPrefix,
            string                                        consentRemovalPrefix,
            string                                        refOrderId  = "",
            string                                        mobilNumber = "",
            string                                        authToken   = "")
        {
            RestRequest request =
                CreateInitiateExpressRequest(orderId, amount,               description, callbackPrefix, fallBack,
                    shippingDetailsPrefix,            consentRemovalPrefix, refOrderId,  mobilNumber,    authToken);
            return ExecuteAsync<Initiate>(request);
        }

        private RestRequest CreateInitiateExpressRequest(string orderId,
            int                                                 amount,
            string                                              description,
            string                                              callbackPrefix,
            string                                              fallBack,
            string                                              shippingDetailsPrefix,
            string                                              consentRemovalPrefix,
            string                                              refOrderId   = "",
            string                                              mobileNumber = "",
            string                                              authToken    = "")
        {
            var request = MakeBaseRestRequest(Constants.UrlPaths.Initiate, Method.POST);

            var paymentRequest =
                MakeBaseRequest<Model.Payment.Request.Initiate>(fallBack, callbackPrefix, true);
            paymentRequest.MerchantInfo.ShippingDetailsPrefix = shippingDetailsPrefix;
            paymentRequest.MerchantInfo.ConsentRemovalPrefix  = consentRemovalPrefix;
            paymentRequest.MerchantInfo.AuthToken             = authToken;

            paymentRequest.CustomerInfo = new CustomerInfo();
            if (!string.IsNullOrEmpty(mobileNumber))
            {
                paymentRequest.CustomerInfo.MobileNumber = mobileNumber;
            }

            var transaction             = new Transaction();
            transaction.TransactionText = description;
            transaction.Amount          = amount;
            transaction.OrderId         = orderId;

            if (!string.IsNullOrEmpty(refOrderId))
            {
                transaction.RefOrderId = refOrderId;
            }

            paymentRequest.Transaction = transaction;

            request.AddBody(paymentRequest);
            return request;
        }

        public Capture Capture(string orderId, string description, int amount = 0)
        {
            RestRequest request = CreateCaptureRequest(orderId, description, amount);
            return Execute<Capture>(request);
        }

        public Task<Capture> CaptureAsync(string orderId, string description, int amount = 0)
        {
            RestRequest request = CreateCaptureRequest(orderId, description, amount);
            return ExecuteAsync<Capture>(request);
        }

        private RestRequest CreateCaptureRequest(string orderId, string description, int amount)
        {
            RestRequest request = MakeBaseRestRequest(string.Format(Constants.UrlPaths.Capture, orderId), Method.POST);

            Model.Payment.Request.Capture captureRequest = MakeBaseRequest<Model.Payment.Request.Capture>();

            Transaction transaction     = new Transaction();
            transaction.TransactionText = description;
            transaction.TimeStamp       = DateTime.Now;
            if (amount > 0)
            {
                transaction.Amount = amount;
            }

            captureRequest.Transaction = transaction;
            request.AddBody(captureRequest);
            return request;
        }

        public Cancel Cancel(string orderId, string description)
        {
            RestRequest request = CreateCancelRequest(orderId, description);
            return Execute<Cancel>(request);
        }

        public Task<Cancel> CancelAsync(string orderId, string description)
        {
            RestRequest request = CreateCancelRequest(orderId, description);
            return ExecuteAsync<Cancel>(request);
        }

        private RestRequest CreateCancelRequest(string orderId, string description)
        {
            RestRequest request = MakeBaseRestRequest(string.Format(Constants.UrlPaths.Cancel, orderId), Method.PUT);

            Model.Payment.Request.Cancel cancelRequest = MakeBaseRequest<Model.Payment.Request.Cancel>();

            Transaction transaction     = new Transaction();
            transaction.TransactionText = description;
            transaction.TimeStamp       = DateTime.Now;

            cancelRequest.Transaction = transaction;
            request.AddBody(cancelRequest);
            return request;
        }

        public Refund Refund(string orderId, string description, int amount = 0)
        {
            RestRequest request = CreateRefundRequest(orderId, description, amount);
            return Execute<Refund>(request);
        }

        public Task<Refund> RefundAsync(string orderId, string description, int amount = 0)
        {
            RestRequest request = CreateRefundRequest(orderId, description, amount);
            return ExecuteAsync<Refund>(request);
        }

        private RestRequest CreateRefundRequest(string orderId, string description, int amount)
        {
            var request = MakeBaseRestRequest(string.Format(Constants.UrlPaths.Refund, orderId), Method.POST);

            var refundRequest = MakeBaseRequest<Model.Payment.Request.Refund>();

            var transaction             = new Transaction();
            transaction.TransactionText = description;
            transaction.TimeStamp       = DateTime.Now;

            if (amount > 0)
            {
                transaction.Amount = amount;
            }

            refundRequest.Transaction = transaction;
            request.AddBody(refundRequest);
            return request;
        }

        public Details GetDetails(string orderId)
        {
            RestRequest request =
                MakeBaseRestRequest(string.Format(Constants.UrlPaths.Details, orderId),
                    Method.GET);

            return Execute<Details>(request);
        }

        public Task<Details> GetDetailsAsync(string orderId)
        {
            RestRequest request =
                MakeBaseRestRequest(string.Format(Constants.UrlPaths.Details, orderId),
                    Method.GET);

            return ExecuteAsync<Details>(request);
        }

        public OrderStatus GetOrderStatus(string orderId)
        {
            RestRequest request =
                MakeBaseRestRequest(string.Format(Constants.UrlPaths.Status, orderId),
                    Method.GET);

            return Execute<OrderStatus>(request);
        }

        public Task<OrderStatus> GetOrderStatusAsync(string orderId)
        {
            RestRequest request =
                MakeBaseRestRequest(string.Format(Constants.UrlPaths.Status, orderId),
                    Method.GET);

            return ExecuteAsync<OrderStatus>(request);
        }

        /****************************************
         *                                      *
         * Private helper functions             *
         *                                      *
         ****************************************/

        private Token GetToken()
        {
            if (_token != null)
            {
                return _token;
            }

            RestClient client = new RestClient(_orderUrl);

            RestRequest request = new RestRequest(Constants.UrlPaths.Token, Method.POST);

            request.AddHeader(Constants.Authorization.ClientId,        _clientId);
            request.AddHeader(Constants.Authorization.ClientSecret,    _clientSecret);
            request.AddHeader(Constants.Authorization.SubscriptionKey, _accessSubscriptionKey);

            var requestResult = client.Execute<Token>(request);
            return requestResult.Data;
        }

        private async Task<T> ExecuteAsync<T>(IRestRequest request) where T : BaseResponse
        {
            RestClient       client   = new RestClient(_orderUrl);
            IRestResponse<T> response = await client.ExecuteTaskAsync<T>(request);
            return HandleResponse(response);
        }

        private T Execute<T>(IRestRequest request) where T : BaseResponse, new()
        {
            RestClient       client   = new RestClient(_orderUrl);
            IRestResponse<T> response = client.Execute<T>(request);

            return HandleResponse(response);
        }

        private T HandleResponse<T>(IRestResponse<T> response)
        {
            if (response.IsSuccessful)
            {
                return response.Data;
            }

            PaymentError errorResponse = JsonConvert.DeserializeObject<IEnumerable<PaymentError>>(response.Content)
                .FirstOrDefault();

            throw new VippsPaymentException(errorResponse);
        }

        private T MakeBaseRequest<T>(string fallback = "", string callbackPrefix = "", bool express = false)
            where T : BaseRequest, new()
        {
            T baseRequest                                 = new T();
            baseRequest.MerchantInfo                      = new MerchantInfo();
            baseRequest.MerchantInfo.MerchantSerialNumber = _merchantSerialNumber;
            baseRequest.MerchantInfo.IsApp                = _isApp;
            baseRequest.MerchantInfo.PaymentType          = express ? "eComm Express Payment" : "eComm Regular Payment";

            if (!string.IsNullOrEmpty(fallback))
            {
                baseRequest.MerchantInfo.Fallback = fallback;
            }

            if (!string.IsNullOrEmpty(callbackPrefix))
            {
                baseRequest.MerchantInfo.CallbackPrefix = callbackPrefix;
            }

            return baseRequest;
        }

        private RestRequest MakeBaseRestRequest(string path, Method method)
        {
            RestRequest request = new RestRequest(path, method);
            request.AddHeader("Authorization",             $"Bearer {_token.AccessToken}");
            request.AddHeader("Ocp-Apim-Subscription-Key", _ecommerceSubscriptionKey);
            request.AddHeader("X-Request-Id",              string.Concat(Guid.NewGuid().ToString().Take(30)));
            request.AddHeader("Content-Type",              "application/json");
            request.RequestFormat  = DataFormat.Json;
            request.JsonSerializer = new JsonSerializer();

            return request;
        }
    }
}