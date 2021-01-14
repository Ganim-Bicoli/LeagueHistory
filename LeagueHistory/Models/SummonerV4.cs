using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueHistory.Models
{
    public class SummonerV4
    {
        public string id { get; set; }
        public string accountId { get; set; }
        public string puuid { get; set; }
        public string profileIconId { get; set; }
        public string revisionDate { get; set; }
        public string summonerLevel { get; set; }
    }
}