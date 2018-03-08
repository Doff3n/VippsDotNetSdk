using System;
using System.Collections.Generic;

namespace VippsDotNetSdk.Model.Error
{
    public class AuthorizationError
    {
        public string              Error            { get; set; }
        public string              ErrorDescription { get; set; }
        public IEnumerable<string> ErrorCodes       { get; set; }
        public DateTime            TimeStamp        { get; set; }
        public string              TraceId          { get; set; }
        public string              CorrelationId    { get; set; }
    }
}