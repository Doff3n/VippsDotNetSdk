using System;

namespace VippsDotNetSdk.Model.Authorization
{
    public class Token
    {
        public string   TokenType    { get; set; }
        public int      ExpiresIn    { get; set; }
        public int      ExtExpiresIn { get; set; }
        public DateTime ExpiresOn    { get; set; }
        public DateTime NotBefore    { get; set; }
        public string   Resource     { get; set; }
        public string   AccessToken  { get; set; }
    }
}
