using System;
using Newtonsoft.Json;

namespace RtzenAPIs.models
{

    public class Tax
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }

    public class Attachment
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class LineItem
    {

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }

    public class ChartOfAccountItem
    {

        [JsonProperty("chartOfAccount")]
        public ChartOfAccount ChartOfAccount { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }

    public class Bill
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("businessUnit")]
        public BusinessUnit BusinessUnit { get; set; }

        [JsonProperty("vendor")]
        public Vendor Vendor { get; set; }

        [JsonProperty("billNumber")]
        public string BillNumber { get; set; }

        [JsonProperty("poNumber")]
        public string PONumber { get; set; }

        [JsonProperty("billDate")]
        public DateTime BillDate { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("billTotal")]
        public decimal BillTotal { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("lineItems")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("chartOfAccounts")]
        public List<ChartOfAccountItem> ChartOfAccounts { get; set; }
    }
}

