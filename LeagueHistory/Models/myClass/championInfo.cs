using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueHistory.Models.myClass
{
 
    public class championItemList
    {
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }

        public string summonerName { get; set; }

        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }

        public string SummonerSpell1 { get; set; }
        public string SummonerSpell2 { get; set; }


        public double Kills { get; set; }
        public double Death { get; set; }
        public double Assist { get; set; }
        public int totalMinionsKilled { get; set; }
        public bool win { get; set; }
        public string winStatus { get; set; }
        public int goldEarned { get; set; }

        public bool Win { get; set; }



    }

    public class SumParticipant
    {
        public championItemList singelParticipant { get; set; }
        public championItemList teamParticipantWin { get; set; }
        public championItemList teamParticipantLose { get; set; }


    }

    public class matchParticipant
    {
        public List<SumParticipant> gameParticipants { get; set; }

    }

    public class championInfo
    {
        public string name;

        public  List<matchParticipant> matchParticipants { get; set; }

    }

}