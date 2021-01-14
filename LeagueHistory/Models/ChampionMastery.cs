using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueHistory.Models
{
    public class ChampionMastery : object
    {
        public long ChampionId { get; set; }
        public int ChampionLevel { get; set; }
        public int ChampionPoints { get; set; }
        public long ChampionPointsSinceLastLevel { get; set; }
        public long ChampionPointsUntilNextLevel { get; set; }
        public bool ChestGranted { get; set; }
        public DateTime LastPlayTime { get; set; }
        public long PlayerId { get; set; }
    }
}