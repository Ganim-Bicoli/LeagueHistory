using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LeagueHistory.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RiotSharp;
using RiotSharp.Misc;
using System.Linq;
using System.IO;

using LeagueHistory.Models.myClass;
using RiotSharp.Endpoints.SummonerEndpoint;

namespace LeagueHistory.Controllers
{
    public class HomeController : Controller
    {
        private static ApiStructure apiStructure = new ApiStructure();
        private string ApiKey = apiStructure.GetApiRiot();
        public static string[] champions = LeagueChampionsAbilities.champions;
        public static string[] SummonerSpell = LeagueChampionsAbilities.summonerSpells;
        // GET: Home

        public async Task<ActionResult> Index()
        {

            return View();
            return RedirectToAction("Index", "ChampionAvgDB");

         
        }



        [HttpPost]
        public async Task<ActionResult> DisplayAccount(string selectedRegion, string user, int historyNumber)
        {
        
            var api = RiotApi.GetDevelopmentInstance(ApiKey);
            SummonerV4 UserInfo = new SummonerV4();
            List<MyViewModel> viewModel = new List<MyViewModel>();

            

            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(Region.Euw, user).Result;

                UserInfo.accountId = summoner.AccountId;
                var bruh = api.ChampionMastery.GetChampionMasteryAsync(Region.Euw, summoner.AccountId, 99);

                viewModel = await GetMatchAsync(Region.Euw, UserInfo.accountId, historyNumber);
            }
            catch (RiotSharpException ex)
            {
                // Handle the exception however you want.
            }
            var temp = viewModel;

            ViewBag.AmmountOfGames = (historyNumber);

            return View(viewModel);
        }

