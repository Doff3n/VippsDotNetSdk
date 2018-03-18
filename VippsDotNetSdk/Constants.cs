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
            public static string Initiate => "ecomm/v2/payments";
            public static string Capture  => "ecomm/v2/payments/{0}/capture";
            public static string Cancel   => "ecomm/v2/payments/{0}/cancel";
            public static string Refund   => "ecomm/v2/payments/{0}/refund";
            public static string Details  => "ecomm/v2/payments/{0}/details";
            public static string Status   => "ecomm/v2/payments/{0}/status";
        }
    }
}