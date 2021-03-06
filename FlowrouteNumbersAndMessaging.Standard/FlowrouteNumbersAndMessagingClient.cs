/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using FlowrouteNumbersAndMessaging.Standard.Controllers;
using FlowrouteNumbersAndMessaging.Standard.Http.Client;

namespace FlowrouteNumbersAndMessaging.Standard
{
    public partial class FlowrouteNumbersAndMessagingClient
    {

        /// <summary>
        /// Singleton access to Messages controller
        /// </summary>
        public MessagesController Messages
        {
            get
            {
                return MessagesController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Numbers controller
        /// </summary>
        public NumbersController Numbers
        {
            get
            {
                return NumbersController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Routes controller
        /// </summary>
        public RoutesController Routes
        {
            get
            {
                return RoutesController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to E911 controller
        /// </summary>
        public E911Controller E911s
        {
            get
            {
                return E911Controller.Instance;
            }
        }

        /// <summary>
        /// Singleton access to CNAM controller
        /// </summary>
        public CNAMsController CNAMs
        {
            get
            {
                return CNAMsController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Porting controller
        /// </summary>
        public PortingController Porting
        {
            get
            {
                return PortingController.Instance;
            }
        }

        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }        
        }
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public FlowrouteNumbersAndMessagingClient() { }

        /// <summary>
        /// Client initialization constructor
        /// </summary>
        public FlowrouteNumbersAndMessagingClient(string basicAuthUserName, string basicAuthPassword)
        {
            Configuration.BasicAuthUserName = basicAuthUserName;
            Configuration.BasicAuthPassword = basicAuthPassword;
        }
        #endregion
    }
}