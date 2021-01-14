using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueHistory.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


    public class charInfo
    {
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }

        public string title { get; set; }

    }

    public class Data
    {
        //champions = { "Aatrox", "Sylas", "Akali", "Lulu", "Alistar", "Amumu", "Annie", "Aphelios", "Ashe", "Aurelion Sol", "Lulu","Jarvan","Janna","Thresh","Rammus","Master-yi","Darius","Draven","Ezreal","Velkoz"};

        //  Twitch, Udyr, Urgot, Varus, Vayne, Veigar, Velkoz, , AurelionSol, Azir, Bard, Blitzcrank, Brand,Caitlyn, Camille,Cassiopeia, Chogath, Corki, Diana, DrMundo, Ekko, Elise, Evelynn, 
        //Fiddlesticks, Fiora, Fizz, Galio, Gangplank, Garen, Gnar, Gragas, Graves, Hecarim, Heimerdinger, Illaoi, Irelia, Ivern, JarvanIV, Jax, Jayce, Jhin, Jinx, Kaisa, Kalista, Karma, Karthus, Kassadin, 
        //Katarina, Kayle, Kayn, Kennen, Khazix,Kindred Kled, KogMaw, Leblanc,LeeSin , Leona, Lissandra, Lucian, Malphite, Malzahar, Maokai, MasterYi, MissFortune, MonkeyKing, Mordekaiser, Morgana, Nami, Nasus, 
        //Nautilus, Nidalee, Nocturne, Nunu, Olaf, Orianna, Ornn, Pantheon, Poppy, Pyke, Qiyana, Quinn, Rakan, Rammus, RekSai, Renekton, Rengar, Riven, Rumble, Ryze, Sejuani, Senna, Sett, Shaco, Shen, 
        //Shyvana, Singed, Sion, Sivir, Skarner, Sona, Soraka, Swain, Syndra, TahmKench, Taliyah, Talon, Taric, Teemo, 
        public charInfo Aatrox { get; set; }

        public charInfo Olaf { get; set; }
        public charInfo Irelia { get; set; }
        public charInfo Tryndamere { get; set; }
        public charInfo Swain { get; set; }
        public charInfo Syndra { get; set; }
        public charInfo TahmKench { get; set; }
        public charInfo Taliyah { get; set; }
        public charInfo Talon { get; set; }
        public charInfo Taric { get; set; }
        public charInfo Teemo { get; set; }

        public charInfo Renekton { get; set; }
        public charInfo Rengar { get; set; }
        public charInfo Riven { get; set; }
        public charInfo Rumble { get; set; }
        public charInfo Ryze { get; set; }
        public charInfo Sejuani { get; set; }
        public charInfo Senna { get; set; }
        public charInfo Sett { get; set; }
        public charInfo Shaco { get; set; }
        public charInfo Shen { get; set; }
        public charInfo Shyvana { get; set; }
        public charInfo Singed { get; set; }
        public charInfo Sion { get; set; }
        public charInfo Sivir { get; set; }
        public charInfo Skarner { get; set; }
        public charInfo Sona { get; set; }

        public charInfo Soraka { get; set; }
        public charInfo Nunu { get; set; }
        public charInfo Ahri { get; set; }
        public charInfo Orianna { get; set; }
        public charInfo Ornn { get; set; }
        public charInfo Pantheon { get; set; }
        public charInfo Poppy { get; set; }
        public charInfo Pyke { get; set; }
        public charInfo Qiyana { get; set; }
        public charInfo Quinn { get; set; }
        public charInfo Rakan { get; set; }
        public charInfo Rammus { get; set; }
        public charInfo RekSai { get; set; }

        public charInfo Leona { get; set; }
        public charInfo Lissandra { get; set; }
        public charInfo Lucian { get; set; }
        public charInfo Malphite { get; set; }
        public charInfo Malzahar { get; set; }
        public charInfo Maokai { get; set; }
        public charInfo MasterYi { get; set; }
        public charInfo MonkeyKing { get; set; }
        public charInfo MissFortune { get; set; }
        public charInfo Mordekaiser { get; set; }
        public charInfo Morgana { get; set; }
        public charInfo Nami { get; set; }
        public charInfo Nasus { get; set; }
        public charInfo Nautilus { get; set; }
        public charInfo Nidalee { get; set; }
        public charInfo Nocturne { get; set; }

        public charInfo Katarina { get; set; }
        public charInfo Kayle { get; set; }
        public charInfo Kayn { get; set; }
        public charInfo Kennen { get; set; }
        public charInfo Khazix { get; set; }
        public charInfo Kindred { get; set; }
        public charInfo Kled { get; set; }

        public charInfo KogMaw { get; set; }
        public charInfo Leblanc { get; set; }
        public charInfo LeeSin { get; set; }
        public charInfo Graves { get; set; }
        public charInfo Hecarim { get; set; }
        public charInfo Heimerdinger { get; set; }
        public charInfo Illaoi { get; set; }
        public charInfo Ivern { get; set; }
        public charInfo Jax { get; set; }
        public charInfo JarvanIV { get; set; }
        public charInfo Jayce { get; set; }
        public charInfo Jhin { get; set; }
        public charInfo Jinx { get; set; }
        public charInfo Kaisa { get; set; }
        public charInfo Kalista { get; set; }
        public charInfo Karma { get; set; }

        public charInfo Karthus { get; set; }
        public charInfo Kassadin { get; set; }
        public charInfo Fiora { get; set; }
        public charInfo Fizz { get; set; }
        public charInfo Galio { get; set; }
        public charInfo Gangplank { get; set; }
        public charInfo Garen { get; set; }

        public charInfo Gnar { get; set; }
        public charInfo Gragas { get; set; }
        public charInfo AurelionSol { get; set; }
        public charInfo Diana { get; set; }
        public charInfo DrMundo { get; set; }
        public charInfo Ekko { get; set; }
        public charInfo Elise { get; set; }
        public charInfo Evelynn { get; set; }

        public charInfo Fiddlesticks { get; set; }
        public charInfo Azir { get; set; }
        public charInfo Blitzcrank { get; set; }
        public charInfo Bard { get; set; }
        public charInfo Caitlyn { get; set; }
        public charInfo Brand { get; set; }
        public charInfo Camille { get; set; }
        public charInfo Cassiopeia { get; set; }
        public charInfo Chogath { get; set; }
        public charInfo Corki { get; set; }

        public charInfo Tristana { get; set; }
        public charInfo Yorick { get; set; }
        public charInfo Yuumi { get; set; }
        public charInfo Zac { get; set; }
        public charInfo TwistedFate { get; set; }
        public charInfo Twitch { get; set; }
        public charInfo Udyr { get; set; }
        public charInfo Urgot { get; set; }
        public charInfo Varus { get; set; }

        public charInfo Vayne { get; set; }
        public charInfo Veigar { get; set; }
        public charInfo Velkoz { get; set; }
        public charInfo Trundle { get; set; }
        public charInfo Vi { get; set; }
        public charInfo Viktor { get; set; }
        public charInfo Xerath { get; set; }
        public charInfo Vladimir { get; set; }
        public charInfo Volibear { get; set; }
        public charInfo Zed { get; set; }
        public charInfo Ziggs { get; set; }
        public charInfo Zoe { get; set; }
        public charInfo Zilean { get; set; }
        public charInfo Zyra { get; set; }
        public charInfo Warwick { get; set; }

        public charInfo Xayah { get; set; }
        public charInfo XinZhao { get; set; }
        public charInfo Yasuo { get; set; }
        public charInfo Sylas { get; set; }
        public charInfo Akali { get; set; }
        public charInfo Lulu { get; set; }
        public charInfo Alistar { get; set; }
        public charInfo Amumu { get; set; }
        public charInfo Annie { get; set; }
        public charInfo Aphelios { get; set; }
        public charInfo Ashe { get; set; }
        public charInfo Janna { get; set; }
        public charInfo Thresh { get; set; }    
        public charInfo Darius { get; set; }
        public charInfo Lux { get; set; }
        public charInfo Ezreal { get; set; }

    }

    public class Root
    {
        public Data data { get; set; }
    }


}