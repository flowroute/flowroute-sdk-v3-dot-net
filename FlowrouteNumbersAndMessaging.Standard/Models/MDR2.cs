/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using Newtonsoft.Json;


namespace FlowrouteNumbersAndMessaging.Standard.Models
{
    public class MDR2 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private Models.Data data;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("data")]
        public Models.Data Data 
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