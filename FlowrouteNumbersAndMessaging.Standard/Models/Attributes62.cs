/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using FlowrouteNumbersAndMessaging.Standard;
using FlowrouteNumbersAndMessaging.Standard.Utilities;


namespace FlowrouteNumbersAndMessaging.Standard.Models
{
    public class Attributes62 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string malias;
        private Models.RouteTypeEnum routeType = Models.RouteTypeEnum.SIPREG;
        private string mvalue;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("alias")]
        public string Alias 
        { 
            get 
            {
                return this.malias; 
            } 
            set 
            {
                this.malias = value;
                onPropertyChanged("Alias");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("route_type", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.RouteTypeEnum RouteType 
        { 
            get 
            {
                return this.routeType; 
            } 
            set 
            {
                this.routeType = value;
                onPropertyChanged("RouteType");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("value")]
        public string Value 
        { 
            get 
            {
                return this.mvalue; 
            } 
            set 
            {
                this.mvalue = value;
                onPropertyChanged("Value");
            }
        }
    }
} 