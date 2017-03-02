using HelloWorld.Database;
using HelloWorld.Models;
using HelloWorld.Products;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorld.Controllers
{

    /// <summary>
    /// The controller for authorization
    /// </summary>
    public class AuthController : ApiController
    {

        #region Constants, Enums, and Variables

        /// <summary>
        /// The data access object for our  auth controller
        /// </summary>
        private readonly IDataAccess<IDataParameterCollection> DataAccess;

        /// <summary>
        /// The database connection settings for the auth controller
        /// </summary>
        private readonly IDatabaseConnectionSettings DatabaseConnectionSettings;

        /// <summary>
        /// The hello world user for the auth controller
        /// </summary>
        private readonly IHelloWorldUser HelloWorldUser;

        #endregion

        #region Constructors

        /// <summary>
        /// Creating our auth controller
        /// </summary>
        /// <param name="helloWorldUser"></param>
        /// <param name="dataAccess"></param>
        /// <param name="dbConnectionSettings"></param>
        public AuthController(IHelloWorldParameters helloWorldParams,
                              IHelloWorldUser helloWorldUser,
                              IDataAccess<IDataParameterCollection> dataAccess,
                              IDatabaseConnectionSettings dbConnectionSettings)
        {
            this.DataAccess = dataAccess;
            this.DatabaseConnectionSettings = dbConnectionSettings;
            this.HelloWorldUser = helloWorldUser;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Init authorization check which returns api id 
        /// </summary>
        /// <param name="parameters"></param>
        [HttpPost]
        [Route("v1/auth/authenticate")]
        public HttpResponseMessage AuthenticateUser(IHelloWorldParameters parameters)
        {
            var session = new SessionHandler(this.DataAccess, this.DatabaseConnectionSettings, parameters, this.HelloWorldUser);
            session.Authenticate();

            if (session.HelloWorldUser.ErrorCode.Equals(HelloWorldErrors.NoError))
            {
                var token = session.Start();
                this.HelloWorldUser.ApiId = token.ApiID;

                // returning token if all is good
                return this.Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                throw new Exception("Invalid credentials provided");
            }
        }

        #endregion

    }
}
