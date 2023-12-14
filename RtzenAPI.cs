using Newtonsoft.Json;
using RtzenAPIs.models;
using RtzenAPIs.utils;


namespace RtzenAPIs
{
    public class RtzenAPI
    {

        public static async Task<List<Vendor>> ReadVendorsAsync()
        {
            List<Vendor> result = new();

            try
            {
                bool hasNext = true;
                int page = 1;
                while (hasNext)
                {
                    String? res = await RestClient.Get("/vendors", page);
                    if (res != null)
                    {
                        var readResponse = JsonConvert.DeserializeObject<ReadResponse<Vendor>>(res);
                        foreach (var item in readResponse.Objects)
                        {
                            Console.WriteLine("Page: " + page + ", Vendor: " + item.Id);
                            result.Add(item);
                        }
                        hasNext = readResponse.Paging.Next;
                        page++;
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return result;
        }

        public static async Task<List<ChartOfAccount>> ReadChartOfAccountsAsync()
        {
            List<ChartOfAccount> result = new();
            try
            {
                bool hasNext = true;
                int page = 1;
                while (hasNext)
                {
                    String? res = await RestClient.Get("/chart-of-accounts", page);
                    if (res != null)
                    {
                        var readResponse = JsonConvert.DeserializeObject<ReadResponse<ChartOfAccount>>(res);
                        foreach (var item in readResponse.Objects)
                        {
                            Console.WriteLine("Page: " + page + ", ChartOfAccount: " + item.Id);
                            result.Add(item);
                        }
                        hasNext = readResponse.Paging.Next;
                        page++;
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return result;
        }


        public static async Task<List<Bill>> ReadBillsAsync()
        {
            List<Bill> result = new();
            try
            {
                bool hasNext = true;
                int page = 1;
                while (hasNext)
                {
                    String? res = await RestClient.Get("/bills", page);
                    if (res != null)
                    {
                        var readResponse = JsonConvert.DeserializeObject<ReadResponse<Bill>>(res);
                        foreach (var item in readResponse.Objects)
                        {
                            Console.WriteLine("Page: " + page + ", Bill: " + item.Id);
                            result.Add(item);
                        }
                        hasNext = readResponse.Paging.Next;
                        page++;
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return result;
        }


        public static async Task<List<WriteResponse<ChartOfAccount>>> WriteChartOfAccountsAsync(List<ChartOfAccount> chartOfAccounts)
        {
            List<WriteResponse<ChartOfAccount>> result = new();
            foreach (var chartOfAccount in chartOfAccounts)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(chartOfAccount);
                    Console.WriteLine("Upserting chartOfAccount: " + json);

                    APIResponse res = await RestClient.Post("/chart-of-accounts", json);
                    if (RestClient.IsSuccessStatusCode(res.StatusCode) && res.Result != null)
                    {
                        var chartOfAccountResponse = JsonConvert.DeserializeObject<ChartOfAccount>(res.Result);
                        result.Add(new WriteResponse<ChartOfAccount> { Object = chartOfAccountResponse });
                    }
                    else
                    {
                        if (res.Result != null)
                        {
                            var error = JsonConvert.DeserializeObject<WriteResponse<ChartOfAccount>.ErrorResult>(res.Result);
                            result.Add(new WriteResponse<ChartOfAccount> { Error = error });
                        }
                        else
                        {
                            Console.WriteLine($"Something went wrong: {res.StatusCode}");
                            result.Add(new WriteResponse<ChartOfAccount> { Error = new WriteResponse<ChartOfAccount>.ErrorResult { StatusCode = res.StatusCode } });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    result.Add(new WriteResponse<ChartOfAccount> { Error = new WriteResponse<ChartOfAccount>.ErrorResult { StatusCode = -1 } });
                }
            }
            return result;
        }

        public static async Task<List<WriteResponse<Vendor>>> WriteVendorsAsync(List<Vendor> vendors)
        {
            List<WriteResponse<Vendor>> result = new();
            foreach (var vendor in vendors)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(vendor);
                    Console.WriteLine("Upserting vendor: " + json);

                    APIResponse res = await RestClient.Post("/vendors", json);
                    if (RestClient.IsSuccessStatusCode(res.StatusCode) && res.Result != null)
                    {
                        var vendorResponse = JsonConvert.DeserializeObject<Vendor>(res.Result);
                        result.Add(new WriteResponse<Vendor>
                        {
                            Object = vendorResponse
                        });
                    }
                    else
                    {
                        if (res.Result != null)
                        {
                            var error = JsonConvert.DeserializeObject<WriteResponse<Vendor>.ErrorResult>(res.Result);
                            result.Add(new WriteResponse<Vendor> { Error = error });
                        }
                        else
                        {
                            Console.WriteLine($"Something went wrong: {res.StatusCode}");
                            result.Add(new WriteResponse<Vendor> { Error = new WriteResponse<Vendor>.ErrorResult { StatusCode = res.StatusCode } });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    result.Add(new WriteResponse<Vendor> { Error = new WriteResponse<Vendor>.ErrorResult { StatusCode = -1 } });
                }
            }
            return result;
        }

        public static async Task<List<WriteResponse<Bill>>> WriteBillsAsync(List<Bill> bills)
        {
            List<WriteResponse<Bill>> result = new();
            foreach (var bill in bills)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(bill);
                    Console.WriteLine("Upserting bill: " + json);

                    APIResponse res = await RestClient.Post("/bills", json);
                    if (RestClient.IsSuccessStatusCode(res.StatusCode) && res.Result != null)
                    {
                        var billResponse = JsonConvert.DeserializeObject<Bill>(res.Result);
                        result.Add(new WriteResponse<Bill> { Object = billResponse });
                    }
                    else
                    {
                        if (res.Result != null)
                        {
                            var error = JsonConvert.DeserializeObject<WriteResponse<Bill>.ErrorResult>(res.Result);
                            result.Add(new WriteResponse<Bill> { Error = error });
                        }
                        else
                        {
                            Console.WriteLine($"Something went wrong: {res.StatusCode}");
                            result.Add(new WriteResponse<Bill> { Error = new WriteResponse<Bill>.ErrorResult { StatusCode = res.StatusCode } });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    result.Add(new WriteResponse<Bill> { Error = new WriteResponse<Bill>.ErrorResult { StatusCode = -1 } });
                }
            }
            return result;
        }
    }

}