namespace HelloWorld.Models
{
        /// <summary>
        /// Enum representing errors from the api
        /// </summary>
        public enum HelloWorldErrors {
            
            /// <summary>
            /// No errors occured
            /// </summary>
            NoError = 0,

            /// <summary>
            /// Invalid credentials were provided
            /// </summary>
            InvalidCredentials = 101,

            /// <summary>
            /// User's token is invalid
            /// </summary>
            InvalidToken = 102
        }
}