using HelloWorld.Database;
using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace HelloWorld.Products
{

    /// <summary>
    /// Session handler class   
    /// </summary>
    public class SessionHandler : ISessionHandler
    {

        #region Constants, Enums, and Variables

        /// <summary>
        /// The data access object for our session handler
        /// </summary>
        private readonly IDataAccess<IDataParameterCollection> DataAccess;

        /// <summary>
        /// The database connection settings for the session handler
        /// </summary>
        private readonly IDatabaseConnectionSettings DatabaseConnectionSettings;

        #endregion

        #region Properties

        /// <summary>
        /// The parameters for this hello world
        /// </summary>
        IHelloWorldParameters HelloWorldParams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IHelloWorldUser HelloWorldUser { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creating a new instance of the session handler
        /// </summary>
        /// <param name="dataAccess"></param>
        /// <param name="dbConnectionSettings"></param>
        /// <param name="helloWorldParams"></param>
        /// <param name="helloWorldUser"></param>
        public SessionHandler(IDataAccess<IDataParameterCollection> dataAccess,
                              IDatabaseConnectionSettings dbConnectionSettings,
                              IHelloWorldParameters helloWorldParams,
                              IHelloWorldUser helloWorldUser)
        {
            this.DataAccess = dataAccess;
            this.DatabaseConnectionSettings = dbConnectionSettings;
            this.HelloWorldParams = helloWorldParams;
            this.HelloWorldUser = helloWorldUser;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates token in DB
        /// </summary>
        /// <returns></returns>
        public IToken Start()
        {
            var Token = new Token(this.HelloWorldUser.UserId);

            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(this.DataAccess.CreateParameter("ToeknStartDate", 1, Token.OpenDate));
            parameters.Add(this.DataAccess.CreateParameter("ToeknExpireDate", 1, Token.ExpirationDate));
            parameters.Add(this.DataAccess.CreateParameter("UserId", 1, this.HelloWorldUser.ApiKey));

            IDataResult<IDataParameterCollection> result = this.DataAccess.ExecuteStoredProcedure(DatabaseConnectionSettings.ConnectionString1, "TokenStartProc", parameters);

            // Get the db generated api id that user will send in all calls to prove who they are
            Token.ApiID = (int)result.DataSet.Tables[0].Rows[0]["ApiId"];

            return Token;
        }

        /// <summary>
        /// Kills token in DB
        /// </summary>
        /// <returns></returns>
        public void End()
        {
            var Token = new Token(this.HelloWorldUser.UserId);

            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(this.DataAccess.CreateParameter("ToeknEndDate", 1, DateTime.Now));
            parameters.Add(this.DataAccess.CreateParameter("UserId", 1, this.HelloWorldUser.ApiKey));

            this.DataAccess.ExecuteStoredProcedure(DatabaseConnectionSettings.ConnectionString1, "UpdateTokenProc", parameters);
        }

        /// <summary>
        /// Getting user account values
        /// </summary>
        private void GetApiUserCredentials()
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(this.DataAccess.CreateParameter("Username", 1, this.HelloWorldParams.Username));
            parameters.Add(this.DataAccess.CreateParameter("Password", 1, this.HelloWorldParams.Password));

            IDataResult<IDataParameterCollection> result = this.DataAccess.ExecuteStoredProcedure(DatabaseConnectionSettings.ConnectionString1, "TokenStartProc", parameters);


            if (result.HasResults)
            {
                var row = result.DataSet.Tables[0].Rows[0];

                this.HelloWorldUser.UserId = (int)row["UserId"];
                this.HelloWorldUser.HashedPassword = (string)row["HashedPassword"];
                // blah blah blah assign values to account...              
            }

        }

        /// <summary>
        /// Authenticating user has good credentials, comparing plain text password passed in to hashed password from DB
        /// </summary>
        public void Authenticate()
        {
            this.GetApiUserCredentials();

            // some sort of check against credentials...
            if (this.HelloWorldParams.Password != this.HelloWorldUser.HashedPassword)
            {
                this.HelloWorldUser.ErrorCode = HelloWorldErrors.InvalidCredentials;
            }
            else
            {
                this.HelloWorldUser.ErrorCode = HelloWorldErrors.NoError;
            }
        }

        #endregion

    }
}