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
                        var responseObject = JsonConvert.DeserializeObject<ResponseObject<Vendor>>(res);
                        foreach (var item in responseObject.Objects)
                        {
                            Console.WriteLine("Page: " + page + ", Vendor: " + item.Id);
                            result.Add(item);
                        }
                        hasNext = responseObject.Paging.Next;
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
                        var responseObject = JsonConvert.DeserializeObject<ResponseObject<ChartOfAccount>>(res);
                        foreach (var item in responseObject.Objects)
                        {
                            Console.WriteLine("Page: " + page + ", ChartOfAccount: " + item.Id);
                            result.Add(item);
                        }
                        hasNext = responseObject.Paging.Next;
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
                        var responseObject = JsonConvert.DeserializeObject<ResponseObject<Bill>>(res);
                        foreach (var item in responseObject.Objects)
                        {
                            Console.WriteLine("Page: " + page + ", Bill: " + item.Id);
                            result.Add(item);
                        }
                        hasNext = responseObject.Paging.Next;
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


        public static async Task WriteChartOfAccountsAsync(ChartOfAccount chartOfAccount)
        {
            try
            {
                var json = JsonConvert.SerializeObject(chartOfAccount);
                Console.WriteLine(json);

                String? res = await RestClient.Post("/chart-of-accounts", json);
                if (res != null)
                {
                    var responseObject = JsonConvert.DeserializeObject<ChartOfAccount>(res);
                    Console.WriteLine($"Handle ChartOfAccount: {responseObject?.Id ?? "Id is null, please check logs for the errors"}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static async Task WriteVendorsAsync(Vendor vendor)
        {
            try
            {

                var json = JsonConvert.SerializeObject(vendor);
                Console.WriteLine(json);

                String? res = await RestClient.Post("/vendors", json);
                if (res != null)
                {
                    var responseObject = JsonConvert.DeserializeObject<Vendor>(res);
                    Console.WriteLine($"Handle Vendor: {responseObject?.Id ?? "Id is null, please check logs for the errors"}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static async Task WriteBillsAsync(Bill bill)
        {
            try
            {
                var json = JsonConvert.SerializeObject(bill);
                Console.WriteLine(json);

                String? res = await RestClient.Post("/bills", json);
                if (res != null)
                {
                    var responseObject = JsonConvert.DeserializeObject<Bill>(res);
                    Console.WriteLine($"Handle Bill: {responseObject?.Id ?? "Id is null, please check logs for the errors"}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}