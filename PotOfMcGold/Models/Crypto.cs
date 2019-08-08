using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace PotOfMcGold.Models
{
    public class IndexClass
    {
        public partial class CryptoIndex
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
            [JsonProperty("assetId")]
            public string AssetId { get; set; }

            [JsonProperty("originalSymbol")]
            public string OriginalSymbol { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
            public string Slug { get; set; }

            [JsonProperty("cryptoType")]
            public bool CryptoType { get; set; }

            [JsonProperty("supply", NullValueHandling = NullValueHandling.Ignore)]
            public double? Supply { get; set; }

            [JsonProperty("marketCap", NullValueHandling = NullValueHandling.Ignore)]
            public double? MarketCap { get; set; }

            [JsonProperty("price")]
            public double Price { get; set; }

            [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
            public double? Volume { get; set; }

            [JsonProperty("change", NullValueHandling = NullValueHandling.Ignore)]
            public double? Change { get; set; }

            [JsonProperty("change1Hour", NullValueHandling = NullValueHandling.Ignore)]
            public double? Change1Hour { get; set; }

            [JsonProperty("change1Week", NullValueHandling = NullValueHandling.Ignore)]
            public double? Change1Week { get; set; }

            [JsonProperty("allTimeHigh")]
            public double AllTimeHigh { get; set; }

            [JsonProperty("allTimeLow")]
            public double AllTimeLow { get; set; }

            [JsonProperty("earliestKnownPrice")]
            public double EarliestKnownPrice { get; set; }

            [JsonProperty("earliestTradeDate")]
            public long EarliestTradeDate { get; set; }

            [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
            public Logo Logo { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }
        }
    }

    public partial class Logo
    {
        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("imageData")]
        public string ImageData { get; set; }
    }

    public class DetailClass
    {
        public partial class CryptoDetail
        {
            [JsonProperty("payload")]
            public Payload Payload { get; set; }
        }
        public partial class Payload
        {
            [JsonProperty("assetId")]
            public string AssetId { get; set; }

            [JsonProperty("originalSymbol")]
            public string OriginalSymbol { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("cryptoType")]
            public bool CryptoType { get; set; }

            [JsonProperty("supply")]
            public double Supply { get; set; }

            [JsonProperty("marketCap")]
            public double MarketCap { get; set; }

            [JsonProperty("price")]
            public double Price { get; set; }

            [JsonProperty("volume")]
            public double Volume { get; set; }

            [JsonProperty("change")]
            public double Change { get; set; }

            [JsonProperty("change1Hour")]
            public double Change1Hour { get; set; }

            [JsonProperty("change1Week")]
            public double Change1Week { get; set; }

            [JsonProperty("allTimeHigh")]
            public double AllTimeHigh { get; set; }

            [JsonProperty("allTimeLow")]
            public double AllTimeLow { get; set; }

            [JsonProperty("earliestKnownPrice")]
            public double EarliestKnownPrice { get; set; }

            [JsonProperty("earliestTradeDate")]
            public long EarliestTradeDate { get; set; }

            [JsonProperty("logo")]
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


