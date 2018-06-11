/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System.Collections.Generic;
using Newtonsoft.Json;


namespace FlowrouteNumbersAndMessaging.Standard.Models
{
    public class Message : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string mfrom;
        private string to;
        private string body;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("from")]
        public string From 
        { 
            get 
            {
                return this.mfrom; 
            } 
            set 
            {
                this.mfrom = value;
                onPropertyChanged("From");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("to")]
        public string To 
        { 
            get 
            {
                return this.to; 
            } 
            set 
            {
                this.to = value;
                onPropertyChanged("To");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("body")]
        public string Body 
        { 
            get 
            {
                return this.body; 
            } 
            set 
            {
                this.body = value;
                onPropertyChanged("Body");
            }
        }
    }

    public class MMS_Message : BaseModel
    {
        // These fields hold the values for the public properties.
        private string mfrom;
        private string to;
        private string body;
        private List<string> mediaUrls;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("from")]
        public string From
        {
            get
            {
                return this.mfrom;
            }
            set
            {
                this.mfrom = value;
                onPropertyChanged("From");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("to")]
        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                this.to = value;
                onPropertyChanged("To");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("body")]
        public string Body
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;
                onPropertyChanged("Body");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("media_urls")]
        public List<string> MediaUrls 
        { 
            get 
            {
                return this.mediaUrls; 
            } 
            set 
            {
                this.mediaUrls = value;
                onPropertyChanged("MediaUrls");
            }
        }

    }

} 