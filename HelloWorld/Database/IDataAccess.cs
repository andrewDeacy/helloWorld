using System.Collections.Generic;
using System.Data;

namespace HelloWorld.Database
{

    /// <summary>
    /// Defines a call to database to get and/or update results
    /// </summary>
    public interface IDataAccess<T> where T : IDataParameterCollection
    {

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IDataParameter CreateParameter(string parameterName, int type, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseSetting"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IDataResult<T> ExecuteStoredProcedure(IDatabaseConnectionSetting databaseSetting, string procedureName, IEnumerable<IDataParameter> parameters, int timeout = 60);

        #endregion

    }
}