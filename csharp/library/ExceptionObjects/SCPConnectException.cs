#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Exception raised when an error occured trying to connnect to the
*               OpenROAD Application Server.
*
* Class : Extends APIException.
*
* Class Name : SCPConnectException
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : SCPConnectException.cs
*
* Version History
*
* Version Date       Who Description
* ------- ---------- --- --------------
* 1.0     01/05/2008 LUM Original Version
*/
#endregion

#region Namespaces Used
using System;
using System.Runtime.Serialization;
#endregion

namespace Luminary.ProxyGen.Util
{
    /// <summary>
    /// Provides information for an SCP connect exception.
    /// </summary>
    [Serializable]
    public class SCPConnectException : APIException
    {
        #region Class Properties

        #endregion

        #region Class Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SCPConnectException()
        {

        }

        /// <summary>
        /// Message parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public SCPConnectException(string message) : base(message)
        {

        }

        /// <summary>
        /// Message and inner exception parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public SCPConnectException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization stream context.</param>
        public SCPConnectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
        #endregion


        #region Class Methods
        /// <summary>
        /// Get the object data for serialization.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization stream context.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        #endregion
    }
}
