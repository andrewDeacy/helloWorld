using System;
using System.Runtime.Serialization;

namespace HelloWorld.Models
{

    /// <summary>
    /// Token class
    /// </summary>
    public class Token : IToken
    {

        #region Properties

        /// <summary>
        /// Api id returned from DB
        /// </summary>
        [DataMember()]
        public int ApiID { get; set; }

        /// <summary>
        /// Uhh ApiKey is userId_openDate..
        /// </summary>
        [DataMember()]
        public string ApiKey { get; set; }

        /// <summary>
        /// The date in which the token expires
        /// </summary>
        [DataMember()]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// The date our token was created
        /// </summary>
        [DataMember()]
        public DateTime OpenDate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creating our token class
        /// </summary>
        /// <param name="UserId"></param>
        public Token(int UserId)
        {
            this.ApiID = 0;
            this.OpenDate = DateTime.Now;
            this.ExpirationDate = this.OpenDate.AddDays(90);
            this.ApiKey = (UserId.ToString() + "_" + this.OpenDate); 
        }

        #endregion

    }
}