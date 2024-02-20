
# API

Meta information about API

## Structure

`API`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Added` | `DateTime` | Required | Timestamp when the API was first added to the directory |
| `Preferred` | `string` | Required | Recommended version |
| `Versions` | [`Dictionary<string, ApiVersion>`](../../doc/models/api-version.md) | Required | List of supported versions of the API |

## Example (as JSON)

```json
{
  "added": "2016-03-13T12:52:32.123Z",
  "preferred": "preferred4",
  "versions": {
    "key0": {
      "added": "2016-03-13T12:52:32.123Z",
      "updated": "2016-03-13T12:52:32.123Z",
      "swaggerUrl": "swaggerUrl6",
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
      "openapiVer": "openapiVer4"
    }
  }
}
```

