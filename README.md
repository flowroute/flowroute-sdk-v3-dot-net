The Flowroute .NET Library v3 provides methods for interacting with [Numbers v2](https://developer.flowroute.com/api/numbers/v2.0/) and [Messages v2.1](https://developer.flowroute.com/api/messages/v2.1/) of
the [Flowroute](https://www.flowroute.com) API.

**Topics**

- [Requirements](#requirements)

- [Installation and Configuration](#installation)
    -   [Credentials](#credentials)

- [Usage](#usage)
    - [Methods](#methods)

    - [Number Management](#number-management)
        -   [GetAvailableAreaCodes](#getavailableareacodesflowroutenumbersandmessagingclient-client)
        -   [GetAvailableExchangeCodes](#getavailableexchangecodesflowroutenumbersandmessagingclient-client)
        -   [GetAvailableNumbers](#getavailablenumbersflowroutenumbersandmessagingclient-client)
        -   [GetNumbers](#getnumbersflowroutenumbersandmessagingclient-client)
        -   [GetNumberDetails](#getnumberdetailsflowroutenumbersandmessagingclient-client-string-id)
    - [Route Management](#routemanagement)
        -   [CreateInboundRoute](#createinboundrouteflowroutenumbersandmessagingclient-client)
        -   [GetInboundRoutes](#getinboundroutesflowroutenumbersandmessagingclient-client)
        -   [UpdatePrimaryRoute](#updateprimaryrouteflowroutenumbersandmessagingclient-client-string-did-string-route_id)
        -   [UpdateFailoverRoute](#updatefailoverrouteflowroutenumbersandmessagingclient-client-string-did-string-route_id)
    - [Messaging](#messaging)
        -   [SendSMS](#sendsmsflowroutenumbersandmessagingclient-client-string-from_did)
        -   [GetMessages](#getmessagesflowroutenumbersandmessagingclient-client)
        -   [GetMDRDetail](#getmdrdetailflowroutenumbersandmessagingclient-client-string-id)

- [Errors](#errors)

* * * * *
Requirements 
------------

-   Flowroute [API
    credentials](https://manage.flowroute.com/accounts/preferences/api/)
-   [Visual Studio](https://www.visualstudio.com/) 2017 for compilation
-   [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library/)
    1.3 or higher
-   Any of the supported [.NET
    platforms](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support)
    which implements .NET Standard 1.3
-   [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) 10.0.3
    or higher

* * * * *
Installation 
------------

1. First, start a shell session and clone the SDK:

#### via HTTPS:

    git clone https://github.com/flowroute/flowroute-sdk-v3-dot-net.git
                        

#### via SSH:

    git@github.com:flowroute/flowroute-sdk-v3-dot-net.git
                        

2. Make a note of the location of your newly-created `flowroute-sdk-v3-dot-net` directory. This version of the SDK was compiled and tested using Visual Studio 2017 for Mac and features two different solutions, **FlowrouteNumbersAndMessaging**, and its accompanying test, **testSDK**. To build your solutions, launch Visual Studio 2017 on your machine.

3. Open **FlowrouteNumbersAndMessaging.sln** from the root directory of the SDK. Once your solution is loaded, modify **Configuration.cs** by updating `BasicAuthUserName` with your Flowroute API Access Key and `BasicAuthPassword` with your Flowroute API Secret Key.

### Credentials 

![dot-net-config.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/dot-net-config.png?raw=true)

4. Select **Build \> Build All** from the menu. You should see a confirmation of a successful build.

5. Next, open **testSDK.sln** from the testSDK subdirectory. Expand **testSDK \> References** in the **Solution Pad**. Check that FlowrouteNumbersandMessaging, Newtonsoft.Json, and all the System references are loaded. If not, right-click **References** and select **Edit References**. To add `FlowrouteNumbersandMessaging.Standard.dll`, select **.Net Assembly** and search for it. Select the checkbox and click **OK**.

![flowroute-reference.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/dot-net-error.png?raw=true)

If the reference is missing, click **Browse** and locate the file.

![missing-reference.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/missing-reference.png/?raw=true)


6. For other missing references, select **Edit References \> All**, and repeat the search and selection process of the previous step.

7. Expand **Packages** in the **Solution Pad** and check that `Newtonsoft.Json 10.0.3` has been added. If not, right-click **Packages** and select **Add Packages**. Search and select the missing package.

8. Repeat step 4 to build the test solution.

* * * * *
Usage
-----

In Flowroute's approach to building the .NET library v3, HTTP requests are handled by an API client object accessed by methods defined in **Program.cs**. To run the tests, select **Program.cs** from the Solution Pad then select **Run \> Start Debugging** from the menu. The methods in the file are used to perform messaging, number management, and route management within the .NET Library.

### Instantiate API Client

After importing all the required references and packages and declaring the class, we instantiate the API client object.
```cs
// Instantiate API client and authenticate
    FlowrouteNumbersAndMessagingClient client = new FlowrouteNumbersAndMessagingClient(FlowrouteNumbersAndMessaging.Standard.Configuration.BasicAuthUserName, FlowrouteNumbersAndMessaging.Standard.Configuration.BasicAuthPassword);
```

Methods 
-------

The following section will demonstrate the capabilities of Numbers v2 and Messages v2.1 that are wrapped in our .NET library. Note that the example responses may not show the expected results from the method
calls in **Program.cs**. These examples have been formatted using Mac's `pbpaste` and `jq`. To learn more, see [Quickly Tidy Up JSON from the Command Line](http://onebigfunction.com/vim/2015/02/02/quickly-tidying-up-json-from-the-command-line-and-vim/).

### Number Management

Flowroute .NET Library v3 allows you to make HTTP requests to the `numbers` resource of Flowroute API v2:
`https://api.flowroute.com/v2/numbers`

#### GetAvailableAreaCodes(FlowrouteNumbersAndMessagingClient client) 

The method declares `limit`, `offset`, and `maxSetupCost` as parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-available-area-codes/).

##### Method Declaration

    private static ArrayList GetAvailableAreaCodes(FlowrouteNumbersAndMessagingClient client)
    {
        ArrayList return_list = new ArrayList();

        int? limit = 3;
        int? offset = 0;
        double? maxSetupCost = 3.25;

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


##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of area code objects in JSON format.

    {
      "data": [
        {
          "type": "areacode",
          "id": "201",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/available/exchanges?areacode=201"
          }
        },
        {
          "type": "areacode",
          "id": "202",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/available/exchanges?areacode=202"
          }
        },
        {
          "type": "areacode",
          "id": "203",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/available/exchanges?areacode=203"
          }
        }
      ],
      "links": {
        "self": "https://api.flowroute.com/v2/numbers/available/areacodes?max_setup_cost=3&limit=3&offset=0",
        "next": "https://api.flowroute.com/v2/numbers/available/areacodes?max_setup_cost=3&limit=3&offset=3"
      }
    }


#### GetAvailableExchangeCodes(FlowrouteNumbersAndMessagingClient client) 
The method declares `limit`, `offset`, `maxSetupCost`, and `areacode` as parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-available-exchanges/).

##### Method Declaration 

    private static ArrayList GetAvailableExchangeCodes(FlowrouteNumbersAndMessagingClient client)
    {
        ArrayList return_list = new ArrayList();

        int? limit = 2;
        int? offset = 0;
        double? maxSetupCost = 3.40;
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


##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of exchange objects in JSON format.

    {
      "data": [
        {
          "type": "exchange",
          "id": "347215",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/available?starts_with=1347215"
          }
        },
        {
          "type": "exchange",
          "id": "347325",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/available?starts_with=1347325"
          }
        },
        {
          "type": "exchange",
          "id": "347331",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/available?starts_with=1347331"
          }
        }
      ],
      "links": {
        "self": "https://api.flowroute.com/v2/numbers/available/exchanges?areacode=347&limit=3&offset=0",
        "next": "https://api.flowroute.com/v2/numbers/available/exchanges?areacode=347&limit=3&offset=3"
      }
    }


#### GetAvailableNumbers(FlowrouteNumbersAndMessagingClient client) 

The method declares `startsWith`, `contains`, `endsWith`, `rateCenter`, `state`, `limit`, and `offset` as parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/search-for-purchasable-phone-numbers/).

##### Method Declaration 

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


##### Example Response 

On success, the HTTP status code in the response header is 200 OK and
the response body contains an array of phone number objects in JSON
format.

    {
      "data": [
        {
          "attributes": {
            "rate_center": "nwyrcyzn01",
            "value": "16463439507",
            "monthly_cost": 1.25,
            "state": "ny",
            "number_type": "standard",
            "setup_cost": 1
          },
          "type": "number",
          "id": "16463439507",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/16463439507"
          }
        },
        {
          "attributes": {
            "rate_center": "nwyrcyzn01",
            "value": "16463439617",
            "monthly_cost": 1.25,
            "state": "ny",
            "number_type": "standard",
            "setup_cost": 1
          },
          "type": "number",
          "id": "16463439617",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/16463439617"
          }
        },
        {
          "attributes": {
            "rate_center": "nwyrcyzn01",
            "value": "16463439667",
            "monthly_cost": 1.25,
            "state": "ny",
            "number_type": "standard",
            "setup_cost": 3.99
          },
          "type": "number",
          "id": "16463439667",
          "links": {
            "related": "https://api.flowroute.com/v2/numbers/16463439667"
          }
        }
      ],
      "links": {
        "self": "https://api.flowroute.com/v2/numbers/available?contains=3&ends_with=7&starts_with=1646&limit=3&offset=0",
        "next": "https://api.flowroute.com/v2/numbers/available?contains=3&ends_with=7&starts_with=1646&limit=3&offset=3"
      }
    }



#### GetNumbers(FlowrouteNumbersAndMessagingClient client) 

The method declares startsWith, contains, endsWith, rateCenter, state,
limit, and offset as parameters which you can learn more about in the
[API
reference](https://developer.flowroute.com/api/numbers/v2.0/list-account-phone-numbers/).

##### Method Declaration 

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



##### Example Response 

On success, the HTTP status code in the response header is 200 OK and
the response body contains an array of phone number objects in JSON
format.

    {
      "data": [
        {
          "attributes": {
            "rate_center": "oradell",
            "value": "12012673227",
            "alias": null,
            "state": "nj",
            "number_type": "standard",
            "cnam_lookups_enabled": true
          },
          "type": "number",
          "id": "12012673227",
          "links": {
            "self": "https://api.flowroute.com/v2/numbers/12012673227"
          }
        },
        {
          "attributes": {
            "rate_center": "jerseycity",
            "value": "12014845220",
            "alias": null,
            "state": "nj",
            "number_type": "standard",
            "cnam_lookups_enabled": true
          },
          "type": "number",
          "id": "12014845220",
          "links": {
            "self": "https://api.flowroute.com/v2/numbers/12014845220"
          }
        }
      ],
      "links": {
        "self": "https://api.flowroute.com/v2/numbers?starts_with=1201&limit=3&offset=0"
      }
    }


#### GetNumberDetails(FlowrouteNumbersAndMessagingClient client, string id) 

The method declares the id as a variable which you can learn more about
in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-phone-number-details/). 

##### Method Declaration 

    public static dynamic GetNumberDetails(FlowrouteNumbersAndMessagingClient client, string id) 
    {
        // User the Numbers Controller from our Client
        NumbersController numbers = client.Numbers;

        Console.WriteLine("---------------------------\nList Phone Number Details:\n");
        dynamic result = numbers.GetPhoneNumberDetails(id);
        Console.WriteLine(result);
        return result;

    }


##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains a phone number object in JSON format.

    {
      "included": [
        {
          "attributes": {
            "route_type": "sip-reg",
            "alias": "sip-reg",
            "value": null
          },
          "type": "route",
          "id": "0",
          "links": {
            "self": "https://api.flowroute.com/v2/routes/0"
          }
        }
      ],
      "data": {
        "relationships": {
          "cnam_preset": {
            "data": null
          },
          "e911_address": {
            "data": null
          },
          "failover_route": {
            "data": null
          },
          "primary_route": {
            "data": {
              "type": "route",
              "id": "0"
            }
          }
        },
        "attributes": {
          "rate_center": "millbrae",
          "value": "16502390214",
          "alias": null,
          "state": "ca",
          "number_type": "standard",
          "cnam_lookups_enabled": true
        },
        "type": "number",
        "id": "16502390214",
        "links": {
          "self": "https://api.flowroute.com/v2/numbers/16502390214"
        }
      },
      "links": {
        "self": "https://api.flowroute.com/v2/numbers/16502390214"
      }
    }

### Route Management 

The Flowroute .NET Library v3 allows you to make HTTP requests to the `routes` resource of Flowroute API v2: `https://api.flowroute.com/v2/routes`

#### CreateInboundRoute(FlowrouteNumbersAndMessagingClient client) 

The method declares the route object in JSON format as a parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/create-an-inbound-route/). In the following example, we declare a test route with `route_type` "host".

##### Method Declaration

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


##### Example Response 

On success, the HTTP status code in the response header is `201 Created` and the response body contains a route object in JSON format.

    {
      "data": {
        "attributes": {
          "alias": "Test Route",
          "route_type": "host",
          "value": "www.flowroute.com"
        },
        "id": "98396",
        "links": {
          "self": "https://api.flowroute.com/routes/98396"
        },
        "type": "route"
      },
      "links": {
        "self": "https://api.flowroute.com/routes/98396"
      }
    }



#### GetInboundRoutes(FlowrouteNumbersAndMessagingClient client) 

The method declares limit and offset as parameters which you can learn more about in the [API
reference](https://developer.flowroute.com/api/numbers/v2.0/list-inbound-routes/).

##### Method Declaration 

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


##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of route objects in JSON format.

    {
      "data": [
        {
          "attributes": {
            "route_type": "sip-reg",
            "alias": "sip-reg",
            "value": null
          },
          "type": "route",
          "id": "0",
          "links": {
            "self": "https://api.flowroute.com/v2/routes/0"
          }
        },
        {
          "attributes": {
            "route_type": "number",
            "alias": "PSTNroute1",
            "value": "12065551212"
          },
          "type": "route",
          "id": "83834",
          "links": {
            "self": "https://api.flowroute.com/v2/routes/83834"
          }
        }
      ],
      "links": {
        "self": "https://api.flowroute.com/v2/routes?limit=2&offset=0",
        "next": "https://api.flowroute.com/v2/routes?limit=2&offset=2"
      }
    }


#### UpdatePrimaryRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route\_id) 

The method updates a DID with the route\_id parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/update-number-primary-voice-route/).

##### Method Declaration 

     private static void UpdatePrimaryRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route_id)
    {
        RoutesController routes = client.Routes;
        string result = routes.UpdatePrimaryVoiceRouteForAPhoneNumber(DID, route_id);
        Console.WriteLine(result);
    }


##### Example Response 

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.

    204: No Content


#### UpdateFailoverRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route\_id) 

The method updates a DID with the `route_id` parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/update-number-failover-voice-route/).

##### Method Declaration 

    private static void UpdateFailoverRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route_id)
    {
        RoutesController routes = client.Routes;
        string result = routes.UpdateFailoverVoiceRouteForAPhoneNumber(DID, route_id);
        Console.WriteLine(result);
    }


##### Example Response 

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.

    204: No Content


### Messaging 

The Flowroute .NET Library v3 allows you to make HTTP requests to the `messages` resource of Flowroute API v2.1: `https://api.flowroute.com/v2.1/messages`

#### SendSMS(FlowrouteNumbersAndMessagingClient client, string from\_did) 

The method declares a message object in JSON format as a parameter which you can learn more about in the API References for [MMS](https://developer.flowroute.com/api/messages/v2.1/send-an-mms/) and [SMS](https://developer.flowroute.com/api/messages/v2.1/send-an-sms/). In the following example, we are sending an SMS from the previously declared `from_did` to your mobile number.

##### Method Declaration {#examplerequest-10}

      private static void SendSMS(FlowrouteNumbersAndMessagingClient client, string from_did)
    {
        Message msg = new Message();
        msg.From = from_did;
        msg.To = "YOUR_MOBILE_NUMBER"; // Replace with your mobile number to receive messages sent from your Flowroute account
        msg.Body = "Hi Chris";

        MessagesController messages = client.Messages;
        string result = messages.CreateSendAMessage(msg);
        Console.WriteLine(result);
    }


Note that this function call is currently commented out. Uncomment to test the `SendSMS` method.

##### Example Response 

On success, the HTTP status code in the response header is `202 Accepted` and the response body contains the message record ID with mdr2 prefix.

    {
      "data": {
        "links": {
          "self": "https://api.flowroute.com/v2.1/messages/mdr2-39cadeace66e11e7aff806cd7f24ba2d"
        },
        "type": "message",
        "id": "mdr2-39cadeace66e11e7aff806cd7f24ba2d"
      }
    }



#### GetMessages(FlowrouteNumbersAndMessagingClient client) 

The method declares `startDate`, `endDate`, `limit`, and `offset` as parameters which you can learn more about in the [API Reference](https://developer.flowroute.com/api/messages/v2.1/look-up-set-of-messages/).

##### Method Declaration 

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


##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of message objects in JSON format.

    {
      "data": [
        {
          "attributes": {
            "body": "Hello are you there? ",
            "status": "delivered",
            "direction": "inbound",
            "amount_nanodollars": 4000000,
            "to": "12012673227",
            "message_encoding": 0,
            "timestamp": "2017-12-22T01:52:39.39Z",
            "delivery_receipts": [],
            "amount_display": "$0.0040",
            "from": "12061231234",
            "is_mms": false,
            "message_type": "longcode"
          },
          "type": "message",
          "id": "mdr2-ca82be46e6ba11e79d08862d092cf73d"
        },
        {
          "attributes": {
            "body": "test sms on v2",
            "status": "message buffered",
            "direction": "outbound",
            "amount_nanodollars": 4000000,
            "to": "12061232634",
            "message_encoding": 0,
            "timestamp": "2017-12-21T16:44:34.93Z",
            "delivery_receipts": [
              {
                "status": "message buffered",
                "status_code": 1003,
                "status_code_description": "Message accepted by Carrier",
                "timestamp": "2017-12-21T16:44:35.00Z",
                "level": 2
              },
              {
                "status": "smsc submit",
                "status_code": null,
                "status_code_description": "Message has been sent",
                "timestamp": "2017-12-21T16:44:35.00Z",
                "level": 1
              }
            ],
            "amount_display": "$0.0040",
            "from": "12012673227",
            "is_mms": false,
            "message_type": "longcode"
          },
          "type": "message",
          "id": "mdr2-39cadeace66e11e7aff806cd7f24ba2d"
        }
      ],
      "links": {
        "next": "https://api.flowroute.com/v2.1/messages?limit=2&start_date=2017-12-01T00%3A00%3A00%2B00%3A00&end_date=2018-01-08T00%3A00%3A00%2B00%3A00&offset=2"
      }
    }


#### GetMDRDetail(FlowrouteNumbersAndMessagingClient client, string id) 

The method declares a message `id` in MDR2 format as a variable which you can learn more about in the [API
Reference](https://developer.flowroute.com/api/messages/v2.1/look-up-a-message-detail-record/). In the following example, we retrieve the details of the first message in our look\_up\_a\_set\_of\_messages search result.

##### Method Declaration 

      private static void GetMDRDetail(FlowrouteNumbersAndMessagingClient client, string id)
    {
        MessagesController messages = client.Messages;

        dynamic mdr_data = messages.GetLookUpAMessageDetailRecord(id);   
        Console.WriteLine(mdr_data);
    }
    result = messages_controller.look_up_a_message_detail_record(message_id)
    pprint.pprint(result)


##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains the message object for our specified message `id`.

    {
      "data": {
        "attributes": {
          "body": "Hello are you there? ",
          "status": "delivered",
          "direction": "inbound",
          "amount_nanodollars": 4000000,
          "to": "12012673227",
          "message_encoding": 0,
          "timestamp": "2017-12-22T01:52:39.39Z",
          "delivery_receipts": [],
          "amount_display": "$0.0040",
          "from": "12061232634",
          "is_mms": false,
          "message_type": "longcode"
        },
        "type": "message",
        "id": "mdr2-ca82be46e6ba11e79d08862d092cf73d"
      }
    }


Errors 
------

In cases of HTTP errors, the .NET library displays a pop-up window with an error message next to the line of code that caused the error. You can add more error logging if necessary.

### Example Error 

![dot-net-error.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/dot-net-error.png?raw=true)
