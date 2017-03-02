using System.Data;
using System.Data.SqlClient;

namespace HelloWorld.Database
{

    /// <summary>
    /// Class representing sql db call result
    /// </summary>
    public class SqlResult : IDataResult<IDataParameterCollection>
    {

        #region Properties

        /// <summary>
        /// Gets data from data layer
        /// </summary>
        public DataSet DataSet { get; }

        /// <summary>
        /// If data set has results
        /// </summary>
        public bool HasResults { get; }

        /// <summary>
        /// Gets params from data layer
        /// </summary>
        public IDataParameterCollection Parameters { get; }

        #endregion

        #region Constructors

        public SqlResult(SqlParameterCollection parameters, DataSet dataSet)
        {
            this.Parameters = parameters;
            this.DataSet = dataSet;
            this.HasResults = false;

            foreach(DataTable table in DataSet.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    this.HasResults = true;
                    break;
                }
            }
        }

        #endregion

    }
}