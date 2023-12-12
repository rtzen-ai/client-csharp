using System;
using RtzenAPIs.models;

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
                await RtzenAPI.WriteChartOfAccountsAsync(chartOfAccount);
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

                await RtzenAPI.WriteVendorsAsync(vendor);
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
                await RtzenAPI.WriteBillsAsync(bill);
            }

            Console.WriteLine("Sync Finished");
        }
    }
}

