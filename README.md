The Flowroute .NET Library v3 provides methods for interacting with [Numbers v2](https://developer.flowroute.com/api/numbers/v2.0/) &endash; which includes inbound voice routes, E911 addresses, and CNAM storage &endash; and [Messages v2.1](https://developer.flowroute.com/api/messages/v2.1/) of the [Flowroute](https://www.flowroute.com) API.

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
            -   [etNumberDetails](#getnumberdetailsflowroutenumbersandmessagingclient-client-string-id)
        - [Route Management](#routemanagement)
            -   [CreateInboundRoute](#createinboundrouteflowroutenumbersandmessagingclient-client)
            -   [GetInboundRoutes](#getinboundroutesflowroutenumbersandmessagingclient-client)
            -   [UpdatePrimaryRoute](#updateprimaryrouteflowroutenumbersandmessagingclient-client-string-did-string-route_id)
            -   [UpdateFailoverRoute](#updatefailoverrouteflowroutenumbersandmessagingclient-client-string-did-string-route_id)
        - [Messaging](#messaging)
            -   [SendSMS](#sendsmsflowroutenumbersandmessagingclient-client-string-from_did)
            -   [GetMessages](#getmessagesflowroutenumbersandmessagingclient-client)
            -   [GetMDRDetail](#getmdrdetailflowroutenumbersandmessagingclient-client-string-id)
        - [E911 Address Management](#e911-address-management)
            -   [GetE911Records](#gete911recordsflowroutenumbersandmessagingclient-client)
            -   [ListE911Details](#liste911detailsflowroutenumbersandmessagingclient-client-string-id)
            -   [ValidateE911](#validatee911flowroutenumbersandmessagingclient-client)
            -   [CreateE911Address](#createe911address-flowroutenumbersandmessagingclient-client)
            -   [UpdateE911Address](#updatee911addressflowroutenumbersandmessagingclient-client-string-e911_id-string-new_label)
            -   [AssociateE911](#associatee911flowroutenumbersandmessagingclient-client-string-number_id-string-e911_id)
            -   [ListE911Associations](#liste911associationsflowroutenumbersandmessagingclient-client-string-e911_id)
            -   [UnassociateE911](#unassociatee911flowroutenumbersandmessagingclient-client-string-number_id)
            -   [DeleteE911](#deletee911flowroutenumbersandmessagingclient-client-string-e911_id)
        - [CNAM Record Management](#e911-address-management)
            -   [GetCNAMRecords](#)
            -   [GetCNAMDetail](#)
            -   [CreateCNAM](#)
            -   [AssociateCNAM](#)
            -   [UnassociateCNAM](#)
            -   [AssociateE911](#)

    - [Errors](#errors)

* * * * *
Requirements 
------------

-   Flowroute [API credentials](https://manage.flowroute.com/accounts/preferences/api/)
-   [Visual Studio](https://www.visualstudio.com/) 2017 for compilation
-   [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library/) 1.3 or higher
-   Any of the supported [.NET platforms](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support)
    which implements .NET Standard 1.3
-   [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) 10.0.3 or higher

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

4. Select **Build > Build All** from the menu. You should see a confirmation of a successful build.

5. Next, open **testSDK.sln** from the testSDK subdirectory. Expand **testSDK > References** in the **Solution Pad**. Check that FlowrouteNumbersandMessaging, Newtonsoft.Json, and all the System references are loaded. If not, right-click **References** and select **Edit References**. To add `FlowrouteNumbersandMessaging.Standard.dll`, select **.Net Assembly** and search for it. Select the checkbox and click **OK**.

![flowroute-reference.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/dot-net-error.png?raw=true)

If the reference is missing, click **Browse** and locate the file.

![missing-reference.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/missing-reference.png/?raw=true)


6. For other missing references, select **Edit References > All**, and repeat the search and selection process of the previous step.

7. Expand **Packages** in the **Solution Pad** and check that `Newtonsoft.Json 10.0.3` has been added. If not, right-click **Packages** and select **Add Packages**. Search and select the missing package.

8. Repeat step 4 to build the test solution.

* * * * *
Usage
-----

In Flowroute's approach to building the .NET library v3, HTTP requests are handled by an API client object accessed by methods defined in **Program.cs**. To run the tests, select **Program.cs** from the Solution Pad then select **Run > Start Debugging** from the menu. The methods in the file are used to perform number management &endash; including phone numbers, routes, E911 addresses, and CNAM record management &endash; and messaging within the .NET Library.

### Instantiate API Client

After importing all the required references and packages and declaring the class, we instantiate the API client object.
```cs
// Instantiate API client and authenticate
    FlowrouteNumbersAndMessagingClient client = new FlowrouteNumbersAndMessagingClient(FlowrouteNumbersAndMessaging.Standard.Configuration.BasicAuthUserName, FlowrouteNumbersAndMessaging.Standard.Configuration.BasicAuthPassword);
```

Methods 
-------

The following section will demonstrate the capabilities of Number Management v2 (i.e. phone numbers, routes, E911 addresses, CNAM records) and Messaging v2.1 that are wrapped in our .NET library. Note that the example responses may not show the expected results from the method
calls in **Program.cs**. These examples have been formatted using Mac's `pbpaste` and `jq`. To learn more, see [Quickly Tidy Up JSON from the Command Line](http://onebigfunction.com/vim/2015/02/02/quickly-tidying-up-json-from-the-command-line-and-vim/).

### Number Management

The Flowroute .NET Library v3 allows you to make HTTP requests to the `numbers` resource of Flowroute API v2:
`https://api.flowroute.com/v2/numbers`

#### GetAvailableAreaCodes(FlowrouteNumbersAndMessagingClient client) 

The method declares variables `limit`, `offset`, and `maxSetupCost` which are passed as arguments for listing the available area codes. You can learn more about these query parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-available-area-codes/).

##### Method Declaration
```cs
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
```

##### Example Request
The following line in **Program.cs** calls the `GetAvailableAreaCodes` method:
`ArrayList available_areacodes = GetAvailableAreaCodes(client);`

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of area code objects in JSON format.
```
Available Area Code:
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
```

#### GetAvailableExchangeCodes(FlowrouteNumbersAndMessagingClient client) 
The method declares variables `limit`, `offset`, `maxSetupCost`, and `areacode` which are passed as arguments for listing the available exchange codes. You can learn more about these query parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-available-exchanges/).

##### Method Declaration 
```cs
private static ArrayList GetAvailableExchangeCodes(FlowrouteNumbersAndMessagingClient client)
{
    ArrayList return_list = new ArrayList();

    int? limit = 2;
    int? offset = 0;
    double? maxSetupCost = 3.40;
    string areacode = "347";

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
```

##### Example Request
The following line in **Program.cs** calls the `GetAvailableExchangeCodes` method:
`ArrayList available_exchange_codes = GetAvailableExchangeCodes(client);`

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of exchange objects in JSON format.
```
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
```

#### GetAvailableNumbers(FlowrouteNumbersAndMessagingClient client) 

The method declares variables `startsWith`, `contains`, `endsWith`, `rateCenter`, `state`, `limit`, and `offset` which are passed as arguments for listing the purchasable phone numbers. You can learn more about these query parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/search-for-purchasable-phone-numbers/).

##### Method Declaration 
```cs
private static ArrayList GetAvailableNumbers(FlowrouteNumbersAndMessagingClient client)
{
    string startsWith = "646";
    string contains = null;
    string endsWith = null;
    string rateCenter = null;
    string state = null;

    int? limit = 3;
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
```

##### Example Request

The following line in **Program.cs** calls the `GetAvailableNumbers` method:
`ArrayList available_numbers = GetAvailableNumbers(client);`

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of purchasable phone number objects in JSON format.
```
Available Area Codes:    
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
```

#### GetNumbers(FlowrouteNumbersAndMessagingClient client) 
The method declares variables `startsWith`, `contains`, `endsWith`, `rateCenter`, `state`, `limit`, and `offset` which are passed as arguments for retrieving the phone numbers on your Flowroute account. You can learn more about these query parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-account-phone-numbers/).

##### Method Declaration 
```cs
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
```

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of phone number objects in JSON
format.
```
Phone Number Record:
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
```

#### GetNumberDetails(FlowrouteNumbersAndMessagingClient client, string id) 


The method accepts a phone number ID as a parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-phone-number-details/). In the following example, we pass the value of the first item in the returned JSON array, `our_numbers`, from our previous [GetNumbers](#getnumbersflowroutenumbersandmessagingclient-client) method call.

##### Method Declaration 
```cs
    public static dynamic GetNumberDetails(FlowrouteNumbersAndMessagingClient client, string id) 
    {
        // User the Numbers Controller from our Client
        NumbersController numbers = client.Numbers;

        Console.WriteLine("---------------------------\nList Phone Number Details:\n");
        dynamic result = numbers.GetPhoneNumberDetails(id);
        Console.WriteLine(result);
        return result;

    }
```
##### Example Request
The following line in **Program.cs** calls the `GetNumberDetails` method after initializing `our_numbers`:
```
ArrayList our_numbers = GetNumbers(client);
dynamic number_details = GetNumberDetails(client, (string)our_numbers[0]);
```

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains a detailed phone number object in JSON format.
List Phone Number Details:
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

The method first invokes the RoutesController and instantiates `body` as a `NewRoute` object, then we initialize the different route attributes with example values. The different attributes that a `NewRoute` object can have include `Alias`, `RouteType`, and `Value`. Learn more about the different body parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/create-an-inbound-route/). We then pass `body` as an argument for the `CreateInboundRoute` method.

##### Method Declaration
```cs
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
```

##### Example Request
The following line in **Program.cs** calls the `CreateInboundRoute` method:
`CreateInboundRoute(client);`

##### Example Response 

On success, the HTTP status code in the response header is `201 Created` and the response body contains a route object in JSON format.
```
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
```

#### GetInboundRoutes(FlowrouteNumbersAndMessagingClient client) 

The method declares limit and offset as parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-inbound-routes/).

##### Method Declaration 
```cs
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
```

##### Example Request
The following line in **Program.cs** calls the `GetInboundRoutes` method:
`ArrayList inbound_routes = GetInboundRoutes(client);`

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of route objects in JSON format. Note that this demo method iterates through all the route records on your account filtered by the parameters that you specify. The following example response has been clipped for brevity's sake.
```
Inbound Routes:
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
    "self": "https://api.flowroute.com/v2/routes?limit=10&offset=0",
    "next": "https://api.flowroute.com/v2/routes?limit=10&offset=10"
  }
}
```

#### UpdatePrimaryRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route\_id) 

The method updates a DID with the route\_id parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/update-number-primary-voice-route/).

##### Method Declaration 
```cs
private static void UpdatePrimaryRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route_id)
{
    RoutesController routes = client.Routes;
    string result = routes.UpdatePrimaryVoiceRouteForAPhoneNumber(DID, route_id);
    Console.WriteLine(result);
}
```

##### Example Request

The following line in **Program.cs** calls the `UpdatePrimaryRoute` method:
`UpdatePrimaryRoute(client, (string)our_numbers[0], (string)route_id);`

##### Example Response 

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.
`204 No Content`


#### UpdateFailoverRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route\_id) 

The method updates a DID with the `route_id` parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/update-number-failover-voice-route/).

##### Method Declaration 
```cs
private static void UpdateFailoverRoute(FlowrouteNumbersAndMessagingClient client, string DID, string route_id)
{
    RoutesController routes = client.Routes;
    string result = routes.UpdateFailoverVoiceRouteForAPhoneNumber(DID, route_id);
    Console.WriteLine(result);
}
```

##### Example Request

The following line in **Program.cs** calls the `UpdateFailoverRoute` method:
`UpdateFailoverRoute(client, (string)our_numbers[0], (string)route_id);`

##### Example Response 

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.
`204: No Content`


### Messaging 

The Flowroute .NET Library v3 allows you to make HTTP requests to the `messages` resource of Flowroute API v2.1: `https://api.flowroute.com/v2.1/messages`

#### SendSMS(FlowrouteNumbersAndMessagingClient client, string from_did, string to_did, string callback=null) 

The method first instantiates `msg` as a `Message` object, then initializes the different Message attributes with example values. The different attributes that a `Message` object can have include `From`, `To`, `Body` and an optional `Callback` URL for posting delivery receipt notifications to. You can learn more about the different body parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/create-an-inbound-route/). We then pass `msg` as an argument for the `CreateSendAMessage` method.

##### Method Declaration {#examplerequest-10}
```cs
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
```

##### Example Request

The following line in **Program.cs** calls the `SendSMS` method and specifies a delivery callback URL after initializing `our_numbers` and `target_number`:
```
string target_number = "YOUR MOBILE NUMBER HERE";
ArrayList our_numbers = GetNumbers(client);
SendSMS(client, (string)our_numbers[0], target_number, "http://httpbin.org/status/:code");
```

##### Example Response 

On success, the HTTP status code in the response header is `202 Accepted` and the response body contains the message record ID with `mdr2` prefix.
```
{
  "data": {
    "links": {
      "self": "https://api.flowroute.com/v2.1/messages/mdr2-39cadeace66e11e7aff806cd7f24ba2d"
    },
    "type": "message",
    "id": "mdr2-39cadeace66e11e7aff806cd7f24ba2d"
  }
}
```

#### GetMessages(FlowrouteNumbersAndMessagingClient client) 

The method declares `startDate`, `endDate`, `limit`, and `offset` as parameters which you can learn more about in the [API Reference](https://developer.flowroute.com/api/messages/v2.1/look-up-set-of-messages/). 

##### Method Declaration 
```cs
public static ArrayList GetMessages(FlowrouteNumbersAndMessagingClient client)
{
    ArrayList return_list = new ArrayList();
    int? limit = 20;
    int? offset = 0;

    // Find all messages since December 1, 2017
    DateTime startDate = new DateTime(2017, 12, 1);
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
```

##### Example Request

The following line in **Program.cs** calls the `GetMessages` method:
`ArrayList our_messages = GetMessages(client);`

##### Example Response 

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of message objects in JSON format. Note that the following example response has been clipped for brevity.
```
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
        "next": "https://api.flowroute.com/v2.1/messages?limit=20&start_date=2017-12-01T00%3A00%3A00%2B00%3A00"
      }
    }
```

#### GetMDRDetail(FlowrouteNumbersAndMessagingClient client, string id) 

The method accepts a message ID as a parameter which you can learn more about in the [API
Reference](https://developer.flowroute.com/api/messages/v2.1/look-up-a-message-detail-record/). In the following example, we retrieve the details of the first message in the resulting array, `our_messages`, of our previous call to `GetMessages`.

##### Method Declaration 
```cs
private static void GetMDRDetail(FlowrouteNumbersAndMessagingClient client, string id)
{
    MessagesController messages = client.Messages;

    dynamic mdr_data = messages.GetLookUpAMessageDetailRecord(id);   
    Console.WriteLine(mdr_data);
}
```
##### Example Request

The following line in **Program.cs** calls the `GetMDRDetail` method after initializing `our_messages`:
```
ArrayList our_messages = GetMessages(client);
GetMDRDetail(client, (string)our_messages[0]);
```

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


### E911 Address Management

The Flowroute .NET Library v3 allows you to make HTTP requests to the `e911s` resource of Flowroute API v2:
`https://api.flowroute.com/v2/e911s`

#### GetE911Records(FlowrouteNumbersAndMessagingClient client) 

The method declares `limit` and `offset` as parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-account-e911-addresses/).

##### Method Declaration
```
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
```

##### Example Request

The following line in **Program.cs** calls the `GetE911Records` method:
`ArrayList our_e911s = GetE911Records(client);`


##### Example Response

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of e911 objects in JSON format. Note that this demo method iterates through all the E911 records on your account filtered by the parameters that you specify. The following example response has been clipped for brevity's sake.

```
E911 Record:
{'data': [{'attributes': {'address_type': 'Lobby',
                          'address_type_number': '12',
                          'city': 'Seattle',
                          'country': 'USA',
                          'first_name': 'Maria',
                          'label': 'Example E911',
                          'last_name': 'Bermudez',
                          'state': 'WA',
                          'street_name': '20th Ave SW',
                          'street_number': '7742',
                          'zip': '98106'},
           'id': '20930',
           'links': {'self': 'https://api.flowroute.com/v2/e911s/20930'},
           'type': 'e911'},
          {'attributes': {'address_type': 'Apartment',
                          'address_type_number': '12',
                          'city': 'Seattle',
                          'country': 'US',
                          'first_name': 'Something',
                          'label': '5th E911',
                          'last_name': 'Someone',
                          'state': 'WA',
                          'street_name': 'Main St',
                          'street_number': '645',
                          'zip': '98104'},
           'id': '20707',
           'links': {'self': 'https://api.flowroute.com/v2/e911s/20707'},
           'type': 'e911'}],
 'links': {'next': 'https://api.flowroute.com/v2/e911s?limit=100&offset=100',
           'self': 'https://api.flowroute.com/v2/e911s?limit=100&offset=0'}}
```

#### ListE911Details(FlowrouteNumbersAndMessagingClient client, string id)

The method requires a string parameter, `id`, as a parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-account-e911-addresses/). The value that gets assigned to `id` is the first record of the resulting array, `our_e911s` from the `GetE911Records` method call.

##### Method Declaration
```
public static dynamic ListE911Details(FlowrouteNumbersAndMessagingClient client, string id)
        {
            // Use the E911 Controller from our Client
            E911Controller e911s = client.E911s;

            Console.WriteLine("---------------------------\nList E911 Details:\n");
            dynamic result = e911s.E911Details(id);
            Console.WriteLine(result);
            return result;
        }
```

##### Example Request

The following line in **Program.cs** calls the `ListE911Details` method after initializing `our_e911s`:
``` 
ArrayList our_e911s = GetE911Records(client);
ListE911Details(client, (string)our_e911s[0]);
```

##### Example Response

On success, the HTTP status code in the response header is `200 OK` and the response body contains a detailed e911 object in JSON format. 

```
List E911 Details:
{
  "data": {
    "attributes": {
      "address_type": "Suite",
      "address_type_number": "333",
      "city": "Seattle",
      "country": "US",
      "first_name": "Albus",
      "label": "Office Space III",
      "last_name": "Rasputin, Jr.",
      "state": "WA",
      "street_name": "Main St",
      "street_number": "666",
      "zip": "98101"
    },
    "id": "21845",
    "links": {
      "self": "https://api.flowroute.com/v2/e911s/21845"
    },
    "type": "e911"
  }
}
```
#### ValidateE911(FlowrouteNumbersAndMessagingClient client)

In the following example request, we instantiate `body` as an `E911` object, then initialize its different attributes with example values. The different attributes that an `E911Record` object can have include `Label`, `FirstName`, `LastName`, `StreetName`, `StreetNumber`, `AddressType`, `AddressTypeNumber`, `City`, `State`, `Country`, and `Zip`. Learn more about the different body parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/validate-e911-address/). We then pass `body` as an argument for the `ValidateE911` method.

##### Method Declaration
```
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
```

##### Example Request

The following line in **Program.cs** calls the `ValidateE911` method:
`ValidateE911(client);`

##### Example Response

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content. On error, a printable representation of the detailed API response is displayed.

`204 No Content`

#### CreateE911Address (FlowrouteNumbersAndMessagingClient client)

In the following example request, we instantiate `body` as an `E911` object, then initialize its different attributes with example values. The different attributes that an `E911Record` object can have include `Label`, `FirstName`, `LastName`, `StreetName`, `StreetNumber`, `AddressType`, `AddressTypeNumber`, `City`, `State`, `Country`, and `Zip`. Learn more about the different body parameters in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/validate-e911-address/). We then pass `body` as an argument for the `CreateE911Address` method.

##### Method Declaration
```
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
```

##### Example Request

The following line in **Program.cs** calls the `CreateE911Address` method:
`CreateE911Address(client);`

##### Example Response

On success, the HTTP status code in the response header is `201 Created` and the response body contains the newly created e911 object in JSON format. On error, a printable representation of the detailed API response is displayed.

```
--Create an E911 Address
{
  "data": {
    "attributes": {
      "address_type": "Suite",
      "address_type_number": "200",
      "city": "Seattle",
      "country": "US",
      "first_name": "John",
      "label": "Potbelly",
      "last_name": "Doe",
      "state": "WA",
      "street_name": "3rd Ave",
      "street_number": "1111",
      "zip": "98101"
    },
    "id": "21907",
    "links": {
      "self": "https://api.flowroute.com/v2/e911s/21907"
    },
    "type": "e911"
  }
}
```

#### UpdateE911Address(FlowrouteNumbersAndMessagingClient client, string e911_id, string new_label)

The method accepts an E911 record ID and an E911 address label as parameters. Learn more about the different E911 attributes that you can update in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/update-and-validate-existing-e911-address/). In the following example, we will update the `label` of the first record of the resulting array, `our_e911s`, to "New Address".
    
##### Method Declaration
```
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
```

##### Example Request

The following line in **Program.cs** calls the `UpdateE911Address` method after initializing `our_e911s`:
```
ArrayList our_e911s = GetE911Records(client);
UpdateE911Address(client, (string)our_e911s[0], "New Address");
```

##### Example Response
On success, the HTTP status code in the response header is `200 OK` and the response body contains the newly updated e911 object in JSON format. On error, a printable representation of the detailed API response is displayed.

```
{
  "data": {
    "attributes": {
      "address_type": "Suite",
      "address_type_number": "333",
      "city": "Seattle",
      "country": "US",
      "first_name": "Albus",
      "label": "New Address",
      "last_name": "Rasputin, Jr.",
      "state": "WA",
      "street_name": "Main St",
      "street_number": "666",
      "zip": "98101"
    },
    "id": "21845",
    "links": {
      "self": "https://api.flowroute.com/v2/e911s/21845"
    },
    "type": "e911"
  }
}
```

#### AssociateE911(FlowrouteNumbersAndMessagingClient client, string number_id, string e911_id)G

The method accepts a long code or toll-free phone number ID and an E911 record ID on your Flowroute account as parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/assign-valid-e911-address-to-phone-number/). In the following example, we call the [GetNumbers](#getnumbersflowroutenumbersandmessagingclient-client) function covered under Number Management to extract and pass the value of the first item in the returned JSON array, `our_numbers`,  pass the first item from  `our_e911s` as the E911 record ID, and then make the association between them.
    
##### Method Declaration
```
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
```

##### Example Request

The following line in **Program.cs** calls the `AssociateE911` method after initializing `our_numbers` and `our_e911s`:
```
ArrayList our_numbers = GetNumbers(client);
ArrayList our_e911s = GetE911Records(client);
AssociateE911(client, (string)our_numbers[0], (string)our_e911s[0]);
```

##### Example Response

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.

`204 No Content`

#### UnassociateE911(FlowrouteNumbersAndMessagingClient client, string number_id)

The method accepts a phone number as a parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/deactivate-e911-service-for-phone-number/). In the following example, we deactivate the E911 service for our previously assigned `number_id`.
    
##### Method Declaration
```
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
```

##### Example Request

The following line in **Program.cs** calls the `UnassociateE911` method:

`UnassociateE911(client, (string)our_numbers[0]);`

##### Example Response

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.

`204 No Content`


#### ListE911Associations(FlowrouteNumbersAndMessagingClient client, string e911_id)

The method accepts an E911 record id as a parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-phone-numbers-associated-with-e911-record/). In the following example, we retrieve the list of phone numbers associated with the first item from `our_e911s`.

##### Method Declaration
```
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
```

##### Example Request
The following line in **Program.cs** calls the `ListE911Associations` method after initializing `our_e911s`:
```
ArrayList our_e911s = GetE911Records(client);
ListE911Associations(client, (string)our_e911s[0]);
```

##### Example Response

On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of related number objects in JSON format.
```
{
  "data": [
    {
      "attributes": {
        "alias": null,
        "value": "12062011682"
      },
      "id": "12062011682",
      "links": {
        "self": "https://api.flowroute.com/v2/numbers/12062011682"
      },
      "type": "number"
    }
  ],
  "links": {
    "self": "https://api.flowroute.com/v2/e911s/21907/relationships/numbers?limit=10&offset=0"
  }
}
```

#### DeleteE911(FlowrouteNumbersAndMessagingClient client, string e911_id)

The method accepts an E911 record ID as a parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/remove-e911-address-from-account/). Note that all phone number associations must be removed first before you are able to delete the specified `e911_id`. In the following example, we will attempt to delete the first item from `our_e911s`. 

##### Method Declaration
```
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
```

##### Example Request
The following line in **Program.cs** calls the `DeleteE911` method after initializing `our_e911s`:
```
ArrayList our_e911s = GetE911Records(client);
DeleteE911(client, (string)our_e911s[0]);
```

##### Example Response
On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.

`204 No Content`

### CNAM Record Management

The Flowroute .NET Library v3 allows you to make HTTP requests to the `cnams` resource of Flowroute API v2:
`https://api.flowroute.com/v2/cnams`

#### GetCNAMRecords(FlowrouteNumbersAndMessagingClient client) 

The method declares variables `limit` and `offset` which are query parameters that you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-account-cnam-records/). Afterwards, the method invokes the CNAMsController then iterates through each of the approved CNAM record on your account.

##### Method Declaration
```
public static dynamic GetCNAMRecords(FlowrouteNumbersAndMessagingClient client)
        {
            ArrayList return_list = new ArrayList();

            // List all CNAM records in our account paging through them 1 at a time
            //  If you have several CNAM records, change the 'limit' variable below
            //  This example is intended to show how to page through a list of resources

            int limit = 10;
            int offset = 0;

            CNAMsController cnams = client.CNAMs;
            do
            {
                dynamic cnam_data = cnams.GetAccountCNAMS(null, null, null, true, limit, offset);

                // Iterate through each CNAM item
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
```

##### Example Request

The following line in **Program.cs** calls the `GetCNAMRecords` method:
`ArrayList our_cnams = GetCNAMRecords(client);`


##### Example Response
On success, the HTTP status code in the response header is `200 OK` and the response body contains an array of approved **cnam** objects in JSON format.

```
{'data': [{'attributes': {'approval_datetime': None,
                          'creation_datetime': None,
                          'is_approved': True,
                          'rejection_reason': '',
                          'value': 'TEST, MARIA'},
           'id': '17604',
           'links': {'self': 'https://api.flowroute.com/v2/cnams/17604'},
           'type': 'cnam'},
          {'attributes': {'approval_datetime': '2018-04-16 '
                                               '16:20:32.939166+00:00',
                          'creation_datetime': '2018-04-12 '
                                               '19:08:39.062539+00:00',
                          'is_approved': True,
                          'rejection_reason': None,
                          'value': 'REGENCE INC'},
           'id': '22671',
           'links': {'self': 'https://api.flowroute.com/v2/cnams/22671'},
           'type': 'cnam'},
          {'attributes': {'approval_datetime': '2018-04-23 '
                                               '17:04:30.829341+00:00',
                          'creation_datetime': '2018-04-19 '
                                               '21:03:04.932192+00:00',
                          'is_approved': True,
                          'rejection_reason': None,
                          'value': 'BROWN BAG'},
           'id': '22790',
           'links': {'self': 'https://api.flowroute.com/v2/cnams/22790'},
           'type': 'cnam'},
          {'attributes': {'approval_datetime': '2018-05-23 '
                                               '18:58:46.052602+00:00',
                          'creation_datetime': '2018-05-22 '
                                               '23:38:27.794911+00:00',
                          'is_approved': True,
                          'rejection_reason': None,
                          'value': 'LEATHER REBEL'},
           'id': '23221',
           'links': {'self': 'https://api.flowroute.com/v2/cnams/23221'},
           'type': 'cnam'},
          {'attributes': {'approval_datetime': '2018-05-23 '
                                               '18:58:46.052602+00:00',
                          'creation_datetime': '2018-05-22 '
                                               '23:39:24.447054+00:00',
                          'is_approved': True,
                          'rejection_reason': None,
                          'value': 'LEATHER REBELZ'},
           'id': '23223',
           'links': {'self': 'https://api.flowroute.com/v2/cnams/23223'},
           'type': 'cnam'},
          {'attributes': {'approval_datetime': '2018-05-23 '
                                               '18:58:46.052602+00:00',
                          'creation_datetime': '2018-05-22 '
                                               '23:42:00.786818+00:00',
                          'is_approved': True,
                          'rejection_reason': None,
                          'value': 'MORBO'},
           'id': '23224',
           'links': {'self': 'https://api.flowroute.com/v2/cnams/23224'},
           'type': 'cnam'}],
 'links': {'self': 'https://api.flowroute.com/v2/cnams?limit=10&offset=0'}}
```

#### GetCNAMDetail(FlowrouteNumbersAndMessagingClient client) 

The method first invokes the CNAMsController then declares a dynamic variable, `cnam_data`, which calls the *GetCNAMDetails* function with the ID of the first record in the array, `our_cnams`, as an argument. *GetCNAMDetails* then retrieves the details of that specific CNAM record. The CNAM record ID is a path parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/list-cnam-record-details/).

##### Method Declaration
```
public static dynamic GetCNAMDetail(FlowrouteNumbersAndMessagingClient client, string cnam_id)
{
	CNAMsController cnams = client.CNAMs;
	dynamic cnam_data = cnams.GetCNAMDetails(cnam_id);
	Console.WriteLine(cnam_data);
	return cnam_data;
}
```

##### Example Request

The following line in **Program.cs** calls the `GetCNAMDetail` method after initializing `our_cnams`:
```
ArrayList our_cnams = GetCNAMRecords(client);
GetCNAMDetail(client, (string)our_cnams[0]);
```

##### Example Response
On success, the HTTP status code in the response header is `200 OK` and the response body contains a detailed cnam object in JSON format.

```
{'data': {'attributes': {'approval_datetime': None,
                         'creation_datetime': None,
                         'is_approved': True,
                         'rejection_reason': '',
                         'value': 'TEST, MARIA'},
          'id': '17604',
          'links': {'self': 'https://api.flowroute.com/v2/cnams/17604'},
          'type': 'cnam'}}
```


#### CreateCNAM(FlowrouteNumbersAndMessagingClient client, string cnam_value) 

The method first invokes the CNAMsController then declares a dynamic variable, `cnam_data`, which calls the *CreateCNAM* function and passes a Caller ID value as an argument. The Caller ID value, or `cnam_value`, is a body parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/create-a-new-cnam-record/). In the following example, we pass "Flowroute" as our example CNAM value. Note that you can enter up to 15 characters for your CNAM value.

##### Method Declaration
```
public static dynamic CreateCNAM(FlowrouteNumbersAndMessagingClient client, string cnam_value)
{
	CNAMsController cnams = client.CNAMs;
	dynamic cnam_data = cnams.CreateCNAM(cnam_value);
	Console.WriteLine(cnam_data);
	return cnam_data;
}
```

##### Example Request

The following line in **Program.cs** calls the `CreateCNAM` method:
`CreateCNAM(client, "Flowroute");`

##### Example Response

On success, the HTTP status code in the response header is `201 Created` and the response body contains the newly created cnam object in JSON format. 

```
{
  "data": {
    "attributes": {
      "approval_datetime": null,
      "creation_datetime": "2018-06-27 20:44:01.543801+00:00",
      "is_approved": false,
      "rejection_reason": null,
      "value": "FLOWROUTE"
    },   
    "id": "23922",
    "links": {
      "self": "https://api.flowroute.com/v2/cnams/23922"
    },   
    "type": "cnam"
  }
}
```

#### AssociateCNAM(FlowrouteNumbersAndMessagingClient client, string number_id, string cnam_id) 

The method first invokes the CNAMsController then declares a dynamic variable, `return_data`, which calls the *AssociateCNAM* function and passes a phone number ID and a CNAM record ID as arguments.  Both the phone number and CNAM IDs are path parameters which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/assign-cnam-record-to-phone-number/). In the following example, we will associate the first number returned in `our_numbers` with the first CNAM record returned in `our_cnams`.

##### Method Declaration
```
public static dynamic AssociateCNAM(FlowrouteNumbersAndMessagingClient client, string number_id, string cnam_id)
{
	CNAMsController cnams = client.CNAMs;
	dynamic return_data = cnams.AssociateCNAM(number_id, cnam_id);
	Console.WriteLine(return_data);
	return return_data;
}
```

##### Example Request

The last line in **Program.cs** below calls the `AssociateCNAM` method after initializing `our_numbers` and `our_cnams`:
```
ArrayList our_numbers = GetNumbers(client);
ArrayList our_cnams = GetCNAMRecords(client);
AssociateCNAM(client, (string)our_numbers[0], (string)our_cnams[0]);
```

##### Example Response

On success, the HTTP status code in the response header is `202 Accepted` and the response body contains an attributes dictionary containing the `date_created` field and the assigned cnam object in JSON format. This request will fail if the CNAM you are trying to associate has not yet been approved.
```
{'data': {'attributes': {'date_created': 'Fri, 01 Jun 2018 00:17:52 GMT'},
          'id': 22790,
          'type': 'cnam'}}
```

#### UnassociateCNAM(FlowrouteNumbersAndMessagingClient client, string number_id) 

The method first invokes the CNAMsController then declares a dynamic variable, `return_data`, which calls the *UnassociateCNAM* function and passes a phone number ID as an argument.  The phone number ID is a path parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/assign-cnam-record-to-phone-number/). In the following example, we will disassociate the same phone number that we've used in *AssociateCNAM*.

##### Method Declaration
```
public static dynamic UnassociateCNAM(FlowrouteNumbersAndMessagingClient client, string number_id)
{
	CNAMsController cnams = client.CNAMs;
	dynamic return_data = cnams.UnassociateCNAM(number_id);
	Console.WriteLine(return_data);
	return return_data;
}
```

##### Example Request

The last line in **Program.cs** below calls the `AssociateCNAM` method after initializing `our_numbers`:
```
ArrayList our_numbers = GetNumbers(client);
UnassociateCNAM(client, (string)our_numbers[0]);
```

##### Example Response
On success, the HTTP status code in the response header is `202 Accepted` and the response body contains an attributes object with the date the CNAM was requested to be disassociated, and the updated cnam object in JSON format. 

```
{'data': {'attributes': {'date_created': 'Wed, 27 Jun 2018 20:59:36 GMT'},
          'id': None,
          'type': 'cnam'}}
```

#### DeleteCNAM(FlowrouteNumbersAndMessagingClient client, string cnam_id) 

The method first invokes the CNAMsController then declares a dynamic variable, `return_data`, which calls the *DeleteCNAM* function and passes a CNAM record ID as an argument.  The CNAM record ID is a path parameter which you can learn more about in the [API reference](https://developer.flowroute.com/api/numbers/v2.0/assign-cnam-record-to-phone-number/). In the following example, we will delete the CNAM record that we've used in *AssociateCNAM*.

##### Method Declaration
```
public static dynamic DeleteCNAM(FlowrouteNumbersAndMessagingClient client, string cnam_id)
{
	CNAMsController cnams = client.CNAMs;
	dynamic return_data = cnams.DeleteCNAM(cnam_id);
	Console.WriteLine(return_data);
	return return_data;
}
```

##### Example Request

The last line in **Program.cs** below calls the `AssociateCNAM` method after initializing `our_cnams`:
```
ArrayList our_cnams = GetCNAMRecords(client);
DeleteCNAM(client, (string)our_cnams[0]);
```

##### Example Response

On success, the HTTP status code in the response header is `204 No Content` which means that the server successfully processed the request and is not returning any content.

`204 No Content`

Errors 
------

In cases of HTTP errors, the .NET library displays a pop-up window with an error message next to the line of code that caused the error. You can add more error logging if necessary.

### Example Error 

![dot-net-error.png](https://github.com/flowroute/flowroute-sdk-v3-dot-net/blob/master/images/dot-net-error.png?raw=true)
