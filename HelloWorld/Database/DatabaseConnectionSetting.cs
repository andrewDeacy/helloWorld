namespace HelloWorld.Database
{

    /// <summary>
    /// Database connection string object
    /// </summary>
    public class DatabaseConnectionSetting : IDatabaseConnectionSetting
    {

        #region Properties

        /// <summary>
        /// Connection string we're using
        /// </summary>
        public string ConnectionString { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Making a new instance of database connection settings
        /// </summary>
        /// <param name="connectionString"></param>
        public DatabaseConnectionSetting(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

    }
}