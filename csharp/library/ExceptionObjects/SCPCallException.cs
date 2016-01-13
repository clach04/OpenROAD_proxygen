#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Exception raised when an error occures while calling an SCP.
*
* Class : Extends APIException.
*
* Class Name : SCPCallException
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : SCPCallException.cs
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
    /// Provides information for an SCP call exception.
    /// </summary>
    [Serializable]
    public class SCPCallException : APIException
    {
        #region Class Fields

        // private variables
        private int _scpErrorNo   = 0;
        private int _scpErrorType = 0;
        #endregion

        #region Class Properties

        /// <summary>
        /// Obtain the specific SCP error number.
        /// </summary>
        public int SCPErrorNo
        {
            get { return _scpErrorNo; }
            set { _scpErrorNo = value; }
        }

        /// <summary>
        /// Obtain the specific SCP error type.
        /// </summary>
        public int SCPErrorType
        {
            get { return _scpErrorType; }
            set { _scpErrorType = value; }
        }

        #endregion

        #region Class Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SCPCallException()
        {

        }

        /// <summary>
        /// Call Exception with message, error type and error number
        /// </summary>
        /// <param name="message">OSCA message</param>
        /// <param name="errorType">OSCA error type: 0 - No error (NA); 1 - Fatal error; 2 - User error; 3 - Information only</param>
        /// <param name="errorNo">OSCA error code number of message</param>
        public SCPCallException(string message, int errorType, int errorNo) : this(message)
        {
            SCPErrorType = errorType;
            SCPErrorNo   = errorNo;
        }

        /// <summary>
        /// Message parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public SCPCallException(string message) : base(message)
        {
        }

        /// <summary>
        /// Message and inner exception parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public SCPCallException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization stream context.</param>
        public SCPCallException(SerializationInfo info, StreamingContext context) : base(info, context)
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
