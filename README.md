# client-csharp

# Settings 

Step1:  
Make sure the following settings are updated in the Settings.cs file.

| Setting | Description |
| --- | --- |
| API_URL | The URL of the API. Dev: `https://api.dev.rtzen.com` for prod `https://api.rtzen.com` |
| API_KEY | The API key for the user. |
| READ_CHART_OF_ACCOUNTS | Set to true to read the chart of accounts. |
| READ_VENDORS | Set to true to read the vendors. |
| READ_BILLS | Set to true to read the bills. |
| WRITE_CHART_OF_ACCOUNTS| Set to true to write the chart of accounts. |
| WRITE_VENDORS| Set to true to write the vendors. |
| WRITE_BILLS| Set to true to write the bills. |
| RESULTS_PER_PAGE| The number of results to return per page (in read APIs) |

Step1:  
Update `Start.cs` to handle the data as needed. And start `Start.cs`
