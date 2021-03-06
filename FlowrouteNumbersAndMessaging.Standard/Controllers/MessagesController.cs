/*
 * FlowrouteNumbersAndMessaging.Standard
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
    public partial class MessagesController : BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static MessagesController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static MessagesController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MessagesController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Retrieves a list of Message Detail Records (MDRs) within a specified date range. Date and time is based on Coordinated Universal Time (UTC).
        /// </summary>
        /// <param name="startDate">Required parameter: The beginning date and time, in UTC, on which to perform an MDR search. The DateTime can be formatted as YYYY-MM-DDor YYYY-MM-DDTHH:mm:ss.SSZ.</param>
        /// <param name="endDate">Optional parameter: The ending date and time, in UTC, on which to perform an MDR search. The DateTime can be formatted as YYYY-MM-DD or YYYY-MM-DDTHH:mm:ss.SSZ.</param>
        /// <param name="limit">Optional parameter: The number of MDRs to retrieve at one time. You can set as high of a number as you want, but the number cannot be negative and must be greater than 0 (zero).</param>
        /// <param name="offset">Optional parameter: The number of MDRs to skip when performing a query. The number must be 0 (zero) or greater, but cannot be negative.</param>
        /// <return>Returns the string response from the API call</return>
        public dynamic GetLookUpASetOfMessages(
                DateTime startDate,
                DateTime? endDate = null,
                int? limit = null,
                int? offset = null)
        {
            Task<dynamic> t = GetLookUpASetOfMessagesAsync(startDate, endDate, limit, offset);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a list of Message Detail Records (MDRs) within a specified date range. Date and time is based on Coordinated Universal Time (UTC).
        /// </summary>
        /// <param name="startDate">Required parameter: The beginning date and time, in UTC, on which to perform an MDR search. The DateTime can be formatted as YYYY-MM-DDor YYYY-MM-DDTHH:mm:ss.SSZ.</param>
        /// <param name="endDate">Optional parameter: The ending date and time, in UTC, on which to perform an MDR search. The DateTime can be formatted as YYYY-MM-DD or YYYY-MM-DDTHH:mm:ss.SSZ.</param>
        /// <param name="limit">Optional parameter: The number of MDRs to retrieve at one time. You can set as high of a number as you want, but the number cannot be negative and must be greater than 0 (zero).</param>
        /// <param name="offset">Optional parameter: The number of MDRs to skip when performing a query. The number must be 0 (zero) or greater, but cannot be negative.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<dynamic> GetLookUpASetOfMessagesAsync(
                DateTime startDate,
                DateTime? endDate = null,
                int? limit = null,
                int? offset = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "start_date", startDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") },
                { "end_date", (endDate.HasValue) ? endDate.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") : null },
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
        /// Sends an SMS from a Flowroute long code or toll-free phone number to another valid phone number.
        /// </summary>
        /// <param name="body">Required parameter: The SMS or MMS message to send.</param>
        /// <return>Returns the string response from the API call</return>
        public string CreateSendAMessage(Models.Message body)
        {
            Task<string> t = CreateSendAMessageAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sends an SMS from a Flowroute long code or toll-free phone number to another valid phone number.
        /// </summary>
        /// <param name="body">Required parameter: The SMS or MMS message to send.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> CreateSendAMessageAsync(Models.Message body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "content-type", "application/vnd.api+json" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);
            Console.WriteLine("Body is : {0} ", _body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 403)
                throw new ErrorException(@"Forbidden – You don't have permission to access this resource.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            if (_response.StatusCode == 422)
                throw new ErrorException(@"Unprocessable Entity - You tried to enter an incorrect value.", _context);

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
        /// Sends an SMS from a Flowroute long code or toll-free phone number to another valid phone number.
        /// </summary>
        /// <param name="body">Required parameter: The SMS or MMS message to send.</param>
        /// <return>Returns the string response from the API call</return>
        public string CreateSendAMMSMessage(Models.MMS_Message body)
        {
            Task<string> t = CreateSendAMMSMessageAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sends an SMS from a Flowroute long code or toll-free phone number to another valid phone number.
        /// </summary>
        /// <param name="body">Required parameter: The SMS or MMS message to send.</param>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> CreateSendAMMSMessageAsync(Models.MMS_Message body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Flowroute SDK v3.0" },
                { "content-type", "application/vnd.api+json" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 401)
                throw new ErrorException(@"Unauthorized – There was an issue with your API credentials.", _context);

            if (_response.StatusCode == 403)
                throw new ErrorException(@"Forbidden – You don't have permission to access this resource.", _context);

            if (_response.StatusCode == 404)
                throw new ErrorException(@"The specified resource was not found", _context);

            if (_response.StatusCode == 422)
                throw new ErrorException(@"Unprocessable Entity - You tried to enter an incorrect value.", _context);

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
        /// Searches for a specific message record ID and returns a Message Detail Record (in MDR2 format).
        /// </summary>
        /// <param name="id">Required parameter: The unique message detail record identifier (MDR ID) of any message. When entering the MDR ID, the number should include the mdr2- preface.</param>
        /// <return>Returns the Models.MDR2 response from the API call</return>
        public dynamic GetLookUpAMessageDetailRecord(string id)
        {
            Task<dynamic> t = GetLookUpAMessageDetailRecordAsync(id);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for a specific message record ID and returns a Message Detail Record (in MDR2 format).
        /// </summary>
        /// <param name="id">Required parameter: The unique message detail record identifier (MDR ID) of any message. When entering the MDR ID, the number should include the mdr2- preface.</param>
        /// <return>Returns the Models.MDR2 response from the API call</return>
        public async Task<dynamic> GetLookUpAMessageDetailRecordAsync(string id)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages/{id}");

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
                { "content-type", "application/vnd.api+json" }
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
        /// Sets the Account Level SMS Callback URL.
        /// </summary>
        /// <param name="sms_url">Required parameter: The callback URL for all SMS messages
        /// <return>Status Code, 204 on success 4xx on error</return>
        public dynamic SetSMSCallback(string sms_url)
        {
            Task<dynamic> t = SetSMSCallbackAsync(sms_url);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sets the Account Level callback url for all SMS Messages
        /// </summary>
        /// <param name="sms_url">Required parameter: The callback url for all SMS messages
        /// <return>Returns the response from the API call</return>
        public async Task<dynamic> SetSMSCallbackAsync(string sms_url)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages/sms_callback");

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //append body params
            var _body = "{\"data\": {\"attributes\": {\"callback_url\": ";
            _body += sms_url;
            _body += "\"}}}";

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return _response.StatusCode;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Sets the Account Level MMS Callback URL.
        /// </summary>
        /// <param name="mms_url">Required parameter: The callback URL for all MMS messages
        /// <return>Status Code, 204 on success 4xx on error</return>
        public dynamic SetMMSCallback(string mms_url)
        {
            Task<dynamic> t = SetMMSCallbackAsync(mms_url);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Set the Account Level callback for all MMS messages.
        /// </summary>
        /// <param name="mms_url">Required parameter: The callback url for all MMS messages.
        /// <return>Returns the response from the API call</return>
        public async Task<dynamic> SetMMSCallbackAsync(string mms_url)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages/mms_callback");

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
                {
                    { "user-agent", "APIMATIC 2.0" },
                    { "accept", "application/json" }
                };

            //append body params
            var _body = "{\"data\": {\"attributes\": {\"callback_url\": ";
            _body += mms_url;
            _body += "\"}}}";

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return _response.StatusCode;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Sets the Account Level DLR Callback URL.
        /// </summary>
        /// <param name="dlr_url">Required parameter: The callback URL for all DLRs
        /// <return>Status Code, 204 on success 4xx on error</return>
        public dynamic SetDLRCallback(string dlr_url)
        {
            Task<dynamic> t = SetDLRCallbackAsync(dlr_url);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Set the Account Level callback for all DLRs
        /// </summary>
        /// <param name="dlr_url">Required parameter: The callback url for all DLRs.
        /// <return>Returns the response from the API call</return>
        public async Task<dynamic> SetDLRCallbackAsync(string dlr_url)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2.1/messages/dlr_callback");

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
                    {
                        { "user-agent", "APIMATIC 2.0" },
                        { "accept", "application/json" }
                    };

            //append body params
            var _body = "{\"data\": {\"attributes\": {\"callback_url\": ";
            _body += dlr_url;
            _body += "\"}}}";

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

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
                return _response.StatusCode;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }
    }
}