/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System.Collections.Generic;
using Newtonsoft.Json;


namespace FlowrouteNumbersAndMessaging.Standard.Models
{
    public class E911 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string m_id;
        private string m_label;
        private string m_first_name;
        private string m_last_name;
        private string m_street_number;
        private string m_street_name;
        private string m_address_number;
        private string m_address_type_number;
        private string m_address_type;
        private string m_city;
        private string m_state;
        private string m_country;
        private string m_zip;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("id")]
        public string Id 
        { 
            get 
            {
                return this.m_id; 
            } 
            set
            {
                this.m_id = value;
                onPropertyChanged("id");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { 
            get 
            {
                return this.m_label; 
            } 
            set 
            {
                this.m_label= value;
                onPropertyChanged("label");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName
        { 
            get 
            {
                return this.m_first_name; 
            } 
            set 
            {
                this.m_first_name = value;
                onPropertyChanged("first_name");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName
        {
            get
            {
                return this.m_last_name;
            }
            set
            {
                this.m_last_name = value;
                onPropertyChanged("last_name");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("street_number")]
        public string StreetNumber
        {
            get
            {
                return this.m_street_number;
            }
            set
            {
                this.m_street_number = value;
                onPropertyChanged("street_number");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("street_name")]
        public string StreetName
        {
            get
            {
                return this.m_street_name;
            }
            set
            {
                this.m_street_name = value;
                onPropertyChanged("street_name");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("address_number")]
        public string AdressNumber
        {
            get
            {
                return this.m_address_number;
            }
            set
            {
                this.m_address_number = value;
                onPropertyChanged("address_number");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("address_type")]
        public string AddressType
        {
            get
            {
                return this.m_address_type;
            }
            set
            {
                this.m_address_type = value;
                onPropertyChanged("address_type");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("address_type_number")]
        public string AddressTypeNumber
        {
            get
            {
                return this.m_address_type_number;
            }
            set
            {
                this.m_address_type_number = value;
                onPropertyChanged("address_type_number");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("city")]
        public string City
        {
            get
            {
                return this.m_city;
            }
            set
            {
                this.m_city = value;
                onPropertyChanged("city");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("state")]
        public string State
        {
            get
            {
                return this.m_state;
            }
            set
            {
                this.m_state = value;
                onPropertyChanged("state");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("country")]
        public string Country
        {
            get
            {
                return this.m_country;
            }
            set
            {
                this.m_country = value;
                onPropertyChanged("country");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("zip")]
        public string Zip
        {
            get
            {
                return this.m_zip;
            }
            set
            {
                this.m_zip = value;
                onPropertyChanged("zip");
            }
        }
    }
} 