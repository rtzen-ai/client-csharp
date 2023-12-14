using System;
using Newtonsoft.Json;
using RtzenAPIs.models;
using RtzenAPIs.utils;

namespace RtzenAPIs
{
    public class Start
    {
        public static async Task Main()
        {
            Console.WriteLine("Started Sync");

            // Read Data
            if (Settings.READ_CHART_OF_ACCOUNTS)
            {

                List<ChartOfAccount> chartOfAccounts = await RtzenAPI.ReadChartOfAccountsAsync();
                foreach (var item in chartOfAccounts)
                {
                    Console.WriteLine("Handle ChartOfAccount: Name: " + item.Name + ", Id: " + item.Id);
                }
            }
            if (Settings.READ_VENDORS)
            {
                List<Vendor> vendors = await RtzenAPI.ReadVendorsAsync();
                foreach (var item in vendors)
                {
                    Console.WriteLine("Handle Vendor: Name: " + item.Name + ", Id: " + item.Id);
                }
            }
            if (Settings.READ_BILLS)
            {
                List<Bill> bills = await RtzenAPI.ReadBillsAsync();
                foreach (var item in bills)
                {
                    Console.WriteLine("Handle Bill: Number: " + item.BillNumber + ", Id: " + item.Id);
                }
            }

            // Write Data
            if (Settings.WRITE_CHART_OF_ACCOUNTS)
            {
                var CurrentSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Read this from your ERP
                var chartOfAccount = new ChartOfAccount
                {
                    BusinessUnitId = Settings.BUSINESS_UNIT_ID,
                    Name = "ChartOfAccount - " + CurrentSeconds,
                    ExternalId = "ExternalId - " + CurrentSeconds
                };
                List<ChartOfAccount> chartOfAccounts = new();
                chartOfAccounts.Add(chartOfAccount);
                List<WriteResponse<ChartOfAccount>> writeResult = await RtzenAPI.WriteChartOfAccountsAsync(chartOfAccounts);
                foreach (var item in writeResult)
                {
                    if (item.Object != null)
                    {
                        Console.WriteLine("ChartOfAccount Created: " + item?.Object?.Id);
                    }
                    else
                    {
                        Console.WriteLine("ChartOfAccount Creation Failed: " + item.Error.StatusCode + ", " + JsonConvert.SerializeObject(item.Error));
                    }
                }
            }
            if (Settings.WRITE_VENDORS)
            {

                var CurrentSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Read this from your ERP
                var vendor = new Vendor
                {
                    BusinessUnit = new BusinessUnit
                    {
                        Id = Settings.BUSINESS_UNIT_ID
                    },
                    Name = "Vendor - " + CurrentSeconds,
                    ExternalId = "ExternalId - " + CurrentSeconds
                };
                List<Vendor> vendors = new();
                vendors.Add(vendor);
                List<WriteResponse<Vendor>> writeResult = await RtzenAPI.WriteVendorsAsync(vendors);
                foreach (var item in writeResult)
                {
                    if (item.Object != null)
                    {
                        Console.WriteLine("Vendor Created: " + item?.Object?.Id);
                    }
                    else
                    {
                        Console.WriteLine("Vendor Creation Failed: " + item.Error.StatusCode + ", " + JsonConvert.SerializeObject(item.Error));
                    }
                }
            }
            if (Settings.WRITE_BILLS)
            {
                var CurrentSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Read this from your ERP
                var bill = new Bill
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
                List<Bill> bills = new();
                bills.Add(bill);
                List<WriteResponse<Bill>> writeResult = await RtzenAPI.WriteBillsAsync(bills);
                foreach (var item in writeResult)
                {
                    if (item.Object != null)
                    {
                        Console.WriteLine("Bill Created: " + item?.Object?.Id);
                    }
                    else
                    {
                        Console.WriteLine("Bill Creation Failed: " + item.Error.StatusCode + ", " + JsonConvert.SerializeObject(item.Error));
                    }
                }
            }

            Console.WriteLine("Sync Finished");
        }
    }
}

