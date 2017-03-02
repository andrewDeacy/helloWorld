using System;

namespace HelloWorld.Models
{
    public interface IToken
    {
        int ApiID { get; set; }
        string ApiKey { get; set; }
        DateTime ExpirationDate { get; set; }
        DateTime OpenDate { get; set; }
    }
}