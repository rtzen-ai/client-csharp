using System;
using System.Net.Http.Headers;
using System.Text;
namespace RtzenAPIs.utils
{
    public class RestClient
    {
        public static async Task<String?> Get(String path, int pageNum)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Settings.API_URL + path + "?count=" + Settings.RESULTS_PER_PAGE + "&page=" + pageNum);

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("x-api-key", Settings.API_KEY);

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }

        public static async Task<APIResponse> Post(String path, String body)
        {
            var result = new APIResponse();
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Settings.API_URL + path);

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("x-api-key", Settings.API_KEY);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    result.StatusCode = (int)response.StatusCode;
                    result.Result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    result.StatusCode = (int)response.StatusCode;
                    result.Result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }

        public static bool IsSuccessStatusCode(int statusCode)
        {
            return statusCode >= 200 && statusCode <= 299;
        }

    }
}

