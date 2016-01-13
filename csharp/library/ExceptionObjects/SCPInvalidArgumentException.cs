#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Exception raised when a variable used to call the SCP is invalid
*               e.g. null.
*
* Class : Extends APIException.
*
* Class Name : SCPInvalidArgumentException
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : SCPInvalidArgumentException.cs
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
    /// Provides information for an invalid argument exception.
    /// </summary>
    [Serializable]
    public class SCPInvalidArgumentException : APIException
    {
        #region Class Properties
        #endregion

        #region Class Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SCPInvalidArgumentException()
        {

        }

        /// <summary>
        /// Message parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public SCPInvalidArgumentException(string message) : base(message)
        {

        }

        /// <summary>
        /// Message and invalid parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="typeExpected">The type expected.</param>
        /// <param name="typeEncountered">The type encountered.</param>
        public SCPInvalidArgumentException(string message, string paramName, Type typeExpected, Type typeEncountered) :
            base(message + "Parameter of type " + typeEncountered.ToString() + " when expecting " + typeExpected.ToString())
        {

        }

        /// <summary>
        /// Message and inner exception parameter constructor.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public SCPInvalidArgumentException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization stream context.</param>
        public SCPInvalidArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
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
