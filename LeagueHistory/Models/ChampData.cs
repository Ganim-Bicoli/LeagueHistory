using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueHistory.Models
{
    public class ChampData : object
    {
        public string name;
        public int id;

        public string platformId { get; set; }

   
        public long gameId { get; set; }

 
        public int champion { get; set; }

     
        public int queue { get; set; }

    
        public int season { get; set; }

    
        public long timestamp { get; set; }

      
        public string role { get; set; }

  
        public string lane { get; set; }
    }
}