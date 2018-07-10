using System;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using FlowrouteNumbersAndMessaging.Standard;
using FlowrouteNumbersAndMessaging.Standard.Controllers;
using FlowrouteNumbersAndMessaging.Standard.Models;
using FlowrouteNumbersAndMessaging.Standard.Utilities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace testSDK
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Create Basic Authentication Object - client - from our Configuration Settings
            FlowrouteNumbersAndMessagingClient client = new FlowrouteNumbersAndMessagingClient(FlowrouteNumbersAndMessaging.Standard.Configuration.BasicAuthUserName,
                                                                                               FlowrouteNumbersAndMessaging.Standard.Configuration.BasicAuthPassword);
            // List all our numbers
            ArrayList our_numbers = GetNumbers(client);
            /*
            // Find details for a specific number
            dynamic number_details = GetNumberDetails(client, (string)our_numbers[0]);

            // Find purchasable numbers
            ArrayList available_numbers = GetAvailableNumbers(client);

            // Purchase a DID
            //Number26 did_detail = PurchaseDid(client, (string)available_numbers[0]);

            // Release a DID
            //if(did_detail != null) {
            //    ReleaseDid(client, did_detail.Data.Id);
            //}

            // List Available Area Codes
            ArrayList available_areacodes = GetAvailableAreaCodes(client);

            // List available Exchange Codes
            ArrayList available_exchange_codes = GetAvailableExchangeCodes(client);

            // List Inbound Routes
            ArrayList inbound_routes = GetInboundRoutes(client);

            // List available Edge Strategies
            ArrayList edge_strategies = GetEdgeStrategies(client);

            // Create an Inbound Route
            CreateInboundRoute(client);

            // Update Primary Route for a DID
            string route_id = "";
            foreach (JObject item in inbound_routes)
            {
                route_id = (string)item.GetValue("id");
                break;
            }
            UpdatePrimaryRoute(client, (string)our_numbers[0], (string)route_id);

            // Update the Failover Route for a DID
            for (int i = 1; i < inbound_routes.Count;)
            {
                JObject item = (JObject)inbound_routes[i];
                route_id = (string)item.GetValue("id");
                break;
            }
            UpdateFailoverRoute(client, (string)our_numbers[0], route_id);

            // Set an Alias for a DID
            SetDidAlias(client, (string)our_numbers[0], "Our DID");

            // Set DID Callback
            SetDidCallback(client, (string)our_numbers[0], "http://www.example.com/callback");

            //-------------------- E911 --------------------------
            // List E911 Records
            ArrayList our_e911s = GetE911Records(client);

            // Show E911 Details
            //ListE911Details(client, (string)our_e911s[0]);

            // Validate an E911 Address
            ValidateE911(client);

            // Create an E911 Address
            CreateE911Address(client);

            // Update an E911 Address
            Random random = new Random();
            string new_label = String.Format("New Address {0}", random.Next(0, 100));
            UpdateE911Address(client, (string)our_e911s[0], new_label);

            // Associate an E911 Address with a DID
            AssociateE911(client, (string)our_numbers[0], (string)our_e911s[0]);

            // List all DIDs associated with a specific E911 Record
            ListE911Associations(client, (string)our_e911s[0]);

            // Unassociate an E911 Address from a DID
            UnassociateE911(client, (string)our_numbers[0]);

            // Remove an E911 Record
            DeleteE911(client, (string)our_e911s[0]);

            //----------------- Messaging --------------------------
            // List all our SMS Messages
            ArrayList our_messages = GetMessages(client);

            string target_number = "4254664078";

            // Send an SMS Message from our account
            SendSMS(client, (string)our_numbers[0], target_number);

            // Send an MMS Message from our account
            SendMMS(client, (string)our_numbers[0], target_number);

            // Look up a specific MDR
            GetMDRDetail(client, (string)our_messages[0]);

            // Set Account Level Callback URL for SMS
            SetAccountLevelCallback(client, "SMS_callback", "http://www.example/com/sms");

            // Set Account Level Callback URL for MMS
            SetAccountLevelCallback(client, "MMS_callback", "http://www.example/com/sms");

            // Set Account Level DLR Callback URL
            SetAccountLevelCallback(client, "DLR_callback", "http://www.example/com/sms");

            // Send an SMS Message and specify a custom DLR URL
            SendSMS(client, (string)our_numbers[0], target_number, "http://httpbin.org/status/:code");

            //----------------- CNAM --------------------------

            // Get all CNAM Records
            ArrayList our_cnams = GetCNAMRecords(client);

            // Get details about a single CNAM Record
            GetCNAMDetail(client, (string)our_cnams[0]);

            // Create a CNAM Record
            CreateCNAM(client, "Flowroute");

            // Associate a CNAM Record
            AssociateCNAM(client, (string)our_numbers[0], (string)our_cnams[0]);

            // Unassociate a CNAM
            UnassociateCNAM(client, (string)our_numbers[0]);

            // Delete a CNAM record
            DeleteCNAM(client, (string)our_cnams[0]);
            */
            //----------------- Portability -----------------------

            // Check number portability
            List<string> numbers_to_check = new List<string>();
            numbers_to_check.Add("+14254664444");
            numbers_to_check.Add("+18827833439");
            var result = CheckPortability(client, numbers_to_check);
        }

        private static void CreateInboundRoute(FlowrouteNumbersAndMessagingClient client)
        {
            RoutesController routes = client.Routes;
            NewRoute body = new NewRoute();
            body.Data = new Data61();
            body.Data.Attributes = new Attributes62();
            body.Data.Attributes.Alias = "Test Route";
            body.Data.Attributes.RouteType = RouteTypeEnum.HOST;
            body.Data.Attributes.Value = "www.flowroute.com";
            body.Data.Attributes.EdgeStrategy = "1";

            string result = routes.CreateAnInboundRoute(body);
            Console.WriteLine(result);
        }

        private static void UpdatePrimaryRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route_id)
        {
            RoutesController routes = client.Routes;
            string result = routes.UpdatePrimaryVoiceRouteForAPhoneNumber(DID, route_id);
            Console.WriteLine(result);
        }

        private static void UpdateFailoverRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route_id)
        {
            RoutesController routes = client.Routes;
            string result = routes.UpdateFailoverVoiceRouteForAPhoneNumber(DID, route_id);
            Console.WriteLine(result);
        }

        private static void SetDidAlias(FlowrouteNumbersAndMessagingClient client, string our_number, string new_alias)
        {
            NumbersController numbers = client.Numbers;
            Int32 result = numbers.SetDIDAlias(our_number, new_alias);
            Console.WriteLine(result);
        }

        private static void SetDidCallback(FlowrouteNumbersAndMessagingClient client, string DID, string url)
        {
            NumbersController numbers = client.Numbers;
            Int32 result = numbers.SetDIDCallback(DID, url);
            Console.WriteLine(result);
        }


        private static ArrayList GetInboundRoutes(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            int? limit = 10;
            int? offset = 0;

            RoutesController routes = client.Routes;

            do
            {
                dynamic route_data = routes.ListInboundRoutes(limit, offset);
                Console.WriteLine(route_data);

                foreach (var item in route_data.data)
                {
                    Console.WriteLine("---------------------------\nInbound Routes:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((dynamic)item);
                }

                // See if there is more data to process
                var links = route_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }

            }
            while (true);

            return return_list;
        }


        private static ArrayList GetEdgeStrategies(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            RoutesController routes = client.Routes;

            dynamic route_data = routes.ListEdgeStrategies();
            Console.WriteLine(route_data);

            foreach (var item in route_data.data)
            {
                Console.WriteLine("---------------------------\nEdge Strategies:\n");
                Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                return_list.Add((dynamic)item);
            }

            return return_list;
        }

        private static ArrayList GetAvailableExchangeCodes(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            int? limit = 10;
            int? offset = 0;
            double? maxSetupCost = 174.40;
            string areacode = "206";

            // User the Numbers Controller from our Client
            NumbersController numbers = client.Numbers;

            do
            {
                dynamic exchanges_data = numbers.ListAvailableExchangeCodes(limit, offset, maxSetupCost, areacode);
                Console.WriteLine(exchanges_data);

                foreach (var item in exchanges_data.data)
                {
                    Console.WriteLine("---------------------------\nAvailable Exchange:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = exchanges_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }
            }
            while (true);

            return return_list;
        }

        private static ArrayList GetAvailableAreaCodes(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            int? limit = 100;
            int? offset = 0;
            double? maxSetupCost = 10.00;

            // User the Numbers Controller from our Client
            NumbersController numbers = client.Numbers;

            do
            {
                Console.WriteLine("Offset is {0}", offset);
                dynamic areacode_data = numbers.ListAvailableAreaCodes(limit, offset, maxSetupCost);
                Console.WriteLine(areacode_data);

                foreach (var item in areacode_data.data)
                {
                    Console.WriteLine("---------------------------\nAvailable Area Code:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = areacode_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }
            } while (true);

            return return_list;
        }

        private static Number26 PurchaseDid(FlowrouteNumbersAndMessagingClient client, string did)
        {
            NumbersController numbers = client.Numbers;

            try {
                Number26 data = numbers.CreatePurchaseAPhoneNumber(did);
                return data;
            } catch(FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e) {
                Console.WriteLine(e);
                return null;
            }
        }

        private static void ReleaseDid(FlowrouteNumbersAndMessagingClient client, string did)
        {
            NumbersController numbers = client.Numbers;

            numbers.ReleaseDID(did);
        }


        private static ArrayList GetAvailableNumbers(FlowrouteNumbersAndMessagingClient client)
        {
            string startsWith = "206";
            string contains = null;
            string endsWith = null;
            string rateCenter = null;
            string state = null;

            int? limit = 10;
            int? offset = 0;

            ArrayList return_list = new ArrayList();
            // User the Numbers Controller from our Client
            NumbersController numbers = client.Numbers;
            do
            {
                dynamic number_data = numbers.SearchForPurchasablePhoneNumbers(startsWith, contains, endsWith, limit, offset, rateCenter, state);
                Console.WriteLine(number_data);
                // Iterate through each number item
                foreach (var item in number_data.data)
                {
                    Console.WriteLine("---------------------------\nAvailable Area Codes:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = number_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }
            } while (true);

            return return_list;
        }

        private static void GetMDRDetail(FlowrouteNumbersAndMessagingClient client, string id)
        {
            MessagesController messages = client.Messages;

            dynamic mdr_data = messages.GetLookUpAMessageDetailRecord(id);   
            Console.WriteLine(mdr_data);
        }

        private static void SendSMS(FlowrouteNumbersAndMessagingClient client, string from_did, string to_did, string callback=null)
        {
            Message msg = new Message();
            msg.From = from_did;
            msg.To = to_did; // Replace with your mobile number to receive messages sent from your Flowroute account
            msg.Body = "Hi Chris";
            msg.Callback = callback;

            MessagesController messages = client.Messages;
            string result = messages.CreateSendAMessage(msg);
            Console.WriteLine(result);
        }

        private static void SendMMS(FlowrouteNumbersAndMessagingClient client, string from_did, string to_did)
        {
            MMS_Message msg = new MMS_Message();
            msg.From = from_did;
            msg.To = to_did;
            msg.Body = "Hi Chris";
            // Create the image / media urls to add to the message
            List<string> pictures = new List<string>();
            pictures.Add("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");
            msg.MediaUrls = pictures;

            MessagesController messages = client.Messages;
            string result = messages.CreateSendAMMSMessage(msg);
            Console.WriteLine(result);
        }

        public static ArrayList GetMessages(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();
            int? limit = 20;
            int? offset = 0;

            // Find all messages since January 1, 2017
            DateTime startDate = new DateTime(2017, 1, 1);
            DateTime? endDate = null;

            do
            {
                MessagesController messages = client.Messages;
                dynamic message_data = messages.GetLookUpASetOfMessages(startDate, endDate, limit, offset);

                // Iterate through each number item
                foreach (var item in message_data.data)
                {
                    Console.WriteLine("---------------------------\nSMS MDR:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = message_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }
            }
            while (true);
            return return_list;
        }

        public static ArrayList GetNumbers(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            // List all phone numbers in our account paging through them 1 at a time
            //  If you have several phone numbers, change the 'limit' variable below
            //  This example is intended to show how to page through a list of resources

            int? limit = 100;
            int? offset = 0;

            int? startsWith = null;
            int? endsWith = null;
            int? contains = null;

            // User the Numbers Controller from our Client
            NumbersController numbers = client.Numbers;
            do
            {
                dynamic number_data = numbers.GetAccountPhoneNumbers(startsWith, endsWith, contains, limit, offset);

                // Iterate through each number item
                foreach (var item in number_data.data)
                {
                    Console.WriteLine("---------------------------\nPhone Number Record:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = number_data.links;
                if(links.next != null) 
                {
                    // more data to pull
                    offset += limit;
                } else {
                    break;   // no more data
                }
            }
            while (true);

            Console.WriteLine("Processing Complete");
            return return_list;
        }

        public static dynamic GetNumberDetails(FlowrouteNumbersAndMessagingClient client, string id) 
        {
            // User the Numbers Controller from our Client
            NumbersController numbers = client.Numbers;

            Console.WriteLine("---------------------------\nList Phone Number Details:\n");
            dynamic result = numbers.GetPhoneNumberDetails(id);
            Console.WriteLine(result);
            return result;

        }

        public static dynamic GetE911Records(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            // List all E911 records in our account paging through them 1 at a time
            //  If you have several phone numbers, change the 'limit' variable below
            //  This example is intended to show how to page through a list of resources

            int? limit = 100;
            int? offset = 0;

            E911Controller e911s = client.E911s;
            do
            {
                dynamic e911_data = e911s.ListE911s(limit, offset);

                // Iterate through each number item
                foreach (var item in e911_data.data)
                {
                    Console.WriteLine("---------------------------\nE911 Record:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = e911_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }
            }
            while (true);

            Console.WriteLine("Processing Complete");
            return return_list;
        }

        public static dynamic ListE911Details(FlowrouteNumbersAndMessagingClient client, string id)
        {
            // User the E911 Controller from our Client
            E911Controller e911s = client.E911s;

            Console.WriteLine("---------------------------\nList E911 Details:\n");
            dynamic result = e911s.E911Details(id);
            Console.WriteLine(result);
            return result;
        }

        public static dynamic ValidateE911(FlowrouteNumbersAndMessagingClient client)
        {
            E911Controller e911s = client.E911s;
            E911 body = new E911();
            body.StreetName = "N Vassault";
            body.StreetNumber = "3901";
            body.AddressType = null;
            body.AddressTypeNumber = null;
            body.City = "Tacoma";
            body.State = "WA";
            body.Country = "US";
            body.FirstName = "John";
            body.LastName = "Doe";
            body.Label = "Home";
            body.Zip = "98407";

            dynamic result = e911s.ValidateE911(body);
            Console.WriteLine(result);
            return result;
        }

        public static dynamic CreateE911Address(FlowrouteNumbersAndMessagingClient client)
        {
            E911Controller e911s = client.E911s;
            E911 body = new E911();
            body.StreetName = "3rd Ave";
            body.StreetNumber = "1111";
            body.AddressType = "Suite";
            body.AddressTypeNumber = "200";
            body.City = "Seattle";
            body.State = "WA";
            body.Country = "US";
            body.FirstName = "John";
            body.LastName = "Doe";
            body.Label = "Potbelly";
            body.Zip = "98101";

            try
            {
                dynamic result = e911s.CreateE911Address(body);
                Console.WriteLine(result);
                return result;
            } catch(FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic UpdateE911Address(FlowrouteNumbersAndMessagingClient client, string e911_id, string new_label)
        {
            E911Controller e911s = client.E911s;
            dynamic result = e911s.E911Details(e911_id);

            string jsonstring = result.ToString();
            Newtonsoft.Json.Linq.JObject j = Newtonsoft.Json.Linq.JObject.Parse(jsonstring);
            string old_label = (string)j["data"]["attributes"]["label"];
            E911 body = new E911();
            body.AddressType = (string)j["data"]["attributes"]["address_type"];
            body.AddressTypeNumber = (string)j["data"]["attributes"]["address_type_number"];
            body.AdressNumber = (string)j["data"]["attributes"]["street_number"];
            body.City = (string)j["data"]["attributes"]["city"];
            body.Country = (string)j["data"]["attributes"]["country"];
            body.FirstName = (string)j["data"]["attributes"]["first_name"];
            body.Id = (string)j["data"]["id"];
            body.LastName = (string)j["data"]["attributes"]["last_name"];
            body.State = (string)j["data"]["attributes"]["state"];
            body.StreetName = (string)j["data"]["attributes"]["street_name"];
            body.StreetNumber = (string)j["data"]["attributes"]["street_number"];
            body.Zip = (string)j["data"]["attributes"]["zip"];
            body.Label = (string)new_label;

            try
            {
                dynamic submissin_result = e911s.UpdateE911Address(body);
                Console.WriteLine(result);
                return result;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic AssociateE911(FlowrouteNumbersAndMessagingClient client, string number_id, string e911_id)
        {
            E911Controller e911s = client.E911s;
            try
            {
                dynamic result = e911s.AssociateE911(number_id, e911_id);
                Console.WriteLine(result);
                return result;
            } catch(FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic UnassociateE911(FlowrouteNumbersAndMessagingClient client, string number_id)
        {
            E911Controller e911s = client.E911s;
            try
            {
                dynamic result = e911s.UnassociateE911(number_id);
                Console.WriteLine(result);
                return result;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic DeleteE911(FlowrouteNumbersAndMessagingClient client, string e911_id)
        {
            E911Controller e911s = client.E911s;
            try
            {
                dynamic result = e911s.DeleteE911(e911_id);
                Console.WriteLine(result);
                return result;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic ListE911Associations(FlowrouteNumbersAndMessagingClient client, string e911_id)
        {
            E911Controller e911s = client.E911s;
            try
            {
                dynamic result = e911s.ListDidsForE911(e911_id);
                Console.WriteLine(result);
                return result;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic SetAccountLevelCallback(FlowrouteNumbersAndMessagingClient client, string callback_type, string callback_url)
        {
            MessagesController messages = client.Messages;

            if (callback_type.Equals("sms_callback", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    dynamic result = messages.SetSMSCallback(callback_url);
                    return result;
                }
                catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            } 
            else if (callback_type.Equals("mms_callback", StringComparison.InvariantCultureIgnoreCase)) 
            {
                try
                {
                    dynamic result = messages.SetMMSCallback(callback_url);
                    return result;
                }
                catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            } 
            else if (callback_type.Equals("dlr_callback", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    dynamic result = messages.SetDLRCallback(callback_url);
                    return result;
                }
                catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            } 
            return null;
        }

        // --------------------------- CNAM Functions --------------------------------------
        public static dynamic GetCNAMRecords(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            // List all E911 records in our account paging through them 1 at a time
            //  If you have several phone numbers, change the 'limit' variable below
            //  This example is intended to show how to page through a list of resources

            int limit = 10;
            int offset = 0;

            CNAMsController cnams = client.CNAMs;
            do
            {
                dynamic cnam_data = cnams.GetAccountCNAMS(null, null, null, true, limit, offset);

                // Iterate through each number item
                foreach (var item in cnam_data.data)
                {
                    Console.WriteLine("---------------------------\nCNAM Record:\n");
                    Console.WriteLine("Attributes:{0}\nId:{1}\nLinks:{2}\nType:{3}\n", item.attributes, item.id, item.links, item.type);
                    return_list.Add((string)item.id);
                }

                // See if there is more data to process
                var links = cnam_data.links;
                if (links.next != null)
                {
                    // more data to pull
                    offset += limit;
                }
                else
                {
                    break;   // no more data
                }
            }
            while (true);

            Console.WriteLine("Processing Complete");
            return return_list;
        }

        public static dynamic GetCNAMDetail(FlowrouteNumbersAndMessagingClient client, string cnam_id)
        {
            CNAMsController cnams = client.CNAMs;
            dynamic cnam_data = cnams.GetCNAMDetails(cnam_id);
            Console.WriteLine(cnam_data);
            return cnam_data;
        }

        public static dynamic CreateCNAM(FlowrouteNumbersAndMessagingClient client, string cnam_value)
        {
            CNAMsController cnams = client.CNAMs;
            try
            {
                dynamic cnam_data = cnams.CreateCNAM(cnam_value);
                Console.WriteLine(cnam_data);
                return cnam_data;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic AssociateCNAM(FlowrouteNumbersAndMessagingClient client, string number_id, string cnam_id)
        {
            CNAMsController cnams = client.CNAMs;
            try
            {
                dynamic return_data = cnams.AssociateCNAM(number_id, cnam_id);
                Console.WriteLine(return_data);
                return return_data;
            } catch(FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic UnassociateCNAM(FlowrouteNumbersAndMessagingClient client, string number_id)
        {
            CNAMsController cnams = client.CNAMs;
            try
            {
                dynamic return_data = cnams.UnassociateCNAM(number_id);
                Console.WriteLine(return_data);
                return return_data;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic DeleteCNAM(FlowrouteNumbersAndMessagingClient client, string cnam_id)
        {
            CNAMsController cnams = client.CNAMs;
            try {
                dynamic return_data = cnams.DeleteCNAM(cnam_id);
                Console.WriteLine(return_data);
                return return_data;
            }
            catch (FlowrouteNumbersAndMessaging.Standard.Exceptions.ErrorException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static dynamic CheckPortability(FlowrouteNumbersAndMessagingClient client, List<string>numbers_to_check)
        {
            PortingController porting = client.Porting;
            dynamic return_data = porting.CheckPortability(numbers_to_check);
            return return_data;
        }

    }
}
