
# Api Version

API Version

## Structure

`ApiVersion`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Added` | `DateTime` | Required | Timestamp when the version was added |
| `Updated` | `DateTime` | Required | Timestamp when the version was updated |
| `SwaggerUrl` | `string` | Required | URL to OpenAPI definition in JSON format |
| `SwaggerYamlUrl` | `string` | Required | URL to OpenAPI definition in YAML format |
| `Link` | `string` | Optional | Link to the individual API entry for this API |
| `Info` | `object` | Required | Copy of `info` section from OpenAPI definition |
| `ExternalDocs` | `object` | Optional | Copy of `externalDocs` section from OpenAPI definition |
| `OpenapiVer` | `string` | Required | The value of the `openapi` or `swagger` property of the source definition |

## Example (as JSON)

```json
{
  "added": "2016-03-13T12:52:32.123Z",
  "updated": "2016-03-13T12:52:32.123Z",
  "swaggerUrl": "swaggerUrl4",
  "swaggerYamlUrl": "swaggerYamlUrl6",
  "link": "link0",
  "info": {
    "key1": "val1",
    "key2": "val2"
  },
  "externalDocs": {
    "key1": "val1",
    "key2": "val2"
  },
  "openapiVer": "openapiVer6"
}
```

