# AP Is

Actions relating to APIs in the collection

```csharp
APIsController aPIsController = client.APIsController;
```

## Class Name

`APIsController`

## Methods

* [Get Providers](../../doc/controllers/ap-is.md#get-providers)
* [Get Provider](../../doc/controllers/ap-is.md#get-provider)
* [Get Services](../../doc/controllers/ap-is.md#get-services)
* [Get API](../../doc/controllers/ap-is.md#get-api)
* [Get Service API](../../doc/controllers/ap-is.md#get-service-api)
* [List AP Is](../../doc/controllers/ap-is.md#list-ap-is)
* [Get Metrics](../../doc/controllers/ap-is.md#get-metrics)


# Get Providers

Use this endpoint to list all the providers in the directory.

```csharp
GetProvidersAsync()
```

## Response Type

[`Task<Models.ProvidersJsonResponse>`](../../doc/models/providers-json-response.md)

## Example Usage

```csharp
try
{
    ProvidersJsonResponse result = await aPIsController.GetProvidersAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Provider

Use this endpoint to list all APIs in the directory for a particular providerName.

```csharp
GetProviderAsync(
    string provider)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `provider` | `string` | Template, Required | Entity that offers an API service to other applications or clients |

## Response Type

[`Task<Dictionary<string, Models.API>>`](../../doc/models/api.md)

## Example Usage

```csharp
string provider = "apis.guru";
try
{
    Dictionary<string, API> result = await aPIsController.GetProviderAsync(provider);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Services

Use this endpoint to return all serviceNames in the directory for a particular providerName.

```csharp
GetServicesAsync(
    string provider)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `provider` | `string` | Template, Required | Entity that offers an API service to other applications or clients |

## Response Type

[`Task<Models.ServicesJsonResponse>`](../../doc/models/services-json-response.md)

## Example Usage

```csharp
string provider = "apis.guru";
try
{
    ServicesJsonResponse result = await aPIsController.GetServicesAsync(provider);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get API

Use this endpoint to return the API entry for one specific version of an API where there is no serviceName.

```csharp
GetAPIAsync(
    string provider,
    string api)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `provider` | `string` | Template, Required | Entity that offers an API service to other applications or clients |
| `api` | `string` | Template, Required | API version |

## Response Type

[`Task<Models.API>`](../../doc/models/api.md)

## Example Usage

```csharp
string provider = "apis.guru";
string api = "2.1.0";
try
{
    API result = await aPIsController.GetAPIAsync(
        provider,
        api
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Service API

Use this endpoint to returns the API entry for one specific version of an API where there is a serviceName.

```csharp
GetServiceAPIAsync(
    string provider,
    string service,
    string api)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `provider` | `string` | Template, Required | Entity that offers an API service to other applications or clients |
| `service` | `string` | Template, Required | Specific functionality or feature that an API provides to other applications or clients |
| `api` | `string` | Template, Required | API Version |

## Response Type

[`Task<Models.API>`](../../doc/models/api.md)

## Example Usage

```csharp
string provider = "apis.guru";
string service = "graph";
string api = "2.1.0";
try
{
    API result = await aPIsController.GetServiceAPIAsync(
        provider,
        service,
        api
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List AP Is

Use this endpoint to list all APIs in the directory.
Returns links to the OpenAPI definitions for each API in the directory.
If API exist in multiple versions `preferred` one is explicitly marked.
Some basic info from the OpenAPI definition is cached inside each object.
This allows you to generate some simple views without needing to fetch the OpenAPI definition for each API.

```csharp
ListAPIsAsync()
```

## Response Type

[`Task<Dictionary<string, Models.API>>`](../../doc/models/api.md)

## Example Usage

```csharp
try
{
    Dictionary<string, API> result = await aPIsController.ListAPIsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Metrics

Use this endpoint to get basic metrics for the entire directory.

```csharp
GetMetricsAsync()
```

## Response Type

[`Task<Models.Metrics>`](../../doc/models/metrics.md)

## Example Usage

```csharp
try
{
    Metrics result = await aPIsController.GetMetricsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

