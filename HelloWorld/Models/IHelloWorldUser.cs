namespace HelloWorld.Models
{
    public interface IHelloWorldUser
    {
        int ApiId { get; set; }
        string ApiKey { get; set; }
        string HashedPassword { get; set; }
        int UserId { get; set; }
        string Username { get; set; }
        HelloWorldErrors ErrorCode { get; set; }
    }
}