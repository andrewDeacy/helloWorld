namespace HelloWorld.Models
{

    /// <summary>
    /// Parameter for hello world API calls
    /// </summary>
    public class HelloWorldParameters : IHelloWorldParameters
    {

        #region Properties

        /// <summary>
        /// API Id from token
        /// </summary>
        public int ApiId { get; set; } = -1;

        /// <summary>
        /// Where we are writing the hello world output to
        /// </summary>
        public string FileName { get; set; } = "";

        /// <summary>
        /// Username passed into API
        /// </summary>
        public string Username { get; set; } = "";

        /// <summary>
        /// Plain text password inputed by user
        /// </summary>
        public string Password { get; set; } = "";

        #endregion

    }
}