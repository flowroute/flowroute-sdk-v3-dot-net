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
    public partial class NumbersController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static NumbersController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static NumbersController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new NumbersController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Returns a list of all phone numbers currently on your Flowroute account. The response includes details such as the phone number's rate center, state, number type, and whether CNAM Lookup is enabled for that number.
        /// </summary>
        /// <param name="startsWith">Optional parameter: Retrieves phone numbers that start with the specified value.</param>
        /// <param name="endsWith">Optional parameter: Retrieves phone numbers that end with the specified value.</param>
        /// <param name="contains">Optional parameter: Retrieves phone numbers containing the specified value.</param>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic GetAccountPhoneNumbers(
                int? startsWith = null,
                int? endsWith = null,
                int? contains = null,
                int? limit = null,
                int? offset = null)
        {
            Task<dynamic> t = GetAccountPhoneNumbersAsync(startsWith, endsWith, contains, limit, offset);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of all phone numbers currently on your Flowroute account. The response includes details such as the phone number's rate center, state, number type, and whether CNAM Lookup is enabled for that number.
        /// </summary>
        /// <param name="startsWith">Optional parameter: Retrieves phone numbers that start with the specified value.</param>
        /// <param name="endsWith">Optional parameter: Retrieves phone numbers that end with the specified value.</param>
        /// <param name="contains">Optional parameter: Retrieves phone numbers containing the specified value.</param>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> GetAccountPhoneNumbersAsync(
                int? startsWith = null,
                int? endsWith = null,
                int? contains = null,
                int? limit = null,
                int? offset = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "starts_with", startsWith },
                { "ends_with", endsWith },
                { "contains", contains },
                { "limit", limit },
                { "offset", offset }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Lists all of the information associated with any of the phone numbers in your account, including billing method, primary voice route, and failover voice route.
        /// </summary>
        /// <param name="id">Required parameter: Phone number to search for which must be a number that you own. Must be in 11-digit E.164 format; e.g. 12061231234.</param>
        /// <return>Returns the Models.Number26 response from the API call</return>
        public dynamic GetPhoneNumberDetails(string id)
        {
            Task<dynamic> t = GetPhoneNumberDetailsAsync(id);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists all of the information associated with any of the phone numbers in your account, including billing method, primary voice route, and failover voice route.
        /// </summary>
        /// <param name="id">Required parameter: Phone number to search for which must be a number that you own. Must be in 11-digit E.164 format; e.g. 12061231234.</param>
        /// <return>Returns the Models.Number26 response from the API call</return>
        public async Task<dynamic> GetPhoneNumberDetailsAsync(string id)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "id", id }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
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
        /// Lets you purchase a phone number from available Flowroute inventory.
        /// </summary>
        /// <param name="id">Required parameter: Phone number to purchase. Must be in 11-digit E.164 format; e.g. 12061231234.</param>
        /// <return>Returns the Models.Number26 response from the API call</return>
        public Models.Number26 CreatePurchaseAPhoneNumber(string id)
        {
            Task<Models.Number26> t = CreatePurchaseAPhoneNumberAsync(id);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lets you purchase a phone number from available Flowroute inventory.
        /// </summary>
        /// <param name="id">Required parameter: Phone number to purchase. Must be in 11-digit E.164 format; e.g. 12061231234.</param>
        /// <return>Returns the Models.Number26 response from the API call</return>
        public async Task<Models.Number26> CreatePurchaseAPhoneNumberAsync(string id)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "id", id }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Post(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            if (_response.StatusCode == 403)
                throw new ErrorException(@"Insufficient funds available to complete the request.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.Number26>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Lets you purchase a phone number from available Flowroute inventory.
        /// </summary>
        /// <param name="id">Required parameter: Phone number to purchase. Must be in 11-digit E.164 format; e.g. 12061231234.</param>
        /// <return>Returns the Models.Number26 response from the API call</return>
        public Int32 ReleaseDID(string id)
        {
            Task<Int32> t = ReleaseDIDAsync(id);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lets you purchase a phone number from available Flowroute inventory.
        /// </summary>
        /// <param name="id">Required parameter: Phone number to purchase. Must be in 11-digit E.164 format; e.g. 12061231234.</param>
        /// <return>Returns the Models.Number26 response from the API call</return>
        public async Task<Int32> ReleaseDIDAsync(string id)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{id}");

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

            return _response.StatusCode;
        }
        /// <summary>
        /// This endpoint lets you search for phone numbers by state or rate center, or by your specified search value.
        /// </summary>
        /// <param name="startsWith">Optional parameter: Retrieve phone numbers that start with the specified value.</param>
        /// <param name="contains">Optional parameter: Retrieve phone numbers containing the specified value.</param>
        /// <param name="endsWith">Optional parameter: Retrieve phone numbers that end with the specified value.</param>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <param name="rateCenter">Optional parameter: Filters by and displays phone numbers in the specified rate center.</param>
        /// <param name="state">Optional parameter: Filters by and displays phone numbers in the specified state. Optional unless a ratecenter is specified.</param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic SearchForPurchasablePhoneNumbers(
                string startsWith = null,
                string contains = null,
                string endsWith = null,
                int? limit = null,
                int? offset = null,
                string rateCenter = null,
                string state = null)
        {
            Task<dynamic> t = SearchForPurchasablePhoneNumbersAsync(startsWith, contains, endsWith, limit, offset, rateCenter, state);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint lets you search for phone numbers by state or rate center, or by your specified search value.
        /// </summary>
        /// <param name="startsWith">Optional parameter: Retrieve phone numbers that start with the specified value.</param>
        /// <param name="contains">Optional parameter: Retrieve phone numbers containing the specified value.</param>
        /// <param name="endsWith">Optional parameter: Retrieve phone numbers that end with the specified value.</param>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <param name="rateCenter">Optional parameter: Filters by and displays phone numbers in the specified rate center.</param>
        /// <param name="state">Optional parameter: Filters by and displays phone numbers in the specified state. Optional unless a ratecenter is specified.</param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> SearchForPurchasablePhoneNumbersAsync(
                string startsWith = null,
                string contains = null,
                string endsWith = null,
                int? limit = null,
                int? offset = null,
                string rateCenter = null,
                string state = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/available");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "starts_with", startsWith },
                { "contains", contains },
                { "ends_with", endsWith },
                { "limit", limit },
                { "offset", offset },
                { "rate_center", rateCenter },
                { "state", state }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Returns a list of all Numbering Plan Area (NPA) codes containing purchasable phone numbers.
        /// </summary>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 400 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <param name="maxSetupCost">Optional parameter: Restricts the results to the specified maximum non-recurring setup cost.</param>
        /// <return>Returns the void response from the API call</return>
        public dynamic ListAvailableAreaCodes(int? limit = null, int? offset = null, double? maxSetupCost = null)
        {
            Task<dynamic> t = ListAvailableAreaCodesAsync(limit, offset, maxSetupCost);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of all Numbering Plan Area (NPA) codes containing purchasable phone numbers.
        /// </summary>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 400 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <param name="maxSetupCost">Optional parameter: Restricts the results to the specified maximum non-recurring setup cost.</param>
        /// <return>Returns the void response from the API call</return>
        public async Task<dynamic> ListAvailableAreaCodesAsync(int? limit = null, int? offset = null, double? maxSetupCost = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/available/areacodes");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "limit", limit },
                { "offset", offset },
                { "max_setup_cost", maxSetupCost }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Returns a list of all Central Office (exchange) codes containing purchasable phone numbers.
        /// </summary>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <param name="maxSetupCost">Optional parameter: Restricts the results to the specified maximum non-recurring setup cost.</param>
        /// <param name="areacode">Optional parameter: Restricts the results to the specified area code.</param>
        /// <return>Returns the void response from the API call</return>
        public dynamic ListAvailableExchangeCodes(
                int? limit = null,
                int? offset = null,
                double? maxSetupCost = null,
                string areacode = null)
        {
            Task<dynamic> t = ListAvailableExchangeCodesAsync(limit, offset, maxSetupCost, areacode);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of all Central Office (exchange) codes containing purchasable phone numbers.
        /// </summary>
        /// <param name="limit">Optional parameter: Limits the number of items to retrieve. A maximum of 200 items can be retrieved.</param>
        /// <param name="offset">Optional parameter: Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response.</param>
        /// <param name="maxSetupCost">Optional parameter: Restricts the results to the specified maximum non-recurring setup cost.</param>
        /// <param name="areacode">Optional parameter: Restricts the results to the specified area code.</param>
        /// <return>Returns the void response from the API call</return>
        public async Task<dynamic> ListAvailableExchangeCodesAsync(
                int? limit = null,
                int? offset = null,
                double? maxSetupCost = null,
                string areacode = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/available/exchanges");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "limit", limit },
                { "offset", offset },
                { "max_setup_cost", maxSetupCost },
                { "areacode", areacode }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Allows you to set a text alias on a given DID.
        /// </summary>
        /// <param name="number">Required parameter: Phone number to operate on.</param>
        /// <param name="alias">Required parameter: Alias to apply.</param>
        /// <return>Returns the response from the API call</return>
        public Int32 SetDIDAlias(string number, string alias)
        {
            Task<Int32> t = SetDIDAliasAsync(number, alias);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Allows you to set a text alias on a given DID.
        /// </summary>
        /// <param name="number">Required parameter: Phone number to operate on.</param>
        /// <param name="alias">Required parameter: Alias to apply.</param>
        /// <return>Returns the response from the API call</return>
        public async Task<Int32> SetDIDAliasAsync(string number, string alias)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{did}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "did", number }
            });

            var body = "{\"type\":\"number\", \"alias\":\"";
            body += alias;
            body += "\"}";
            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PatchBody(_queryUrl, _headers, body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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

            return _response.StatusCode;
        }

            /// <summary>
        /// Allows you to set a text alias on a given DID.
        /// </summary>
        /// <param name="number">Required parameter: Phone number to operate on.</param>
        /// <param name="callback">Required parameter: URL to apply.</param>
        /// <return>Returns the response from the API call</return>
        public Int32 SetDIDCallback(string number, string callback)
        {
            Task<Int32> t = SetDIDCallbackAsync(number, callback);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Allows you to set a text alias on a given DID.
        /// </summary>
        /// <param name="number">Required parameter: Phone number to operate on.</param>
        /// <param name="callback">Required parameter: URL to apply.</param>
        /// <return>Returns the response from the API call</return>
        public async Task<Int32> SetDIDCallbackAsync(string number, string callback)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/numbers/{did}/relationships/dlr_callback");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "did", number }
            });

            var body = "{\"data\":{\"attributes\": {\"callback_url\":\"";
            body += callback;
            body += "\"}}}";
            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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

            return _response.StatusCode;
        }


    }
} 