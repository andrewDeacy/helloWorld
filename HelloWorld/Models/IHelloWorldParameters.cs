namespace HelloWorld.Models
{
    public interface IHelloWorldParameters
    {
        int ApiId { get; set; }
        string FileName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}