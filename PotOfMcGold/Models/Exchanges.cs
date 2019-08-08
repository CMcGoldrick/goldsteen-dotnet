using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PotOfMcGold.Models
{
    public class ExchangeIndexClass
    {
        public partial class ExchangeIndex
        {
            [JsonProperty("meta")]
            public Meta Meta { get; set; }

            [JsonProperty("payload")]
            public Payload[] Payload { get; set; }
        }

        public partial class Meta
        {
            [JsonProperty("totalCount")]
            public long TotalCount { get; set; }

            [JsonProperty("index")]
            public long Index { get; set; }

            [JsonProperty("limit")]
            public long Limit { get; set; }

            [JsonProperty("results")]
            public long Results { get; set; }
        }

        public partial class Payload
        {
            [JsonProperty("exchangeId")]
            public string ExchangeId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("website")]
            public Uri Website { get; set; }

            [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
            public Logo Logo { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }
        }

        public partial class Logo
        {
            [JsonProperty("mimeType")]
            public string MimeType { get; set; }

            [JsonProperty("imageData")]
            public string ImageData { get; set; }
        }
    }
}