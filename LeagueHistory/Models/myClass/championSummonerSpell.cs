using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueHistory.Models.myClass
{

    public class SummonerSpells
    {
        public string Name { get; set; }
        public int Key { get; set; }

        public string Id { get; set; }
    }

    public class SummonerSpellData 
    {

        //     public SummonerSpells SummonerBarrier { get; set; }

        public SummonerSpells SummonerBarrier { get; set; }
        public SummonerSpells SummonerBoost { get; set; }
        public SummonerSpells SummonerDot { get; set;}
        public SummonerSpells SummonerExhaust { get; set; }
        public SummonerSpells SummonerFlash { get; set; }
        public SummonerSpells SummonerHaste { get; set; }
        public SummonerSpells SummonerHeal { get; set; }
        public SummonerSpells SummonerMana { get; set; }
        public SummonerSpells SummonerPoroRecall { get; set; }
        public SummonerSpells SummonerPoroThrow { get; set; }
        public SummonerSpells SummonerSmite { get; set; }
        public SummonerSpells SummonerSnowball { get; set; }
        public SummonerSpells SummonerTeleport { get; set; }



    }


    public class championSummonerSpell
    {
        public SummonerSpellData data { get; set; }

    }
}