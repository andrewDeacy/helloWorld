namespace HelloWorld.Models
{

    /// <summary>
    /// Credentials for a given hello world user
    /// </summary>
    public class HelloWorldUser : IHelloWorldUser
    {

        #region Properties

        /// <summary>
        /// The api user's api key
        /// </summary>
        public string ApiKey { get; set; } = "";

        /// <summary>
        /// The api user's api id
        /// </summary>
        public int ApiId { get; set; } = 0;

        /// <summary>
        /// Hello world api user's username
        /// </summary>
        public string Username { get; set; } = "";

        /// <summary>
        /// Hello world api user's password
        /// </summary>
        public string HashedPassword { get; set; } = "";

        /// <summary>
        /// Hello world api user's employee id
        /// </summary>
        public int UserId { get; set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        public HelloWorldErrors ErrorCode { get; set; } = HelloWorldErrors.NoError;

        #endregion

    }
}