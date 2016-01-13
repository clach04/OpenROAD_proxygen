#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Base class for exceptions raised by ProxyGen generated code.
*
* Class : Extends ApplicationException. Base class for all SPC Exceptions.
*
* Class Name : APIException
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : APIException.cs
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
    /// Provides base information for all Exceptions.
    /// </summary>
    [Serializable]
    public class APIException : ApplicationException
    {
        #region Class Fields
        #endregion

        #region Class Properties
        #endregion

        #region Class Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public APIException()
        {

        }

        /// <summary>
        /// Message parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public APIException(string message) : base(message)
        {

        }

        /// <summary>
        /// Message and inner exception parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public APIException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization stream context.</param>
        public APIException(SerializationInfo info, StreamingContext context) : base(info, context)
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
