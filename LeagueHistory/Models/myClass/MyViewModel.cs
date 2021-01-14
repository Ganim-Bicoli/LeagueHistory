using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeagueHistory.Models;

namespace LeagueHistory.Models.myClass
{
    public class MyViewModel
    {
        public List<matchParticipant> TheFirstTable { get; set; }
        public List<MatchHistory> TheSecondTable { get; set; }

    }
}