        public async Task<List<MyViewModel>> GetMatchAsync(Region region, string AccountId, int matchAmmount)
        {
            var api = RiotApi.GetDevelopmentInstance(ApiKey);

            List<MatchHistory> ListOfMatch = new List<MatchHistory>();
            List<matchParticipant> TempListOfGame = new List<matchParticipant>();
            List<matchParticipant> ListOfGame = new List<matchParticipant>();

            var matches = api.Match.GetMatchListAsync(Region.Euw, AccountId).Result;


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ddragon.leagueoflegends.com/cdn/10.11.1/data/en_US/champion.json");

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            for (int i = 0; i < matchAmmount; i++)
            {
                ListOfMatch.Add(new MatchHistory()
                {
                    lane = matches.Matches[i].Lane.ToString(),
                    champion = Convert.ToInt32(matches.Matches[i].ChampionID),
                    season = Convert.ToInt32(matches.Matches[i].Season),
                    role = matches.Matches[i].Role.ToString(),
                    platformId = matches.Matches[i].PlatformID.ToString(),
                    gameId = matches.Matches[i].GameId,
                    queue = matches.Matches[i].Queue
                });

                TempListOfGame = await GetMatchParticipantsItemsAsync(ListOfMatch[i].gameId, AccountId); //gör en statisk lista om håller kvar alla matcher? eller ett objekt lista?
                //public async Task<List<championItemList>> GetMatchSummonerSpells(List<championItemList> championItemLists)
               
                ListOfGame.Add(new matchParticipant()
                {
                    gameParticipants = TempListOfGame[0].gameParticipants
                }); 
                
                //Index Must be 0. since the call only collects 1 call at time. FIX   //ToDo. Find solution to call function, collect all games and return a full list. Try to make it into only 1 call.
                     //Solution might be to create a list of ListOfMatch and select all gameId and send it? Look into this
                HttpResponseMessage response = await client.GetAsync("http://ddragon.leagueoflegends.com/cdn/10.11.1/data/en_US/champion.json").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    dynamic jsonObject = await response.Content.ReadAsStringAsync();
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonObject);
                    var data = myDeserializedClass.data;

                    foreach (var champion in champions)
                    {
                        var property = data.GetType().GetProperty(champion);
                        var propertyValue = property.GetValue(data) as charInfo;

                        foreach (var champ in ListOfMatch)
                        {
                            if (champ.champion == Convert.ToInt32(propertyValue.key))
                            {
                                champ.championName = propertyValue.name;
                                
                                //  return champ.championName.FirstOrDefault();  #ToDo. Gör en first or defualt
                            }
                            if (champ.championName == null)
                            {
                                champ.championName = champ.champion.ToString();
                            }
                        }

                    }

                }
            }
            List<MyViewModel> viewModel = new List<MyViewModel>();

            viewModel.Add(new MyViewModel()
            {
                TheFirstTable = ListOfGame,
                TheSecondTable = ListOfMatch
            });

            return viewModel;
        }

        public async Task<List<matchParticipant>> GetMatchParticipantsItemsAsync(long matchId, string accountId)
        {
            var counter = 0;

            List<championItemList> teamChamptionItemList = new List<championItemList>();
            List<championItemList> TempList = new List<championItemList>();


            List<championItemList> singelChampionItemList = new List<championItemList>();
            List<SumParticipant> participants = new List<SumParticipant>();
            List<matchParticipant> funka1 = new List<matchParticipant>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://euw1.api.riotgames.com/lol/match/v4/matches/4695908702?api_key=" + ApiKey);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("https://euw1.api.riotgames.com/lol/match/v4/matches/" + matchId + "?api_key=" + ApiKey).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonObject = await response.Content.ReadAsStringAsync();
                Root2 myDeserializedClass = JsonConvert.DeserializeObject<Root2>(jsonObject);

                for (int i = 0; i < 10; i++)
                {


                    teamChamptionItemList.Add(new championItemList()
                    {
                        item0 = myDeserializedClass.participants[i].stats.item0,
                        item1 = myDeserializedClass.participants[i].stats.item1,
                        item2 = myDeserializedClass.participants[i].stats.item2,
                        item3 = myDeserializedClass.participants[i].stats.item3,
                        item4 = myDeserializedClass.participants[i].stats.item4,
                        item5 = myDeserializedClass.participants[i].stats.item5,

                        Spell1Id = myDeserializedClass.participants[i].spell1Id,
                        Spell2Id = myDeserializedClass.participants[i].spell2Id,

                        Kills = myDeserializedClass.participants[i].stats.kills,
                        Death = myDeserializedClass.participants[i].stats.deaths,
                        Assist = myDeserializedClass.participants[i].stats.assists,
                        goldEarned = myDeserializedClass.participants[i].stats.goldEarned,
                        totalMinionsKilled = myDeserializedClass.participants[i].stats.totalMinionsKilled,
                        win = myDeserializedClass.participants[i].stats.win,
                        
                        

                    }); ;

                    if (teamChamptionItemList[i].win == true)
                    {
                        teamChamptionItemList[i].winStatus = "Victory";
                    }
                    else
                    {
                        teamChamptionItemList[i].winStatus = "Defeat";
                    }

                    TempList = await GetMatchSummonerSpells(teamChamptionItemList);
                    TempList[i].SummonerSpell1 = teamChamptionItemList[i].SummonerSpell1;
                    TempList[i].SummonerSpell2 = teamChamptionItemList[i].SummonerSpell2;

                    if (myDeserializedClass.participantIdentities[i].player.currentAccountId == accountId)  //Collects items from singel champion.
                    {

                        singelChampionItemList.Add(new championItemList()
                        {
                            item0 = teamChamptionItemList[i].item0,
                            item1 = teamChamptionItemList[i].item1,
                            item2 = teamChamptionItemList[i].item2,
                            item3 = teamChamptionItemList[i].item3,
                            item4 = teamChamptionItemList[i].item4,
                            item5 = teamChamptionItemList[i].item5,
                            summonerName = myDeserializedClass.participantIdentities[i].player.summonerName,


                            Spell1Id = myDeserializedClass.participants[i].spell1Id,
                            Spell2Id = myDeserializedClass.participants[i].spell2Id,

                            SummonerSpell1 = TempList[i].SummonerSpell1,
                            SummonerSpell2 = TempList[i].SummonerSpell2,
                             Kills = teamChamptionItemList[i].Kills,
                            Death = teamChamptionItemList[i].Death,
                            Assist = teamChamptionItemList[i].Assist,
                            goldEarned = teamChamptionItemList[i].goldEarned,
                            totalMinionsKilled = teamChamptionItemList[i].totalMinionsKilled,
                            win = teamChamptionItemList[i].win,
                            winStatus = teamChamptionItemList[i].winStatus
                        });
                    }

                }

            
                for (int g = counter; g < (singelChampionItemList.Count()); g++)
                {
                    participants.Add(new SumParticipant()
                    {

                        singelParticipant = singelChampionItemList[counter]
                    });

                    counter++;
                }

           
                funka1.Add(new matchParticipant()
                {
                    gameParticipants = participants


                }); ;
            }


            

       
            return funka1;
        }


        //public async Task<championItemList> GetMatchSummonerSpells(championItemList championItemLists)
        //{

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://ddragon.leagueoflegends.com/cdn/10.14.1/data/en_US/summoner.json");

        //    client.DefaultRequestHeaders.Accept.Add(
        //    new MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = await client.GetAsync("http://ddragon.leagueoflegends.com/cdn/10.14.1/data/en_US/summoner.json");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        dynamic jsonObject = await response.Content.ReadAsStringAsync();
        //        championSummonerSpell myDeserializedClass = JsonConvert.DeserializeObject<championSummonerSpell>(jsonObject);
        //        var SumInfo = myDeserializedClass.data;

        //        SummonerSpells gargar = new SummonerSpells();
        //        var Första = typeof(SummonerSpellData);

        //        foreach (var SpellName in SummonerSpell)
        //        {
        //            var ganim = Första.GetProperty(SpellName); //https://www.youtube.com/watch?v=3FvT6uNMT7M Reflection 14:00. AS BRA :D 
        //            var kanske = ganim.GetValue(SumInfo) as SummonerSpells;



        //                if (kanske.Key == championItemLists.Spell1Id)
        //                {
        //                    championItemLists.SummonerSpell1 = kanske.Name;
        //                }
        //                if (kanske.Key == championItemLists.Spell2Id && championItemLists.Spell1Id != kanske.Key)
        //                {
        //                    championItemLists.SummonerSpell2 = kanske.Name;

        //                }


        //        }

        //    }
        //    var gaerg = championItemLists;
        //    return championItemLists;


        //}


            public async Task<List<championItemList>> GetMatchSummonerSpells(List<championItemList> championItemLists)
        {
            List<championItemList> test = new List<championItemList>();

            var nagag = championItemLists;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ddragon.leagueoflegends.com/cdn/10.14.1/data/en_US/summoner.json");

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("http://ddragon.leagueoflegends.com/cdn/10.14.1/data/en_US/summoner.json").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonObject = await response.Content.ReadAsStringAsync();
                championSummonerSpell myDeserializedClass = JsonConvert.DeserializeObject<championSummonerSpell>(jsonObject);
                var SumInfo = myDeserializedClass.data;

                SummonerSpells gargar = new SummonerSpells();
                var Första = typeof(SummonerSpellData);

                foreach (var SpellName in SummonerSpell)
                {
                    var ganim = Första.GetProperty(SpellName); //https://www.youtube.com/watch?v=3FvT6uNMT7M Reflection 14:00. AS BRA :D 
                    var kanske = ganim.GetValue(SumInfo) as SummonerSpells;


                    for (int i = 0; i < championItemLists.Count(); i++)
                    {
                        if (kanske.Key == championItemLists[i].Spell1Id)
                        {
                            championItemLists[i].SummonerSpell1 = kanske.Id;

                            
                        }
                        if (kanske.Key == championItemLists[i].Spell2Id && championItemLists[i].Spell1Id != kanske.Key)
                        {
                            championItemLists[i].SummonerSpell2 = kanske.Id;

                        }
                    }

                }

            }
         

            return championItemLists;
        }
    }
}