using System;
using System.Collections.Generic;
using System.Text;

namespace VippsDotNetSdk
{
    public static class Constants
    {
        public static class Authorization
        {
            public static string ClientId        => "client_id";
            public static string ClientSecret    => "client_secret";
            public static string SubscriptionKey => "Ocp-Apim-Subscription-Key";
        }

        public static class UrlPaths
        {
            public static string Token    => "accessToken/get";
            public static string Initiate => "Ecomm/v1/payments";
            public static string Capture  => "Ecomm/v1/payments/{0}/capture";
            public static string Cancel   => "Ecomm/v1/payments/{0}/cancel";
            public static string Refund   => "Ecomm/v1/payments/{0}/refund";
            public static string Details  => "Ecomm/v1/payments/{0}/serialNumber/{1}/details";
            public static string Status   => "Ecomm/v1/payments/{0}/serialNumber/{1}/status";
        }
    }
}