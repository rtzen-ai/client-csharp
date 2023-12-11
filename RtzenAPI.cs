using Newtonsoft.Json;
using RtzenAPIs.models;
using RtzenAPIs.utils;


namespace RtzenAPIs
{
    public class RtzenAPI
    {
        public static async Task Main()
        {
            Console.WriteLine("Started Sync");

            // Read Data
            if (Settings.READ_CHART_OF_ACCOUNTS)
            {
                await RtzenAPI.ReadChartOfAccountsAsync();
            }
            if (Settings.READ_VENDORS)
            {
                await RtzenAPI.ReadVendorsAsync();
            }
            if (Settings.READ_BILLS)
            {
                await RtzenAPI.ReadBillsAsync();
            }

            if (Settings.WRITE_CHART_OF_ACCOUNTS)
            {
                await RtzenAPI.WriteChartOfAccountsAsync();
            }
            if (Settings.WRITE_VENDORS)
            {
                await RtzenAPI.WriteVendorsAsync();
            }
            if (Settings.WRITE_BILLS)
            {
                await RtzenAPI.WriteBillsAsync();
            }

            Console.WriteLine("Sync Finished");

        }

        public static async Task ReadVendorsAsync()
        {
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
                            Console.WriteLine("Page: " + page + ", Handle Vendor: " + item.Id);
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
        }

        public static async Task ReadChartOfAccountsAsync()
        {
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
                            Console.WriteLine("Page: " + page + ", Handle ChartOfAccount: " + item.Id);
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
        }


        public static async Task ReadBillsAsync()
        {
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
                            Console.WriteLine("Page: " + page + ", Handle Bill: " + item.Id);
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
        }


        public static async Task WriteChartOfAccountsAsync()
        {
            try
            {

                var CurrentSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Read this from your ERP
                var ChartOfAccount = new ChartOfAccount
                {
                    BusinessUnitId = Settings.BUSINESS_UNIT_ID,
                    Name = "ChartOfAccount - " + CurrentSeconds,
                    ExternalId = "ExternalId - " + CurrentSeconds
                };

                var json = JsonConvert.SerializeObject(ChartOfAccount);
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

        public static async Task WriteVendorsAsync()
        {
            try
            {

                var CurrentSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Read this from your ERP
                var Vendor = new Vendor
                {
                    BusinessUnit = new BusinessUnit
                    {
                        Id = Settings.BUSINESS_UNIT_ID
                    },
                    Name = "Vendor - " + CurrentSeconds,
                    ExternalId = "ExternalId - " + CurrentSeconds
                };

                var json = JsonConvert.SerializeObject(Vendor);
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

        public static async Task WriteBillsAsync()
        {
            try
            {

                var CurrentSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Read this from your ERP
                var Bill = new Bill
                {
                    BusinessUnit = new BusinessUnit
                    {
                        Id = Settings.BUSINESS_UNIT_ID
                    },
                    Vendor = new Vendor
                    {
                        Id = Settings.VENDOR_ID
                    },

                    BillDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(30),
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            Description = "LineItem - " + CurrentSeconds,
                            Quantity = 2,
                            Price = 100,
                            Amount = 200,
                        }
                    }
                };

                var json = JsonConvert.SerializeObject(Bill);
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