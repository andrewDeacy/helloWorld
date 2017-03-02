using HelloWorld.Models;

namespace HelloWorld.Products
{
    public interface ISessionHandler
    {
        IHelloWorldUser HelloWorldUser { get; set; }

        void Authenticate();
        void End();
        IToken Start();
    }
}