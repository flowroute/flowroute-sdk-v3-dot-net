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
        /// Returns a list of your inbound routes. From the list, you can then select routes to use as the primary and failover routes for a phone number, which you can do via "Update Primary Voice Route for a Phone Number" and "Update Failover Voice Route for a Phone Number".
        /// </summary>
        /// <param name="limit">Optional parameter: Limits the number of routes to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of routes by your specified value. For example, if you have 4 inbound routes and you entered 1 as your offset value, then only 3 of your routes will be displayed in the response.</param>
        /// <return>Returns the void response from the API call</return>
        public dynamic ListInboundRoutes(int? limit = null, int? offset = null)
        {
            Task<dynamic> t = ListInboundRoutesAsync(limit, offset);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of your inbound routes. From the list, you can then select routes to use as the primary and failover routes for a phone number, which you can do via "Update Primary Voice Route for a Phone Number" and "Update Failover Voice Route for a Phone Number".
        /// </summary>
        /// <param name="limit">Optional parameter: Limits the number of routes to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of routes by your specified value. For example, if you have 4 inbound routes and you entered 1 as your offset value, then only 3 of your routes will be displayed in the response.</param>
        /// <return>Returns the void response from the API call</return>
        public async Task<dynamic> ListInboundRoutesAsync(int? limit = null, int? offset = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/routes");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "limit", limit },
                { "offset", offset }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

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
        /// Creates a new inbound route which can then be associated with phone numbers. Please see "List Inbound Routes" to review the route values that you can associate with your Flowroute phone numbers.
        /// </summary>
        /// <param name="body">Required parameter: The new inbound route to be created.</param>
        /// <return>Returns the string response from the API call</return>
        public string CreateAnInboundRoute(Models.NewRoute body)
        {
            Task<string> t = CreateAnInboundRouteAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new inbound route which can then be associated with phone numbers. Please see "List Inbound Routes" to review the route values that you can associate with your Flowroute phone numbers.
        /// </summary>
        /// <param name="body">Required parameter: The new inbound route to be created.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> CreateAnInboundRouteAsync(Models.NewRoute body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/routes");

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

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
        /// Use this endpoint to update the primary voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to which the primary route for voice will be assigned.</param>
        /// <param name="routeId">Required parameter: The primary route to be assigned.</param>
        /// <return>Returns the string response from the API call</return>
        public string UpdatePrimaryVoiceRouteForAPhoneNumber(string numberId, string routeId)
        {
            Task<string> t = UpdatePrimaryVoiceRouteForAPhoneNumberAsync(numberId, routeId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this endpoint to update the primary voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to which the primary route for voice will be assigned.</param>
        /// <param name="routeId">Required parameter: The primary route to be assigned.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> UpdatePrimaryVoiceRouteForAPhoneNumberAsync(string numberId, string routeId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{number_id}/relationships/primary_route");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "number_id", numberId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //append body params
            var _body = "{\"data\": {\"type\": \"route\", \"id\": \"";
            _body += routeId;
            _body += "\"}}";

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PatchBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

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
        /// Use this endpoint to update the failover voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to which the failover route for voice will be assigned.</param>
        /// <param name="routeID">Required parameter: The failover route to be assigned.</param>
        /// <return>Returns the string response from the API call</return>
        public string UpdateFailoverVoiceRouteForAPhoneNumber(string numberId, string routeId)
        {
            Task<string> t = UpdateFailoverVoiceRouteForAPhoneNumberAsync(numberId, routeId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this endpoint to update the failover voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.
        /// </summary>
        /// <param name="numberId">Required parameter: The phone number in E.164 11-digit North American format to which the failover route for voice will be assigned.</param>
        /// <param name="body">Required parameter: The failover route to be assigned.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> UpdateFailoverVoiceRouteForAPhoneNumberAsync(string numberId, string routeId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{number_id}/relationships/failover_route");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "number_id", numberId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "text/plain; charset=utf-8" }
            };

            //append body params
            var _body = "{\"data\": {\"type\": \"route\", \"id\": \"";
            _body += routeId;
            _body += "\"}}";

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PatchBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

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
        /// Returns a list of available edge strategies. From the list, you can then select a PoP for inbound routes.
        /// </summary>
        /// <return>Returns the void response from the API call</return>
        public dynamic ListEdgeStrategies(int? limit = null, int? offset = null)
        {
            Task<dynamic> t = ListEdgeStrategiesAsync(limit, offset);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of available edge strategies. From the list, you can then select a PoP for inbound routes.
        /// </summary>
        /// <return>Returns the void response from the API call</return>
        public async Task<dynamic> ListEdgeStrategiesAsync(int? limit = null, int? offset = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/routes/edge_strategies");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "APIMATIC 2.0" },
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
    }
} 