#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Contains the logic for connecting to and disconnecting from an
*               OpenROAD application server.
*
* Class : Base class for fecades to all OpenROAD applications
*
* Class Name : BaseFacade
*
* System Name : ProxyGen
*
* Sub-System Name : C# Template Code
*
* File Name : BaseFacade.cs
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
using System.Data;
using System.Threading;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Xml;
using ORRSOLib;
#endregion

namespace Luminary.ProxyGen.Util
{
    /// <summary>
    /// Base for all all OpenGalaxy API call facades.
    /// </summary>
    public abstract class BaseFacade
    {
        #region Class Fields
        private ORASOSessionClass orSession;
        private string akaName;
        private string imageName;
        private string location;
        private string routing;
        private string flags;
        private bool alreadyConnected;
        private ConnectionTypes connectionType;


        #endregion


        #region Class Properties

        /// <summary>
        /// Image name property.
        /// </summary>
        public string ImageName
        {
            get
            {
                return akaName + ".img";
            }
            set
            {
                imageName = value;
            }
        }

        /// <summary>
        /// Application flags for RSO connection
        /// </summary>
        public string Flags
        {
            get
            {
                return flags;
            }
            set
            {
                flags = value;
            }
        }

        /// <summary>
        /// The OpenROAD remote server object
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
        /// The AKA name of the OpenROAD remote server object.
        /// </summary>
        public string AKAName
        {
            get
            {
                return akaName;
            }
            set
            {
                akaName = value;
            }
        }

        /// <summary>
        /// The location of the OpenROAD remote server object.
        /// </summary>
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        /// <summary>
        /// The routing of the OpenROAD remote server object.
        /// </summary>
        public string Routing
        {
            get
            {
                return routing;
            }
            set
            {
                routing = value;
            }
        }
        public ConnectionTypes ConnectionType
        {
            get
            {
                return connectionType;
            }
            set
            {
                connectionType = value;
            }
        }
        #endregion


        #region Class Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseFacade()
        {
            InitialiseClass();
            ORSession = new ORASOSessionClass();
        }

        /// <summary>
        /// Established OpenROAD remote server object constructor.
        /// </summary>
        /// <param name="orSession">The already established OpenROAD remote server object.</param>
        public BaseFacade(ORASOSessionClass orSession)
        {
            //Validate - must be instantiated and connected.
            if (orSession == null)
            {
                throw new SCPConnectException(Constants.OR_SESSION_UNAVAILABLE_EXCEPTION_MESSAGE);
            }

            if (orSession.IsConnected == 0)
            {
                throw new SCPConnectException(Constants.OR_SESSION_NOT_CONNECTED_EXCEPTION_MESSAGE);
            }

            // Initialise the class
            InitialiseClass();

            //OK if we got here so set the variables.
            ORSession = orSession;
            alreadyConnected = true;
        }

        /// <summary>
        /// Manual connect constructor.
        /// </summary>
        /// <param name="akaName">The AKA name of the OpenROAD remote server object.</param>
        /// <param name="location">The location of the OpenROAD remote server object.</param>
        /// <param name="routing">The routing of the OpenROAD remote server object.</param>
        public BaseFacade(string akaName, string location, string routing, string flags, ConnectionTypes connectionType)
            : this(akaName, location, routing, flags, connectionType, false)
        {
        }

        /// <summary>
        /// Manual connect constructor.
        /// </summary>
        /// <param name="akaName">The AKA name of the OpenROAD remote server object.</param>
        /// <param name="location">The Location of the OpenROAD Remote Server Object.</param>
        /// <param name="routing">The Routing of the OpenROAD Remote Server Object.</param>
        /// <param name="keepConnected"></param>
        public BaseFacade(string akaName, string location, string routing, string flags, ConnectionTypes connectionType, bool keepConnected)
        {
            //Validate - AKA Name is mandatory.
            if (akaName == null || akaName == String.Empty)
            {
                throw new SCPConnectException(Constants.INVALID_AKA_NAME_EXCEPTION_MESSAGE);
            }

            InitialiseClass();

            if (location == null)
            {
                location = System.Environment.MachineName;
            }

            if (routing == null)
            {
                routing = String.Empty;
            }

            AKAName     = akaName;
            Location    = location;
            Routing     = routing;
            Flags       = flags;
            ConnectionType = connectionType;

            ORSession   = new ORASOSessionClass();

            alreadyConnected = keepConnected;

            //We now have enough info for a connect;
            Connect();
        }
        #endregion


        #region Class Methods

        /// <summary>
        /// Initialise the class variables
        /// </summary>
        protected virtual void InitialiseClass()
        {
            ORSession           = null;
            AKAName             = null;
            Location            = null;
            Routing             = null;
            alreadyConnected    = false;
        }

