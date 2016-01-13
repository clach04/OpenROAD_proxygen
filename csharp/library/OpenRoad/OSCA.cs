#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : OSCA is the parameter passed to an OpenROAD SCP which will be
*               populated with any error messages or information.
*
* Class : Static OSCA class to hold common OSCA information.
*
* Class Name : OSCA
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : OSCA.cs
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
using System.Collections.Generic;
using System.Text;
using ORRSOLib;
#endregion

namespace Luminary.ProxyGen.Util
{
    public static class OSCA
    {
        #region Class Properties
        private static int contextId;
        private static int errorType;
        private static string messageText;
        private static int errorNumber;
        private static bool isEmpty;

        /// <summary>
        /// True if the OSCA has been used before i.e. has its contextId set
        /// </summary>
        public static bool IsEmpty
        {
            get
            {
                return OSCA.isEmpty;
            }
            set
            {
                OSCA.isEmpty = value;
            }
        }

        /// <summary>
        /// Context ID of the OpenROAD application server session.
        /// </summary>
        public static int ContextId
        {
            get
            {
                return contextId;
            }
            set
            {
                 contextId = value;
            }
        }

        /// <summary>
        /// Message text passed back from the  OpenROAD application server session.
        /// </summary>
        public static string MessageText
        {
            get
            {
                return messageText;
            }
            set
            {
                messageText = value;
            }
        }

        /// <summary>
        /// Error number passed back from the  OpenROAD application server session.
        /// </summary>
        public static int ErrorNumber
        {
            get
            {
                return errorNumber;
            }
            set
            {
                errorNumber = value;
            }
        }

        /// <summary>
        /// Error number passed back from the  OpenROAD application server session.
        /// </summary>
        public static int ErrorType
        {
            get
            {
                return errorType;
            }
            set
            {
                errorType = value;
            }
        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Populates itself based on the OSCA parameters in the ByRefPDO object
        /// </summary>
        /// <param name="byRefPDO"></param>
        public static void PopulateSelfFromByRef(ORPDOClass byRefPDO)
        {
            //Extract the OSCA parameters from the ByRef Class

            if (null != byRefPDO)
            {
                contextId = (int)byRefPDO.GetAttribute("b_osca.i_context_id");
                errorNumber = (int)byRefPDO.GetAttribute("b_osca.i_error_no");
                errorType = (int)byRefPDO.GetAttribute("b_osca.i_error_type");
                messageText = (string)byRefPDO.GetAttribute("b_osca.v_msg_txt");
                isEmpty = false;
            }
        }

        /// <summary>
        /// Initialise the OSCA class to default values.
        /// </summary>
        public static void Initialise()
        {
            contextId = 0;
            errorNumber = 0;
            errorType = 0;
            messageText = string.Empty;
            isEmpty = true;
        }

        #endregion
    }
}
