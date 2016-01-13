#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Provides logic for SCPWrappers to make calls to SCPs
*
* Class : Base class for all SCPWrappers. A wrapper is generated for each SCP
*         and uses this logic to call SCPs and raise errors as exceptions if the
*         call causes and error in the OpenROAD server.
*
* Class Name : SCPWrapperBase
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : SCPWrapperBase.cs
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
using ORRSOLib;
#endregion

namespace Luminary.ProxyGen.Util
{
    /// <summary>
    /// Base class implementation for the SCPWrapper
    /// </summary>
    public abstract class SCPWrapperBase
    {
        #region Delegate Declarations
        #endregion


        #region Class Fields

        private ORASOSessionClass orSession;
        private ORPDOClass orByValParameter;
        private ORPDOClass orByRefParameter;


        #endregion


        #region Class Properties

        /// <summary>
        /// The SCP name.
        /// </summary>
        protected virtual string SCPName
        {
            get
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// The OpenROAD ASO session.
        /// </summary>
        public ORASOSessionClass ORSession
        {
            get
            {
                return orSession;
            }
            set
            {
                orSession = value;
            }
        }

        /// <summary>
        /// The OpenROAD ASO by value parameter object.
        /// </summary>
        protected ORPDOClass ORByValParameter
        {
            get
            {
                return orByValParameter;
            }
            set
            {
                orByValParameter = value;
            }
        }

        /// <summary>
        /// The OpenROAD aso by reference parameter object.
        /// </summary>
        protected ORPDOClass ORByRefParameter
        {
            get
            {
                return orByRefParameter;
            }
            set
            {
                orByRefParameter = value;
            }
        }

        /// <summary>
        /// Gets the contents of the ByVal parameter descriptions in an array.
        /// </summary>
        protected Array ByValParametersDesc
        {
            get
            {
                if (ORByValParameter != null)
                {
                    Object paramDesc;
                    Object paramVal;
                    ORByValParameter.GetParameters(out paramDesc, out paramVal);

                    return paramDesc as Array;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the contents of the ByVal parameter values in an array.
        /// </summary>
        protected Array ByValParametersVal
        {
            get
            {
                if (ORByValParameter != null)
                {
                    Object paramDesc;
                    Object paramVal;
                    ORByValParameter.GetParameters(out paramDesc, out paramVal);

                    return paramVal as Array;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the contents of the ByRef parameter descriptions in an array.
        /// </summary>
        protected Array ByRefParametersDesc
        {
            get
            {
                if (ORByRefParameter != null)
                {
                    Object paramDesc;
                    Object paramVal;
                    ORByRefParameter.GetParameters(out paramDesc, out paramVal);

                    return paramDesc as Array;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the contents of the ByRef parameter values in an array.
        /// </summary>
        protected Array ByRefParametersVal
        {
            get
            {
                if (ORByRefParameter != null)
                {
                    Object paramDesc;
                    Object paramVal;
                    ORByRefParameter.GetParameters(out paramDesc, out paramVal);

                    return paramVal as Array;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the contents of the SCP error number
        /// </summary>
        protected virtual int SCPErrorNumber
        {
            get
            {
                return ORSession.i_error_no;
            }
        }

        /// <summary>
        /// Gets the contents of the SCP error type
        /// </summary>
        protected virtual int SCPErrorType
        {
            get
            {
                return ORSession.i_error_type;
            }
        }

        /// <summary>
        /// Gets the contents of the SCP error text
        /// </summary>
        protected virtual string SCPErrorText
        {
            get
            {
                return ORSession.v_msg_txt;
            }
        }

        #endregion


        #region Class Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal SCPWrapperBase()
        {
            InitialiseClass();
        }

        /// <summary>
        /// Connected OpenROAD ASO session parameter constructor.
        /// </summary>
        /// <param name="orSession">Connected OpenROAD ASO session.</param>
        public SCPWrapperBase(ORASOSessionClass orSession) :base()
        {
            InitialiseClass();

            // set the OR Session
            ORSession = orSession;
        }



        #endregion


        #region Class Methods
        /// <summary>
        /// Default base class initialiser
        /// </summary>
        protected virtual void InitialiseClass()
        {
        }
        #endregion


        #region Protected Methods
        /// <summary>
        /// Call the SCP.
        /// </summary>
        /// <returns>The result of the SCP.</returns>
        protected virtual void CallSCP()
        {
            try
            {
                // Validate we have everything we need
                Validate();


                // Declare the ByVal and ByRef parameter objects
                DeclareAttributes();

                // Populate the parameter values.
                PopulateAttributes();

                // Call the SCP.
                Object ORByValParameterParam = ORByValParameter;
                Object ORByRefParameterParam = ORByRefParameter;

                CallSCPProcedure(SCPName, ref ORByValParameterParam, ref ORByRefParameterParam);

            }
            catch (SCPInvalidArgumentException)
            {
                // Throw it on.
                throw;
            }
            catch (SCPCallException)
            {
                //rethrow SCPCall Exception
                throw;
            }
            catch (Exception ex)
            {
                //Something went wrong in the call of the SCP - throw it on.
                throw new SCPCallException(ex.Message);
            }
        }

        /// <summary>
        /// Calls the SCP procedure
        /// </summary>
        /// <param name="scpName">SCP Name</param>
        /// <param name="byValObj">By value attributes</param>
        /// <param name="byRefObj">By Ref attributes</param>
        /// <returns>populated SCP response</returns>
        protected virtual void CallSCPProcedure(string scpName, ref Object byValObj, ref Object byRefObj)
        {
            try
            {
                //DePopulate OSCA and add it set the RSO ByRef (but only if it has been set)
                if (!OSCA.IsEmpty)
                    DePopulateOSCAIntoByRefPDO();

                //Cast the RSO as its interface (ORRSO) not (ORRSOClass)
                ORRSO orRSO = (ORRSO)ORSession.RSO;

                //CallProc using RSO.
                orRSO.CallProc(scpName, ref byValObj, ref byRefObj);

                //Always populate OSCA with OSCA from app server.
                OSCA.PopulateSelfFromByRef((ORPDOClass)byRefObj);

                //Check OSCA for error
                if (OSCA.ErrorNumber > 0)
                {
                    throw new SCPCallException(OSCA.MessageText, OSCA.ErrorType, OSCA.ErrorNumber);
                }
            }
            catch (SCPCallException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SCPCallException(ex.Message, ex);
            }

        }

        /// <summary>
        /// Depopulate static OSCA properties into the ByRef
        /// </summary>
        private void DePopulateOSCAIntoByRefPDO()
        {
            SetAttribute("b_osca.i_context_id", OSCA.ContextId);
            SetAttribute("b_osca.i_error_no", OSCA.ErrorNumber);
            SetAttribute("b_osca.i_error_type", OSCA.ErrorType);
            SetAttribute("b_osca.v_msg_txt", OSCA.MessageText);
        }

        /// <summary>
        /// Evaluate if a parameter is null.
        /// </summary>
        /// <param name="attributeName">The attribute to evaluate.</param>
        /// <returns>Wheteher the attribute parameter is null or not.</returns>
        protected bool IsParameterNull( string attributeName)
        {
            return ORByRefParameter.IsNull(attributeName) == 1;
        }

        /// <summary>
        /// Set the attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="val">The value to set.</param>
        protected virtual void SetAttribute(string attributeName, Object val)
        {
            object objVal = val;
            if (val is DateTime)
            {
                // Convert Date & Time to UTC format as OpenROAD expects them in this format
                objVal = ((DateTime)val).ToUniversalTime();
            }

            ORByRefParameter.SetAttribute(attributeName, ref val);

        }

        /// <summary>
        /// Declare an individual userclass attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareUserClassAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_USERCLASS);
        }

        /// <summary>
        /// Declare an individual array attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareArrayAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_UCARRAY);
        }

        /// <summary>
        /// Declare an individual string attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareStringAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_STRING);
        }

        /// <summary>
        /// Declare an individual small integer attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareSmallIntegerAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_SMALL_INTEGER);
        }

        /// <summary>
        /// Declare an boolean attribute
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareBooleanAttribute(string attributeName)
        {
            // Call underlying private method - a boolean is internally represented by a small integer
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_SMALL_INTEGER);
        }


        /// <summary>
        /// Declare an individual integer attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareIntegerAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_INTEGER);
        }

        /// <summary>
        /// Declare an individual float attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareFloatAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_FLOAT);
        }

        /// <summary>
        /// Declare and individial money attribute.
        /// </summary>
        /// <param name="attributeName"></param>
        protected void DeclareMoneyAttribute(string attributeName)
        {
            // Call underlying private method
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_MONEY);
        }


        /// <summary>
        /// Declare an individual date attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        protected void DeclareDateAttribute(string attributeName)
        {
            // call delegate
            DeclareAttribute(attributeName, Constants.OR_ASA_DATATYPE_DATE);
        }

        /// <summary>
        /// Get small integer attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the openroad parameter.</returns>
        protected short GetSmallIntegerAttribute(string attributeName)
        {
            // Call underlying private method
            return (short) GetAttribute(attributeName);
        }

        /// <summary>
        /// Get integer attribute out of the ByRef parameter object with default if null.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="defaultIfNull">The value to return if null encountered.</param>
        /// <returns>The value from the OpenROAD parameter; default value if null.</returns>
        protected short GetSmallIntegerAttribute(string attributeName, short defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            //If the value returned is null then return the amount specified.
            return obj is System.DBNull || obj == null ? defaultIfNull : (short) obj;
        }

        /// <summary>
        /// Get integer attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="useByValParameter">Flag to indicate which PDO to use.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        protected int GetIntegerAttribute(string attributeName)
        {
            // Call underlying private method
            return (int) GetAttribute(attributeName);
        }

        /// <summary>
        /// Get integer attribute out of the ByRef parameter object with default if null.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="defaultIfNull">The value to return if null encountered.</param>
        /// <returns>The value from the OpenROAD parameter; default value if null.</returns>
        protected int GetIntegerAttribute(bool useByValParameter, string attributeName, int defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            //If the value returned is null then return the amount specified.
            return obj is System.DBNull || obj == null ? defaultIfNull : (int) obj;
        }

        /// <summary>
        /// Get string attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        protected string GetStringAttribute(string attributeName)
        {
            // Call underlying private method
            return (string) GetAttribute(attributeName);
        }

        /// <summary>
        /// Get string attribute out of the ByRef parameter object with default if null.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="defaultIfNull">The value to return if null encountered.</param>
        /// <returns>The value from the OpenROAD parameter; default value if null.</returns>
        protected string GetStringAttribute(string attributeName, string defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            //If the value returned is null then return the amount specified.
            return obj is System.DBNull || obj == null ? defaultIfNull : (string) obj;
        }

        /// <summary>
        /// Get boolean attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        protected bool GetBooleanAttribute(string attributeName)
        {
            return Convert.ToInt16(GetAttribute(attributeName)) == 1;
        }

        /// <summary>
        /// Get boolean attribute out of the ByRef parameter object with default if null.
        /// </summary>
         /// <param name="attributeName">The attribute name.</param>
        /// <param name="defaultIfNull">The value to return if null encountered.</param>
        /// <returns>The value from the OpenROAD parameter; default value if null.</returns>
        protected bool GetBooleanAttribute(string attributeName, bool defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            //If the value returned is null then return the amount specified.
            return obj is System.DBNull || obj == null ? defaultIfNull : Convert.ToInt16(obj) == 1;
        }

        /// <summary>
        /// Gets decimal attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        protected decimal GetDecimalAttribute(string attributeName)
        {
            // Call underlying private method
            return (decimal)GetAttribute(attributeName);
        }

        /// <summary>
        /// Get decimal attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="defaultIfNull"></param>
        /// <returns></returns>
        protected decimal GetDecimalAttribute(string attributeName, decimal defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            //If the value returned is null then return the amount specified.
            return obj is System.DBNull || obj == null ? defaultIfNull : (decimal)obj;
        }

        /// <summary>
        /// Get double attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The value from the OpenROAD parameter.</returns>
        protected double GetDoubleAttribute(string attributeName)
        {
            // Call underlying private method
            return (double) GetAttribute(attributeName);
        }

        /// <summary>
        /// Get double attribute out of the ByRef parameter object with default if null.
        /// </summary>
        /// <param name="attributeName">The Attribute Name.</param>
        /// <param name="defaultIfNull">The value to return if null encountered.</param>
        /// <returns>The value from the OpenROAD parameter; default value if null.</returns>
        protected double GetDoubleAttribute(string attributeName, double defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            //If the value returned is null then return the amount specified.
            return obj is System.DBNull || obj == null ? defaultIfNull : (double) obj;
        }

        /// <summary>
        /// Get date attribute out of the ByRef parameter object.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The date value from the OpenROAD parameter.</returns>
        protected DateTime GetDateAttribute(string attributeName)
        {
            // Call underlying private method
            // DateTime dtm = (DateTime) ;
            object oDtm = GetAttribute(attributeName);
            DateTime dtm = Constants.OR_MIN_DATE_VALUE.Date;

            //If the attribute is of type DateTime, do a direct cast.
            if (oDtm is DateTime)
            {
                dtm = (DateTime) oDtm;
            }
            else
            {
                //otherwise, get the string representation and use TryParse.
                DateTime.TryParse((string)GetAttribute(attributeName), out dtm);
            }

            // Convert the time to co-ordinated local time
            dtm = dtm.ToLocalTime();

            // Perform the magic on the date conversion to prevent problems moving between OpenROAD and .NET
            // they have difference min value dates;
            if (dtm.Date  == Constants.OR_MIN_DATE_VALUE.Date)
            {
                dtm = DateTime.MinValue;
            }

            return dtm;
        }

        /// <summary>
        /// Get date attribute out of the ByRef parameter object with default if null.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="defaultIfNull">The value to return if null encountered.</param>
        /// <returns>The value from the OpenROAD parameter; default value if null.</returns>
        protected DateTime GetDateAttribute(string attributeName, DateTime defaultIfNull)
        {
            // Call underlying private method
            object obj = GetAttribute(attributeName);

            // If the value returned is null then return the amount specified.
            if (obj == null || obj is System.DBNull)
            {
                return defaultIfNull;
            }

            // Can get empty string back as a date so check for this.
            string emptyDateTest = obj as string;
            if (emptyDateTest != null && emptyDateTest == String.Empty)
            {
                return defaultIfNull;
            }

            // Convert the time to co-ordinated local time
            DateTime dtm = ((DateTime)obj).ToLocalTime();

            // Perform the magic on the date conversion to prevent problems moving between OpenROAD and .NET
            // they have difference min value dates;
            if (dtm.Date == Constants.OR_MIN_DATE_VALUE.Date)
            {
                dtm = DateTime.MinValue;
            }
            return dtm;
        }


        /// <summary>
        /// Convert date to OpenROAD string format (dd.mm.ccyy 00:00:00).
        /// </summary>
        /// <param name="dateToConvert">The date to convert.</param>
        /// <returns>The string representation of the date.</returns>
        protected string ToOpenROADString(DateTime dateToConvert)
        {
            return dateToConvert.ToString("dd.MM.yyyy HHmmss");
        }

        #endregion


        #region Virtual Overridable methods


        /// <summary>
        /// Validate parameters.
        /// </summary>
        protected virtual void Validate()
        {
            // By this stage the ASO Session must be instantiated and connected.
            if (ORSession == null)
            {
                throw new SCPInvalidArgumentException(Constants.OR_SESSION_UNAVAILABLE_EXCEPTION_MESSAGE);
            }
            if (ORSession.IsConnected == 0)
            {
                throw new SCPInvalidArgumentException(Constants.OR_SESSION_NOT_CONNECTED_EXCEPTION_MESSAGE);
            }

            // The SCP Name must be provided.
            if (SCPName == null || SCPName == String.Empty)
            {
                throw new SCPInvalidArgumentException(Constants.INVALID_SCP_NAME_EXCEPTION_MESSAGE);
            }
        }

        /// <summary>
        /// Declare attribute parameters.
        /// </summary>
        protected virtual void DeclareAttributes()
        {

            // Declare the PDO's
            orByValParameter = new ORPDOClass();
            orByRefParameter = new ORPDOClass();

            //Declare OSCA
            orByRefParameter.DeclareAttribute("b_osca", Constants.OR_ASA_DATATYPE_USERCLASS);
            orByRefParameter.DeclareAttribute("b_osca.i_context_id", Constants.OR_ASA_DATATYPE_INTEGER);
            orByRefParameter.DeclareAttribute("b_osca.i_error_no", Constants.OR_ASA_DATATYPE_INTEGER);
            orByRefParameter.DeclareAttribute("b_osca.i_error_type", Constants.OR_ASA_DATATYPE_INTEGER);
            orByRefParameter.DeclareAttribute("b_osca.v_msg_txt", Constants.OR_ASA_DATATYPE_STRING);
        }

        /// <summary>
        /// Populate the attributes.
        /// </summary>
        protected virtual void PopulateAttributes()
        {
        }

        #endregion


        #region Helper Methods

        #region Private Member methods
        /// <summary>
        /// The underlying delegate method to declare an individual attribute.
        /// </summary>
        /// <param name="attributeName">The Attribute Name.</param>
        /// <param name="attributeType">The Attribute Type.</param>
        protected virtual void DeclareAttribute(string attributeName, string attributeType)
        {
            AttributeManager.DeclareAttribute(orByRefParameter, attributeName, attributeType);
        }

        /// <summary>
        /// The underlying delegate method to get attribute value
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The attribute value.</returns>
        protected virtual object GetAttribute(string attributeName)
        {
            object rtn;

            rtn = AttributeManager.GetAttribute(orByRefParameter, attributeName);

            return rtn;
        }
        /// <summary>
        /// Return the number of rows in an OpenROAD byref parameter object array.
        /// </summary>
        /// <param name="arrayName">The fully qualified name of the array in the PDO.</param>
        /// <returns>The number of rows (not zero based).</returns>
        protected virtual int GetLastRow(string arrayName)
        {
            return ORByRefParameter.LastRow(arrayName);
        }

        #endregion

        #endregion
    }
}
