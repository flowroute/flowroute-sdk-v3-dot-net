# Getting started

The Flowroute APIs are organized around REST. Our APIs have resource-oriented URLs, support HTTP Verbs, and respond with HTTP Status Codes. All API requests and responses, including errors, will be represented as JSON objects. You can use the Flowroute APIs to manage your Flowroute phone numbers including setting primary and failover routes for inbound calls, and sending text messages (SMS and MMS) using long-code or toll-free numbers in your account.

## How to Build

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore
is enabled, these dependencies will be installed automatically. Therefore,
you will need internet access for build.

"This library requires Visual Studio 2017 for compilation."
1. Open the solution (FlowrouteNumbersAndMessaging.sln) file.
2. Invoke the build process using `Ctrl+Shift+B` shortcut key or using the `Build` menu as shown below.

![Building SDK using Visual Studio](https://apidocs.io/illustration/cs?step=buildSDK&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

## How to Use

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8,
Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the [MSDN Portable Class Libraries documentation](http://msdn.microsoft.com/en-us/library/vstudio/gg597391%28v=vs.100%29.aspx).

The following section explains how to use the FlowrouteNumbersAndMessaging library in a new console project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the *solution explorer* and choose  ``` Add -> New Project ```.

![Add a new project in the existing solution using Visual Studio](https://apidocs.io/illustration/cs?step=addProject&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

Next, choose "Console Application", provide a ``` TestConsoleProject ``` as the project name and click ``` OK ```.

![Create a new console project using Visual Studio](https://apidocs.io/illustration/cs?step=createProject&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the ``` TestConsoleProject ``` as the start-up project. To do this, right-click on the  ``` TestConsoleProject ``` and choose  ``` Set as StartUp Project ``` form the context menu.

![Set the new cosole project as the start up project](https://apidocs.io/illustration/cs?step=setStartup&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

### 3. Add reference of the library project

In order to use the FlowrouteNumbersAndMessaging library in the new project, first we must add a projet reference to the ``` TestConsoleProject ```. First, right click on the ``` References ``` node in the *solution explorer* and click ``` Add Reference... ```.

![Open references of the TestConsoleProject](https://apidocs.io/illustration/cs?step=addReference&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

Next, a window will be displayed where we must set the ``` checkbox ``` on ``` FlowrouteNumbersAndMessaging.Standard ``` and click ``` OK ```. By doing this, we have added a reference of the ```FlowrouteNumbersAndMessaging.Standard``` project into the new ``` TestConsoleProject ```.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=createReference&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

### 4. Write sample code

Once the ``` TestConsoleProject ``` is created, a file named ``` Program.cs ``` will be visible in the *solution explorer* with an empty ``` Main ``` method. This is the entry point for the execution of the entire solution.
Here, you can add code to initialize the client library and acquire the instance of a *Controller* class. Sample code to initialize the client library and using controller methods is given in the subsequent sections.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=addCode&workspaceFolder=Flowroute%20Numbers%20and%20Messaging-CSharp&workspaceName=FlowrouteNumbersAndMessaging&projectName=FlowrouteNumbersAndMessaging.Standard)

## How to Test

The generated SDK also contain one or more Tests, which are contained in the Tests project.
In order to invoke these test cases, you will need *NUnit 3.0 Test Adapter Extension for Visual Studio*.
Once the SDK is complied, the test cases should appear in the Test Explorer window.
Here, you can click *Run All* to execute these test cases.

## Initialization

### Authentication
In order to setup authentication and initialization of the API client, you need the following information.

| Parameter | Description |
|-----------|-------------|
| basicAuthUserName | The username to use with basic authentication |
| basicAuthPassword | The password to use with basic authentication |



API client can be initialized as following.

```csharp
// Configuration parameters and credentials
string basicAuthUserName = "basicAuthUserName"; // The username to use with basic authentication
string basicAuthPassword = "basicAuthPassword"; // The password to use with basic authentication

FlowrouteNumbersAndMessagingClient client = new FlowrouteNumbersAndMessagingClient(basicAuthUserName, basicAuthPassword);
```



# Class Reference

## <a name="list_of_controllers"></a>List of Controllers

* [MessagesController](#messages_controller)
* [NumbersController](#numbers_controller)
* [RoutesController](#routes_controller)

## <a name="messages_controller"></a>![Class: ](https://apidocs.io/img/class.png "FlowrouteNumbersAndMessaging.Standard.Controllers.MessagesController") MessagesController

### Get singleton instance

The singleton instance of the ``` MessagesController ``` class can be accessed from the API Client.

```csharp
MessagesController messages = client.Messages;
```

### <a name="get_look_up_a_set_of_messages"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.MessagesController.GetLookUpASetOfMessages") GetLookUpASetOfMessages

> Retrieves a list of Message Detail Records (MDRs) within a specified date range. Date and time is based on Coordinated Universal Time (UTC).


```csharp
Task<string> GetLookUpASetOfMessages(
        DateTime startDate,
        DateTime? endDate = null,
        int? limit = null,
        int? offset = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| startDate |  ``` Required ```  | The beginning date and time, in UTC, on which to perform an MDR search. The DateTime can be formatted as YYYY-MM-DDor YYYY-MM-DDTHH:mm:ss.SSZ. |
| endDate |  ``` Optional ```  | The ending date and time, in UTC, on which to perform an MDR search. The DateTime can be formatted as YYYY-MM-DD or YYYY-MM-DDTHH:mm:ss.SSZ. |
| limit |  ``` Optional ```  | The number of MDRs to retrieve at one time. You can set as high of a number as you want, but the number cannot be negative and must be greater than 0 (zero). |
| offset |  ``` Optional ```  | The number of MDRs to skip when performing a query. The number must be 0 (zero) or greater, but cannot be negative. |


#### Example Usage

```csharp
DateTime startDate = DateTime.Now();
DateTime? endDate = DateTime.Now();
int? limit = 174;
int? offset = 174;

string result = await messages.GetLookUpASetOfMessages(startDate, endDate, limit, offset);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="create_send_a_message"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.MessagesController.CreateSendAMessage") CreateSendAMessage

> Sends an SMS or MMS from a Flowroute long code or toll-free phone number to another valid phone number.


```csharp
Task<string> CreateSendAMessage(Models.Message body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | The SMS or MMS message to send. |


#### Example Usage

```csharp
var body = new Models.Message();

string result = await messages.CreateSendAMessage(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 403 | Forbidden – You don't have permission to access this resource. |
| 404 | The specified resource was not found |
| 422 | Unprocessable Entity - You tried to enter an incorrect value. |


### <a name="get_look_up_a_message_detail_record"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.MessagesController.GetLookUpAMessageDetailRecord") GetLookUpAMessageDetailRecord

> Searches for a specific message record ID and returns a Message Detail Record (in MDR2 format).


```csharp
Task<Models.MDR2> GetLookUpAMessageDetailRecord(string id)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| id |  ``` Required ```  | The unique message detail record identifier (MDR ID) of any message. When entering the MDR ID, the number should include the mdr2- preface. |


#### Example Usage

```csharp
string id = "id";

Models.MDR2 result = await messages.GetLookUpAMessageDetailRecord(id);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


[Back to List of Controllers](#list_of_controllers)

## <a name="numbers_controller"></a>![Class: ](https://apidocs.io/img/class.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController") NumbersController

### Get singleton instance

The singleton instance of the ``` NumbersController ``` class can be accessed from the API Client.

```csharp
NumbersController numbers = client.Numbers;
```

### <a name="get_account_phone_numbers"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController.GetAccountPhoneNumbers") GetAccountPhoneNumbers

> Returns a list of all phone numbers currently on your Flowroute account. The response includes details such as the phone number's rate center, state, number type, and whether CNAM Lookup is enabled for that number.


```csharp
Task<dynamic> GetAccountPhoneNumbers(
        int? startsWith = null,
        int? endsWith = null,
        int? contains = null,
        int? limit = null,
        int? offset = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| startsWith |  ``` Optional ```  | Retrieves phone numbers that start with the specified value. |
| endsWith |  ``` Optional ```  | Retrieves phone numbers that end with the specified value. |
| contains |  ``` Optional ```  | Retrieves phone numbers containing the specified value. |
| limit |  ``` Optional ```  | Limits the number of items to retrieve. A maximum of 200 items can be retrieved. |
| offset |  ``` Optional ```  | Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response. |


#### Example Usage

```csharp
int? startsWith = 174;
int? endsWith = 174;
int? contains = 174;
int? limit = 174;
int? offset = 174;

dynamic result = await numbers.GetAccountPhoneNumbers(startsWith, endsWith, contains, limit, offset);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="get_phone_number_details"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController.GetPhoneNumberDetails") GetPhoneNumberDetails

> Lists all of the information associated with any of the phone numbers in your account, including billing method, primary voice route, and failover voice route.


```csharp
Task<Models.Number26> GetPhoneNumberDetails(int id)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| id |  ``` Required ```  | Phone number to search for which must be a number that you own. Must be in 11-digit E.164 format; e.g. 12061231234. |


#### Example Usage

```csharp
int id = 174;

Models.Number26 result = await numbers.GetPhoneNumberDetails(id);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized |
| 404 | Not Found |


### <a name="create_purchase_a_phone_number"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController.CreatePurchaseAPhoneNumber") CreatePurchaseAPhoneNumber

> Lets you purchase a phone number from available Flowroute inventory.


```csharp
Task<Models.Number26> CreatePurchaseAPhoneNumber(int id)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| id |  ``` Required ```  | Phone number to purchase. Must be in 11-digit E.164 format; e.g. 12061231234. |


#### Example Usage

```csharp
int id = 174;

Models.Number26 result = await numbers.CreatePurchaseAPhoneNumber(id);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="search_for_purchasable_phone_numbers"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController.SearchForPurchasablePhoneNumbers") SearchForPurchasablePhoneNumbers

> This endpoint lets you search for phone numbers by state or rate center, or by your specified search value.


```csharp
Task<dynamic> SearchForPurchasablePhoneNumbers(
        int? startsWith = null,
        int? contains = null,
        int? endsWith = null,
        int? limit = null,
        int? offset = null,
        string rateCenter = null,
        string state = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| startsWith |  ``` Optional ```  | Retrieve phone numbers that start with the specified value. |
| contains |  ``` Optional ```  | Retrieve phone numbers containing the specified value. |
| endsWith |  ``` Optional ```  | Retrieve phone numbers that end with the specified value. |
| limit |  ``` Optional ```  | Limits the number of items to retrieve. A maximum of 200 items can be retrieved. |
| offset |  ``` Optional ```  | Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response. |
| rateCenter |  ``` Optional ```  | Filters by and displays phone numbers in the specified rate center. |
| state |  ``` Optional ```  | Filters by and displays phone numbers in the specified state. Optional unless a ratecenter is specified. |


#### Example Usage

```csharp
int? startsWith = 174;
int? contains = 174;
int? endsWith = 174;
int? limit = 174;
int? offset = 174;
string rateCenter = "rate_center";
string state = "state";

dynamic result = await numbers.SearchForPurchasablePhoneNumbers(startsWith, contains, endsWith, limit, offset, rateCenter, state);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="list_available_area_codes"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController.ListAvailableAreaCodes") ListAvailableAreaCodes

> Returns a list of all Numbering Plan Area (NPA) codes containing purchasable phone numbers.


```csharp
Task ListAvailableAreaCodes(int? limit = null, int? offset = null, double? maxSetupCost = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| limit |  ``` Optional ```  | Limits the number of items to retrieve. A maximum of 400 items can be retrieved. |
| offset |  ``` Optional ```  | Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response. |
| maxSetupCost |  ``` Optional ```  | Restricts the results to the specified maximum non-recurring setup cost. |


#### Example Usage

```csharp
int? limit = 174;
int? offset = 174;
double? maxSetupCost = 174.403489464616;

await numbers.ListAvailableAreaCodes(limit, offset, maxSetupCost);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="list_available_exchange_codes"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.NumbersController.ListAvailableExchangeCodes") ListAvailableExchangeCodes

> Returns a list of all Central Office (exchange) codes containing purchasable phone numbers.


```csharp
Task ListAvailableExchangeCodes(
        int? limit = null,
        int? offset = null,
        double? maxSetupCost = null,
        int? areacode = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| limit |  ``` Optional ```  | Limits the number of items to retrieve. A maximum of 200 items can be retrieved. |
| offset |  ``` Optional ```  | Offsets the list of phone numbers by your specified value. For example, if you have 4 phone numbers and you entered 1 as your offset value, then only 3 of your phone numbers will be displayed in the response. |
| maxSetupCost |  ``` Optional ```  | Restricts the results to the specified maximum non-recurring setup cost. |
| areacode |  ``` Optional ```  | Restricts the results to the specified area code. |


#### Example Usage

```csharp
int? limit = 174;
int? offset = 174;
double? maxSetupCost = 174.403489464616;
int? areacode = 174;

await numbers.ListAvailableExchangeCodes(limit, offset, maxSetupCost, areacode);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


[Back to List of Controllers](#list_of_controllers)

## <a name="routes_controller"></a>![Class: ](https://apidocs.io/img/class.png "FlowrouteNumbersAndMessaging.Standard.Controllers.RoutesController") RoutesController

### Get singleton instance

The singleton instance of the ``` RoutesController ``` class can be accessed from the API Client.

```csharp
RoutesController routes = client.Routes;
```

### <a name="list_inbound_routes"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.RoutesController.ListInboundRoutes") ListInboundRoutes

> Returns a list of your inbound routes. From the list, you can then select routes to use as the primary and failover routes for a phone number, which you can do via "Update Primary Voice Route for a Phone Number" and "Update Failover Voice Route for a Phone Number".


```csharp
Task ListInboundRoutes(int? limit = null, int? offset = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| limit |  ``` Optional ```  | Limits the number of routes to retrieve. A maximum of 200 items can be retrieved. |
| offset |  ``` Optional ```  | Offsets the list of routes by your specified value. For example, if you have 4 inbound routes and you entered 1 as your offset value, then only 3 of your routes will be displayed in the response. |


#### Example Usage

```csharp
int? limit = 174;
int? offset = 174;

await routes.ListInboundRoutes(limit, offset);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized |
| 404 | Not Found |


### <a name="create_an_inbound_route"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.RoutesController.CreateAnInboundRoute") CreateAnInboundRoute

> Creates a new inbound route which can then be associated with phone numbers. Please see "List Inbound Routes" to review the route values that you can associate with your Flowroute phone numbers.


```csharp
Task<string> CreateAnInboundRoute(Models.NewRoute body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | The new inbound route to be created. |


#### Example Usage

```csharp
var body = new Models.NewRoute();

string result = await routes.CreateAnInboundRoute(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="update_primary_voice_route_for_a_phone_number"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.RoutesController.UpdatePrimaryVoiceRouteForAPhoneNumber") UpdatePrimaryVoiceRouteForAPhoneNumber

> Use this endpoint to update the primary voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.


```csharp
Task<string> UpdatePrimaryVoiceRouteForAPhoneNumber(int numberId, void body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| numberId |  ``` Required ```  | The phone number in E.164 11-digit North American format to which the primary route for voice will be assigned. |
| body |  ``` Required ```  | The primary route to be assigned. |


#### Example Usage

```csharp
int numberId = 174;
void body = ;

string result = await routes.UpdatePrimaryVoiceRouteForAPhoneNumber(numberId, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


### <a name="update_failover_voice_route_for_a_phone_number"></a>![Method: ](https://apidocs.io/img/method.png "FlowrouteNumbersAndMessaging.Standard.Controllers.RoutesController.UpdateFailoverVoiceRouteForAPhoneNumber") UpdateFailoverVoiceRouteForAPhoneNumber

> Use this endpoint to update the failover voice route for a phone number. You must create the route first by following "Create an Inbound Route". You can then assign the created route by specifying its value in a PATCH request.


```csharp
Task<string> UpdateFailoverVoiceRouteForAPhoneNumber(int numberId, void body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| numberId |  ``` Required ```  | The phone number in E.164 11-digit North American format to which the failover route for voice will be assigned. |
| body |  ``` Required ```  | The failover route to be assigned. |


#### Example Usage

```csharp
int numberId = 174;
void body = ;

string result = await routes.UpdateFailoverVoiceRouteForAPhoneNumber(numberId, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 401 | Unauthorized – There was an issue with your API credentials. |
| 404 | The specified resource was not found |


[Back to List of Controllers](#list_of_controllers)



