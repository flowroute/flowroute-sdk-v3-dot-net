using System;
using System.Net.Http;
using System.Collections;
using FlowrouteNumbersAndMessaging.Standard;
using FlowrouteNumbersAndMessaging.Standard.Controllers;
using FlowrouteNumbersAndMessaging.Standard.Models;
using Newtonsoft.Json.Linq;

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

            // List all our SMS Messages
            ArrayList our_messages = GetMessages(client);

            // Send an SMS Message from our account
            SendSMS(client, (string)our_numbers[0]);

            // Look up a specific MDR
            GetMDRDetail(client, (string)our_messages[0]);

            // Find details for a specific number
            dynamic number_details = GetNumberDetails(client, (string)our_numbers[0]);

            // Find purchasable numbers
            ArrayList available_numbers = GetAvailableNumbers(client);

            // List Available Area Codes
            ArrayList available_areacodes = GetAvailableAreaCodes(client);

            // List available Exchange Codes
            ArrayList available_exchange_codes = GetAvailableExchangeCodes(client);

            // List Inbound Routes
            ArrayList inbound_routes = GetInboundRoutes(client);

            // Create an Inbound Route
            CreateInboundRoute(client);

            // Update Primary Route for a DID
            string route_id = "";
            foreach(JObject item in inbound_routes)
            {
                route_id = (string)item.GetValue("id");
                break;
            }
            UpdatePrimaryRoute(client, (string)our_numbers[0], (string)route_id);

            // Update the Failover Route for a DID
            for (int i = 1; i < inbound_routes.Count; )
            {
                JObject item = (JObject)inbound_routes[i];
                route_id = (string)item.GetValue("id");
                break;
            }
            UpdateFailoverRoute(client, (string)our_numbers[0], route_id);
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

        private static ArrayList GetAvailableNumbers(FlowrouteNumbersAndMessagingClient client)
        {
            string startsWith = "206";
            string contains = null;
            string endsWith = null;
            string rateCenter = null;
            string state = null;

            int? limit = 5;
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

        private static void SendSMS(FlowrouteNumbersAndMessagingClient client, string from_did)
        {
            Message msg = new Message();
            msg.From = from_did;
            msg.To = "4254664078";
            msg.Body = "Hi Chris";

            MessagesController messages = client.Messages;
            string result = messages.CreateSendAMessage(msg);
            Console.WriteLine(result);
        }

        public static ArrayList GetMessages(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();
            int? limit = 100;
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

            dynamic result = numbers.GetPhoneNumberDetails(id);
            Console.WriteLine(result);
            return result;

        }
    }
}
