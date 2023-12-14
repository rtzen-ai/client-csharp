using System;
using Newtonsoft.Json;

namespace RtzenAPIs.models
{
    public class ChartOfAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("businessUnitId")]
        public string BusinessUnitId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
    }
}

