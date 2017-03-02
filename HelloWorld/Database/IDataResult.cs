using System.Data;

namespace HelloWorld.Database
{

    /// <summary>
    /// Defines results from data layer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataResult<T> where T : IDataParameterCollection
    {

        #region Properties

        /// <summary>
        /// Gets data from data layer
        /// </summary>
        DataSet DataSet { get; }

        /// <summary>
        /// If data set has results
        /// </summary>
        bool HasResults { get; }

        /// <summary>
        /// Gets params from data layer
        /// </summary>
        T Parameters { get; }

        #endregion

    }
}