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
using LeagueHistory.Models.myClass;
using RiotSharp.Endpoints.SummonerEndpoint;

namespace LeagueHistory.Controllers
{
    public class SelectedMatchController : Controller
    {
        ApiStructure apiStructure = new ApiStructure();
        public static string[] champions = { "Aatrox","Olaf","Malzahar" ,"Ahri","Sylas","Sett", "Akali", "Lulu", "Alistar", "Amumu", "Annie", "Aphelios", "Ashe", "Janna","Thresh","Rammus","Darius","Ezreal",
            "Twitch","Udyr","Urgot","Varus","Vayne","Veigar","Velkoz","AurelionSol","Azir","Bard","Blitzcrank","Brand","Caitlyn","Camille","Cassiopeia","Chogath","Corki","Diana","DrMundo",
        "Ekko","Elise","Evelynn","Fiddlesticks","Fiora","Fizz","Galio","Gangplank","Garen","Gnar","Gragas","Graves","Hecarim","Heimerdinger","Illaoi","Irelia","JarvanIV","Jax","Jayce","Jhin",
        "Jinx","Kaisa","Kalista","Karma","Karthus","Kassadin","Nautilus","Nidalee","Kayn","Kennen","Khazix","Kindred","KogMaw","Leblanc","LeeSin","Leona","Lucian","Malphite","Maokai","MasterYi"
        ,"MissFortune","MonkeyKing","Morgana","Nami","Nasus","Shyvana","Jhin","Sion","Sivir","Skarner","Sona","Soraka","Swain","Syndra","TahmKench","Taliyah","Talon","Taric","Jhin","Teemo",
        "Tristana","Trundle","Tryndamere","Senna","TwistedFate","Pyke","Twitch","Viktor","Vladimir","Volibear","Vi","Warwick","Xayah","Xerath","XinZhao","Yasuo","Yorick","Yuumi","Zac","Zed","Lux","Ziggs",
        "Zilean","Zoe","Zyra"};

        public static string[] SummonerSpell = { "SummonerBarrier", "SummonerBoost", "SummonerDot", "SummonerExhaust", "SummonerFlash", "SummonerHaste", "SummonerHeal", "SummonerMana", "SummonerPoroRecall", "SummonerPoroThrow", "SummonerSmite", "SummonerSnowball", "SummonerTeleport" };



        // GET: SelectedMatch
        public async Task<ActionResult> Index(long gameid)
        {
          
            List<matchParticipant> funka1 = await GetMatchTeamParticipantsAsync(gameid);
            var brag = funka1;

            List<MyViewModel> viewModel = new List<MyViewModel>();

            viewModel.Add(new MyViewModel()
            {
                TheFirstTable = funka1
               
            });

            return View(viewModel);
        }

        public async Task<List<matchParticipant>> GetMatchTeamParticipantsAsync(long matchId)
        {
            var counter = 0;

            List<championItemList> teamParticipantsWin = new List<championItemList>();
            List<championItemList> teamParticipantsLose = new List<championItemList>();
            List<SumParticipant> participants = new List<SumParticipant>();
            List<matchParticipant> funka1 = new List<matchParticipant>();

            List<Timeline> hanam = new List<Timeline>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://euw1.api.riotgames.com/lol/match/v4/matches/4695908702?api_key=" + apiStructure.GetApiRiot());

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            System.Threading.Thread.Sleep(100);
            HttpResponseMessage response = await client.GetAsync("https://euw1.api.riotgames.com/lol/match/v4/matches/" + matchId + "?api_key=" + apiStructure.GetApiRiot()).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                dynamic jsonObject = await response.Content.ReadAsStringAsync();
                Root2 myDeserializedClass = JsonConvert.DeserializeObject<Root2>(jsonObject);

                for (int i = 0; i < 10; i++)
                {

                    if (myDeserializedClass.participants[i].stats.win == true)
                    {
                        teamParticipantsWin.Add(new championItemList()
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
                            summonerName = myDeserializedClass.participantIdentities[i].player.summonerName,
                        
                            
                             

                        }); ;


                    }
                    else
                    {

                        teamParticipantsLose.Add(new championItemList()
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
                            summonerName = myDeserializedClass.participantIdentities[i].player.summonerName

                        }); ;
                    }
                }

                for (int g = counter; g < (teamParticipantsWin.Count()); g++)
                {
                    participants.Add(new SumParticipant() //Göra om så det blir två listor? eller ha dem i samma lsita?
                    {

                        teamParticipantWin = teamParticipantsWin[counter],
                        teamParticipantLose = teamParticipantsLose[counter],

                    });;

                    counter++;
                }

                funka1.Add(new matchParticipant()
                {
                    gameParticipants = participants           
                }) ; 
            }
            
            return funka1;
        }
    }
}