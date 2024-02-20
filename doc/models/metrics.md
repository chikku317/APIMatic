
# Metrics

List of basic metrics

## Structure

`Metrics`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `NumSpecs` | `int` | Required | Number of API definitions including different versions of the same API<br>**Constraints**: `>= 1` |
| `NumAPIs` | `int` | Required | Number of unique APIs<br>**Constraints**: `>= 1` |
| `NumEndpoints` | `int` | Required | Total number of endpoints inside all definitions<br>**Constraints**: `>= 1` |
| `Unreachable` | `int?` | Optional | Number of unreachable (4XX,5XX status) APIs |
| `Invalid` | `int?` | Optional | Number of newly invalid APIs |
| `Unofficial` | `int?` | Optional | Number of unofficial APIs |
| `Fixes` | `int?` | Optional | Total number of fixes applied across all APIs |
| `FixedPct` | `int?` | Optional | Percentage of all APIs where auto fixes have been applied |
| `Datasets` | `object` | Optional | Data used for charting etc |
| `Stars` | `int?` | Optional | GitHub stars for our main repo |
| `Issues` | `int?` | Optional | Open GitHub issues on our main repo |
| `ThisWeek` | [`ThisWeek`](../../doc/models/this-week.md) | Optional | Summary totals for the last 7 days |
| `NumDrivers` | `int?` | Optional | Number of methods of API retrieval |
| `NumProviders` | `int?` | Optional | Number of API providers in directory |

## Example (as JSON)

```json
{
  "numAPIs": 2501,
  "numEndpoints": 106448,
  "numSpecs": 3329,
  "unreachable": 123,
  "invalid": 598,
  "unofficial": 25,
  "fixes": 81119,
  "fixedPct": 22,
  "datasets": [],
  "stars": 2429,
  "issues": 28,
  "thisWeek": {
    "added": 45,
    "updated": 171
  },
  "numDrivers": 10,
  "numProviders": 659
}
```