        /// <summary>
        /// Connect the OpenROAD session to the application server.
        /// </summary>
        public void Connect()
        {
            if (this.connectionType == ConnectionTypes.ASO)
                ORConnectASO();

            if (this.connectionType == ConnectionTypes.RSO)
                ORConnectRSO();

        }

        /// <summary>
        /// Disconnect the OpenROAD session from the application server, if required.
        /// </summary>
        public void Disconnect()
        {
            ORDisconnect();
            alreadyConnected = false;
        }

        #endregion


        #region Class Destructors
        /// <summary>
        /// Ensure free up unmanaged resources.
        /// </summary>
        ~BaseFacade()
        {
            if (!alreadyConnected)
            {
                Disconnect();
            }
        }
        #endregion


        #region Private methods


        /// <summary>
        /// Connect to the application server using the RSO method.
        /// </summary>
        private void ORConnectRSO()
        {
            //Ensure we have a Session.
            if (ORSession == null)
            {
                throw new SCPInvalidArgumentException(Constants.OR_SESSION_UNAVAILABLE_EXCEPTION_MESSAGE);
            }

            //If not connected then attempt to connect.
            if (ORSession.IsConnected == 0)
            {
                if (ImageName == null || ImageName.Length == 0)
                {
                    throw new SCPInvalidArgumentException(Constants.INVALID_AKA_NAME_EXCEPTION_MESSAGE);
                }

                //If location not provided then default to current machine.
                if (Location == null || Location.Length == 0)
                {
                    Location = System.Environment.MachineName;
                }

                //If routing not provided then default to empty string.
                if (Routing == null || Routing.Length == 0)
                {
                    Routing = "";
                }

                try
                {
                    // Find host by name
                    IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());

                    // Enumerate IP addresses
                    string ipAddress = "";
                    foreach (IPAddress ipaddress in iphostentry.AddressList)
                    {
                        ipAddress = ipaddress.ToString();
                    }

                    // Create OR ASO Session
                    ORRSOClass rso = new ORRSOClass();
                    ORPDOClass byVal = new ORPDOClass();
                    ORPDOClass byRef = new ORPDOClass();

                    ORSession.v_user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    ORSession.v_ip_address = ipAddress;
                    ORSession.i_user_id = -1;

                    object options = "0";
                    rso.UseASOLib = 1;
                    rso.Initiate(AKAName, Flags, Location, Routing, 0, ref options);

                    object remoteServer = rso;
                    ORSession.AttachRSO(ref remoteServer);
                }
                catch (Exception ex)
                {
                    throw new SCPConnectException(Constants.OR_SESSION_CONNECT_EXCEPTION_MESSAGE, ex);
                }
            }
        }

        /// <summary>
        /// Connect the OpenROAD session to the application server.
        /// </summary>
        private void ORConnectASO()
        {
            //Ensure we have a Session.
            if (ORSession == null)
            {
                throw new SCPInvalidArgumentException(Constants.OR_SESSION_UNAVAILABLE_EXCEPTION_MESSAGE);
            }

            //If not connected then attempt to connect.
            if (ORSession.IsConnected == 0)
            {
                //Mandatory connection info.
                if (AKAName == null || AKAName.Length == 0)
                {
                    throw new SCPInvalidArgumentException(Constants.INVALID_AKA_NAME_EXCEPTION_MESSAGE);
                }

                //If location not provided then default to current machine.
                if (Location == null || Location.Length == 0)
                {
                    Location = System.Environment.MachineName;
                }

                //If routing not provided then default to empty string.
                if (Routing == null || Routing.Length == 0)
                {
                    Routing = "";
                }

                try
                {
                    // Find host by name
                    IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());

                    // Enumerate IP addresses
                    string ipAddress = "";
                    foreach(IPAddress ipaddress in iphostentry.AddressList)
                    {
                        ipAddress = ipaddress.ToString();
                    }

                    ORSession.v_user_name   = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    ORSession.v_ip_address  = ipAddress;
                    ORSession.i_user_id     = -1;

                    int retryCount = Constants.ConnectRetryLimit;
                    int retryDelay = Constants.ConnectRetryDelay;

                    // Attempt to connect a number of times
                    while(retryCount-- >= 0 && ORSession.IsConnected != 1)
                    {
                        try
                        {
#if TESTDATA
#else
                            ORSession.Connect(AKAName, Location, Routing);
#endif
                        }
                        catch (Exception ex)
                        {
                            //If reached retry limit then cant do much more.
                            if (retryCount == 0)
                            {
                                throw ex;
                            }

                            Thread.Sleep(retryDelay);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new SCPConnectException(Constants.OR_SESSION_CONNECT_EXCEPTION_MESSAGE, ex);
                }
            }
        }

        /// <summary>
        /// Disconnect the OpenROAD session from the application server, if required.
        /// </summary>
        private void ORDisconnect()
        {
            ORSession.Disconnect();
        }
        #endregion
    }
}
