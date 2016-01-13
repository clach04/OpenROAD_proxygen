#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Functions to help get, set and declare values on a PDO.
*
* Class : Used to set and retrieve values on a PDO and translate them between
*         OpenROAD and C#.
*
* Class Name : AttributeManager
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : AttributeManager.cs
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
    public sealed class AttributeManager
    {
        #region Set and Declare Methods
        /// <summary>
        /// Set an attribute on a PDO.
        /// </summary>
        /// <param name="pdo"></param>
        /// <param name="attributeName"></param>
        /// <param name="val"></param>
        public static void SetAttribute(ORPDOClass pdo, string attributeName, object val)
        {
            object objVal = val;
            if (val is DateTime)
            {
                // Convert Date & Time to UTC format as OpenROAD expects them in this format
                objVal = ((DateTime)val).ToUniversalTime();
            }

            pdo.SetAttribute(attributeName, ref val);
        }

        /// <summary>
        /// Declare an attribute on a PDO.
        /// </summary>
        /// <param name="pdo"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeType"></param>
        public static void DeclareAttribute(ORPDOClass pdo, string attributeName, string attributeType)
        {
            pdo.DeclareAttribute(attributeName, attributeType);
        }

        #endregion

        #region Retrieve Methods

        /// <summary>
        /// Get integer attribute out of the byref parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        public static int GetIntegerAttribute(ORPDOClass pdo, string attributeName)
        {
            // Call underlying private method
            return (int)GetAttribute(pdo, attributeName);
        }

        /// <summary>
        /// Get string attribute out of the byref parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        public static string GetStringAttribute(ORPDOClass pdo, string attributeName)
        {
            // Call underlying private method
            return (string)GetAttribute(pdo, attributeName);
        }

        /// <summary>
        /// Get boolean attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        public static bool GetBooleanAttribute(ORPDOClass pdo, string attributeName)
        {
            return Convert.ToInt16(GetAttribute(pdo, attributeName)) == 1;
        }
        /// <summary>
        /// Get short attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        public static Int16 GetShortAttribute(ORPDOClass pdo, string attributeName)
        {
            return Convert.ToInt16(GetAttribute(pdo, attributeName));
        }

        /// <summary>
        /// Gets decimal attribute out of the byref parameter object.
        /// </summary>
        /// <param name="useByValParameter"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static decimal GetDecimalAttribute(ORPDOClass pdo, string attributeName)
        {
            // Call underlying private method
            return (decimal)GetAttribute(pdo, attributeName);
        }

        /// <summary>
        /// Get double attribute out of the byref parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        public static double GetDoubleAttribute(ORPDOClass pdo, string attributeName)
        {
            // Call underlying private method
            return (double)GetAttribute(pdo, attributeName);
        }

        /// <summary>
        /// Get date attribute out of the byref parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The date value from the OpenROAD parameter.</returns>
        public static DateTime GetDateAttribute(ORPDOClass pdo, string attributeName)
        {
            // Call underlying private method
            // DateTime dtm = (DateTime) ;
            object oDtm = GetAttribute(pdo, attributeName);
            DateTime dtm = Constants.OR_MIN_DATE_VALUE.Date;

            //If the attribute is of type DateTime, do a direct cast.
            if (oDtm is DateTime)
            {
                dtm = (DateTime)oDtm;
            }
            else
            {
                //otherwise, get the string representation and use TryParse.
                DateTime.TryParse((string)GetAttribute(pdo, attributeName), out dtm);
            }

            // Convert the time to co-ordinated local time
            dtm = dtm.ToLocalTime();

            // Perform the magic on the date conversion to prevent problems moving between OpenROAD and .NET
            // they have difference min value dates;
            if (dtm.Date == Constants.OR_MIN_DATE_VALUE.Date)
            {
                dtm = DateTime.MinValue;
            }

            return dtm;
        }

        /// <summary>
        /// The underlying delegate method to get Attribute value
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The attribute value.</returns>
        public static object GetAttribute(ORPDOClass pdo, string attributeName)
        {
            object rtn;

            rtn = pdo.GetAttribute(attributeName);

            return rtn;
        }

        #endregion
    }
}

