/*
 * FlowrouteNumbersAndMessaging.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlowrouteNumbersAndMessaging.Standard.Utilities;
using FlowrouteNumbersAndMessaging.Standard.Http.Request;
using FlowrouteNumbersAndMessaging.Standard.Http.Response;
using FlowrouteNumbersAndMessaging.Standard.Http.Client;
using FlowrouteNumbersAndMessaging.Standard.Exceptions;

namespace FlowrouteNumbersAndMessaging.Standard.Controllers
{
    public partial class CNAMsController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static CNAMsController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static CNAMsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new CNAMsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern
        /// <summary>
        /// Returns a list of all CNAM Records currently on your Flowroute account. 
        /// </summary>
        /// <param name="startsWith">Optional parameter: Retrieves records that start with the specified value.</param>
        /// <param name="endsWith">Optional parameter: Retrieves records that end with the specified value.</param>
        /// <param name="contains">Optional parameter: Retrieves records containing the specified value.</param>
        /// <param name="is_approved">Optional parameter: If set to 'true', only return approved records.</param>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 records and you entered 1 as your offset value, then only 3 of your records will be displayed in the response.</param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic GetAccountCNAMS(
                string startsWith = null,
                string endsWith = null,
                string contains = null,
                bool is_approved = true,
                int limit = 10,
                int offset = 0)
        {
            Task<dynamic> t = GetAccountCNAMSAsync(startsWith, endsWith, contains, is_approved, limit, offset);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of all CNAM Records currently on your Flowroute account. 
        /// </summary>
        /// <param name="startsWith">Optional parameter: Retrieves records that start with the specified value.</param>
        /// <param name="endsWith">Optional parameter: Retrieves records that end with the specified value.</param>
        /// <param name="contains">Optional parameter: Retrieves records containing the specified value.</param>
        /// <param name="is_approved">Optional parameter: If set to 'true', only return approved records.</param>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 records and you entered 1 as your offset value, then only 3 of your records will be displayed in the response.</param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> GetAccountCNAMSAsync(
                string startsWith = null,
                string endsWith = null,
                string contains = null,
                bool is_approved = true,
                int limit = 10,
                int offset = 0)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cnams");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "starts_with", startsWith },
                { "ends_with", endsWith },
                { "contains", contains },
                { "is_approved", is_approved},
                { "limit", limit },
                { "offset", offset }
            }, ArrayDeserializationFormat, ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Lists all of the information associated with any of the CNAM Records in your account.
        /// </summary>
        /// <param name="id">Required parameter: CNAM Record to search for.</param>
        /// <return>Returns the response from the API call</return>
        public dynamic GetCNAMDetails(string id)
        {
            Task<dynamic> t = GetCNAMDetailsAsync(id);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists all of the information associated with any of the CNAM Records in your account.
        /// </summary>
        /// <param name="id">Required parameter: CNAM Record to search for.</param>
        /// <return>Returns the response from the API call</return>
        public async Task<dynamic> GetCNAMDetailsAsync(string id)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cnams/{id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "id", id }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new APIException(@"Unauthorized", _context);

            if (_response.StatusCode == 404)
                throw new APIException(@"Not Found", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Use this to create a cnam record in your account.
        /// </summary>
        /// <param name="cnam_value">Required parameter: The text for the CNAM Entry.</param>
        /// <return>Returns the string response from the API call</return>
        public string CreateCNAM(string cnam_value)
        {
            Task<string> t = CreateCNAMAsync(cnam_value);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this to create a cnam record in your account.
        /// </summary>
        /// <param name="cnam_value">Required parameter: The text for the CNAM Entry.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> CreateCNAMAsync(string cnam_value)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cnams");

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = "{\"value\": \"";
            _body += cnam_value;
            _body += "\"}}";
            Console.WriteLine("Passing body " + _body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            if (_response.StatusCode == 403)
                throw new ErrorException(@"Insufficient funds to perform this operation.", _context);

            if (_response.StatusCode == 422)
                throw new ErrorException(@"A record with that value already exists.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return _response.Body;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Use this endpoint to associate a CNAM record with a DID.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to which the failover route for voice will be assigned.</param>
        /// <param name="cnamID">Required parameter: The failover route to be assigned.</param>
        /// <return>Returns the string response from the API call</return>
        public string AssociateCNAM(string numberId, string cnamId)
        {
            Task<string> t = AssociateCNAMAsync(numberId, cnamId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this endpoint to update the failover voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to which the failover route for voice will be assigned.</param>
        /// <param name="cnamId">Required parameter: The failover route to be assigned.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> AssociateCNAMAsync(string numberId, string cnamId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{number_id}/relationships/cnam/{cnam_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "number_id", numberId},
                {  "cnam_id", cnamId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "text/plain; charset=utf-8" }
            };


            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PatchBody(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            if (_response.StatusCode == 403)
                throw new ErrorException(@"Insufficient funds to perform this operation.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return _response.Body;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Use this endpoint to remoe a CNAM association from a DID.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to work with.</param>
        /// <return>Returns the string response from the API call</return>
        public string UnassociateCNAM(string numberId)
        {
            Task<string> t = UnassociateCNAMAsync(numberId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this endpoint to remoe a CNAM association from a DID.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to work with.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> UnassociateCNAMAsync(string numberId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{number_id}/relationships/cnam");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "number_id", numberId}
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "text/plain; charset=utf-8" }
            };


            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return _response.Body;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Use this endpoint to remove CNAM record.
        /// </summary>
        /// <param name="cnamId">Required parameter: The id of the CNAM record to remove.</param>
        /// <return>Returns the string response from the API call</return>
        public string DeleteCNAM(string cnamId)
        {
            Task<string> t = DeleteCNAMAsync(cnamId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this endpoint to remove CNAM record.
        /// </summary>
        /// <param name="cnamId">Required parameter: The id of the CNAM record to remove.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> DeleteCNAMAsync(string cnamId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/cnams/{cnam_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "cnam_id", cnamId}
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "text/plain; charset=utf-8" }
            };


            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return _response.Body;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }
    }
} 