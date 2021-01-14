using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LeagueHistory.Models
{

    static public class LeagueChampionsAbilities
    {
        private static string LeagueCharrecterPath = @"C:\Users\ngadh\Documents\c# projekt\League History\LeagueHistory\LeagueHistory\bin\LeagueCharrecterInfo";
        public static string[] champions = getLeagueChampions();
        public static string[] summonerSpells = getLeagueSummoners();


        private static string[] getLeagueSummoners()
        {
            DirectoryInfo di = new DirectoryInfo(LeagueCharrecterPath);
            foreach (var file in di.GetFiles())
            {
                if (file.Name == "LeagueSummoners.txt")
                {
                    try
                    {
                        var GetAllSummoners = File.ReadAllText(file.FullName);
                        string[] SummonersSplitted = GetAllSummoners.Split(',');
                       return SummonersSplitted;
                    }
                    catch (Exception)
                    {
                        //ToDo fix so that a Exception message alerts and creates a file.
                    }
                }
            }
            return champions;
        }

        private static string[] getLeagueChampions()
        {
            DirectoryInfo di = new DirectoryInfo(LeagueCharrecterPath);
            foreach (var file in di.GetFiles())
            {
                if (file.Name == "LeagueCharrecters.txt")
                {
                    try
                    {
                        var GetAllCharecters = File.ReadAllText(file.FullName);
                        string[] CharectersSplitted = GetAllCharecters.Split(',');
          
                        return CharectersSplitted;
                        
                        //ToDo, best practise to use API key in Static storage? or have to call it multiple times?
                        //Security?
                    }
                    catch (Exception)
                    {
                        //ToDo fix so that a Exception message alerts and creates a file.
                    }
                }
      
            }

            return champions;
        }
    }
}