using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VippsDotNetSdk.Model
{
    public class UserDetails
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo BankIdVerified { get; set; }
        public string DateOfBirth    { get; set; }
        public string Email          { get; set; }
        public string FirstName      { get; set; }
        public string LastName       { get; set; }
        public string MobileNumber   { get; set; }
        public string Ssn            { get; set; }
        public string UserId         { get; set; }
    }
}