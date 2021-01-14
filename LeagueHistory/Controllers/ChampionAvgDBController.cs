using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using LeagueHistory.Models.MySQLModell;
using MySql.Data.MySqlClient;

namespace LeagueHistory.Controllers
{
    public class ChampionAvgDBController : Controller
    {
        // GET: ChampionAvgDB
        public ActionResult Index()
        {
          LoadChampion();
            return View();
           
        }

        private void LoadChampion()
        {

            List<SummonerAvg> test = new List<SummonerAvg>();

            string mainConn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString; //https://www.youtube.com/watch?v=AzjNyxuT1V4
            MySqlConnection mySqlConn = new MySqlConnection(mainConn);
            string sqlquery = "SELECT * FROM UserLogin";

            MySqlCommand sqlComm = new MySqlCommand(sqlquery, mySqlConn);
            mySqlConn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConn.Close();

            foreach (DataRow item in dt.Rows)
            {
                test.Add(new SummonerAvg {
                    Username = item["Username"].ToString(),
                    Password = item["Password"].ToString(),

                });
            }

            var bar = test;

        }
    }
}