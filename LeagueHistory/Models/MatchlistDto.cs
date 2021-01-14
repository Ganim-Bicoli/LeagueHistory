using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueHistory.Models
{




    public partial class MatchHistory : IEnumerable<MatchHistory>
    {
        [JsonProperty("platformId")]
        public string platformId { get; set; }

        [JsonProperty("gameId")]
        public long gameId { get; set; }

        [JsonProperty("champion")]
        public int champion { get; set; }

        [JsonProperty("queue")]
        public int queue { get; set; }

        [JsonProperty("season")]
        public int season { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("lane")]
        public string lane { get; set; }

        public string championName { get; set; }



        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<MatchHistory> IEnumerable<MatchHistory>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}