/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using Newtonsoft.Json;


namespace FlowrouteNumbersAndMessaging.Standard.Models
{
    public class Data61 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string type = "route";
        private Models.Attributes62 attributes;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("type")]
        public string Type 
        { 
            get 
            {
                return this.type; 
            } 
            set 
            {
                this.type = value;
                onPropertyChanged("Type");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("attributes")]
        public Models.Attributes62 Attributes 
        { 
            get 
            {
                return this.attributes; 
            } 
            set 
            {
                this.attributes = value;
                onPropertyChanged("Attributes");
            }
        }
    }
} 