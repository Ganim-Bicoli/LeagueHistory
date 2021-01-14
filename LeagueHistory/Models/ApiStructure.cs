using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeagueHistory.Models
{
    public class ApiStructure
    {

        private string Key { get; set; }

        private string KeyPath = @"C:\Users\ngadh\Documents\c# projekt\League History\LeagueHistory\LeagueHistory\bin\KeyPath";

        private string ApiRiot { get; set; }

        private string Region { get; set; }

        public ApiStructure()
        {
           
        }
        //public ApiStructure(string region)
        //{
        //    Region = region;
        //    Key = GetKey();
        //}

        protected HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        public string GetApiRiot()
        {
            GetKey();
            return Key;
        }


        protected string GetURI(string path)
        {
            return "https://" + Region + ".api.riotgames.com/lol/" + path + "?api_key=" + Key;
        }

        private void GetKey()
        {
            DirectoryInfo di = new DirectoryInfo(this.KeyPath);
            foreach (var file in di.GetFiles())
            {
                if (file.Name == "Key.txt")
                {
                    try
                    {
                        this.Key = File.ReadAllText(file.FullName);
                        //ToDo, best practise to use API key in Static storage? or have to call it multiple times?
                        //Security?
                    }
                    catch (Exception)
                    {

                        //ToDo fix so that a Exception message alerts and creates a file.
                    }

                }
            }

        }
    }
}