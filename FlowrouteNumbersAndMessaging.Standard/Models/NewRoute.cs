/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using Newtonsoft.Json;


namespace FlowrouteNumbersAndMessaging.Standard.Models
{
    public class NewRoute : BaseModel 
    {
        // These fields hold the values for the public properties.
        private Models.Data61 data;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("data")]
        public Models.Data61 Data 
        { 
            get 
            {
                return this.data; 
            } 
            set 
            {
                this.data = value;
                onPropertyChanged("Data");
            }
        }
    }
} 