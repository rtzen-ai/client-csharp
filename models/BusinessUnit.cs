using System;
using Newtonsoft.Json;

namespace RtzenAPIs.models
{
	public class BusinessUnit
	{
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paymentType")]
        public string ExternalId { get; set; }
    }
}

