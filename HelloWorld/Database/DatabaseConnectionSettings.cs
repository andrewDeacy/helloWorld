using System.Configuration;

namespace HelloWorld.Database
{

    /// <summary>
    /// Contains various connection strings that will be used through out hello world app
    /// </summary>
    public class DatabaseConnectionSettings : IDatabaseConnectionSettings
    {

        #region Properties

        /// <summary>
        /// Connection string 1 pulled from app config
        /// </summary>
        public IDatabaseConnectionSetting ConnectionString1 { get; }

        /// <summary>
        /// Connection string 2 pulled from app config
        /// </summary>
        public IDatabaseConnectionSetting ConnectionString2 { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Getting connection string from app config
        /// </summary>
        public DatabaseConnectionSettings()
        {
            this.ConnectionString1 = new DatabaseConnectionSetting(ConfigurationManager.AppSettings["ConnectionString1"]);
            this.ConnectionString2 = new DatabaseConnectionSetting(ConfigurationManager.AppSettings["ConnectionString2"]);
        }

        #endregion

    }
}