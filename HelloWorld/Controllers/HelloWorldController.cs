using HelloWorld.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace HelloWorld.Controllers
{

    /// <summary>
    /// Our API controller which provides user's with various ways to Hello World
    /// </summary>
    public class HelloWorldController : ApiController
    {

        #region Properties

        /// <summary>
        /// The logic for printing hello world
        /// </summary>
        private Core.HelloWorld HelloWorldLogic { get; set; }

        /// <summary>
        /// String writer for writing hello world to a file..
        /// </summary>
        private StringWriter StringMaker { get; set; } = new StringWriter();

        #endregion

        #region Methods

        /// <summary>
        /// API method for printing hello world to console
        /// </summary>
        /// <returns></returns>       
        [HttpPost]
        [Route("v1/hello_world/print")]
        public HttpResponseMessage WriteHelloWorld(IHelloWorldParameters parameters)
        {
            this.HelloWorldLogic = new Core.HelloWorld(this.StringMaker, parameters);
            if (parameters.ApiId > 0 ) { // would actually check if token is valid from DB..
                this.HelloWorldLogic.PrintHelloWorld();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new Exception("Invalid token..");
            }    
        }

        /// <summary>
        /// API method for returning hello world string
        /// </summary>
        /// <returns></returns>       
        [HttpPost]
        [Route("v1/hello_world/get_string")]
        public HttpResponseMessage ReturnHelloWorld(IHelloWorldParameters parameters)
        {
            if (parameters.ApiId > 0)
            { // would actually check if token is valid from DB..
                this.HelloWorldLogic.PrintHelloWorld();
                return this.Request.CreateResponse(HttpStatusCode.OK, this.HelloWorldLogic.GetHelloWorld());
            }
            else
            {
                throw new Exception("Invalid token..");
            }
        }

        /// <summary>
        /// API method for updating hello world in DB?
        /// </summary>
        /// <returns></returns>       
        [HttpPost]
        [Route("v1/hello_world/update_db")]
        public HttpResponseMessage UpdateHelloWorld(IHelloWorldParameters parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
