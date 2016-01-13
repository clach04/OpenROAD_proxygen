#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Some common error string and values are contained in this file
*               in order to avoid duplicating them in other files.
*
* Class : A set of static constants useful when connecting to the OpenROAD
*         Application Server.
*
* Class Name : Constants
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : Constants.cs
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
using System.Configuration;
#endregion

namespace Luminary.ProxyGen.Util
{
    /// <summary>
    /// All Constants in the API.
    /// </summary>
    public class Constants
    {
        #region Class Fields
        //OpenROAD connection default parameters.
        private const int OR_CONNECT_RETRY_LIMIT_DEFAULT                    = 3;
        private const int OR_CONNECT_RETRY_DELAY_DEFAULT                    = 500;

        /// <summary>
        /// Minimum value for a date when passed between .NET and OpenROAD
        /// </summary>
        public static DateTime OR_MIN_DATE_VALUE                            = new DateTime(1899,12,30);

        /// <summary>
        /// Invalid type parameter messages
        /// </summary>
        public const string INVALID_PARAMETER_EXCEPTION_MESSAGE             = "Invalid Parameter Encountered.";

        /// <summary>
        /// Invalid type exception messages
        /// </summary>
        public const string INVALID_TYPE_EXCEPTION_MESSAGE                  = "Invalid Type Encountered.";
        /// <summary>
        /// General exception messages
        /// </summary>
        public const string GENERAL_ERROR_EXCEPTION_MESSAGE                 = "There was a general error.";

        /// <summary>
        /// Session unavailable exception message
        /// </summary>
        public const string OR_SESSION_UNAVAILABLE_EXCEPTION_MESSAGE
            = "The OpenROAD ASO Session was not provided (null)";

        /// <summary>
        /// Session not connected exception message
        /// </summary>
        public const string OR_SESSION_NOT_CONNECTED_EXCEPTION_MESSAGE
            = "The OpenROAD ASO Session was not connected";

        /// <summary>
        /// Unable to connect exception message
        /// </summary>
        public const string OR_SESSION_CONNECT_EXCEPTION_MESSAGE
            = "Could not connect to OpenROAD ASO with details provided";

        /// <summary>
        /// Invalid AKA name exception message
        /// </summary>
        public const string INVALID_AKA_NAME_EXCEPTION_MESSAGE              = "AKA Name is not valid";

        /// <summary>
        /// Invalid SCP name exception message
        /// </summary>
        public const string INVALID_SCP_NAME_EXCEPTION_MESSAGE
            = "Service Call Procedure Name is not valid";

        /// <summary>
        /// SCP call exception
        /// </summary>
        public const string INVALID_SCP_CALL_EXCEPTION_MESSAGE              = "There was a problem calling the SCP";


        // Parameter Validation Exception Messages.

        // OpenROAD Data Types.
        public const string OR_ASA_DATATYPE_USERCLASS = "USERCLASS";
        public const string OR_ASA_DATATYPE_UCARRAY = "UCARRAY";
        public const string OR_ASA_DATATYPE_STRING = "STRING";
        public const string OR_ASA_DATATYPE_INTEGER = "INTEGER";
        public const string OR_ASA_DATATYPE_SMALL_INTEGER = "SMALLINT";
        public const string OR_ASA_DATATYPE_FLOAT = "FLOAT";
        public const string OR_ASA_DATATYPE_DATE = "DATE";
        public const string OR_ASA_DATATYPE_MONEY = "MONEY";

        // MetaData API Call Exception Messages.
        internal const string METADATA_POPULATE_EXCEPTION_MESSAGE           = "Could not get interface metadata";

        public const string YES_SHORT = "Y";
        public const string NO_SHORT = "N";
        #endregion


        #region Class Properties
        /// <summary>
        /// The limit of connection attempts to the OpenROAD Application Server.
        /// </summary>
        public static int ConnectRetryLimit
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["ConnectRetryLimit"]);
                }
                catch
                {
                    //Couldn't find a specified value so default.
                    return OR_CONNECT_RETRY_LIMIT_DEFAULT;
                }
            }
        }

        /// <summary>
    /// The amount of time (in ms) to wait between OpenROAD Application Server
        /// Connection Attempts.
        /// </summary>
        public static int ConnectRetryDelay
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["ConnectRetryDelay"]);
                }
                catch
                {
                    //Couldn't find a specified value so default.
                    return OR_CONNECT_RETRY_DELAY_DEFAULT;
                }
            }
        }
        #endregion
    }
}

