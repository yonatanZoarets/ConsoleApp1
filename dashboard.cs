using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1.API.Controllers
{
    [Route("api/[controller]")]
    public class dashboard: Controller
    {

        //GET api/values/5
        [HttpPost]
        public ArrayList get(DateTime date)
        {
            string string_date = date.ToString();
            return get(string_date);
        }
        
        //GET api/values/5
        [HttpPost]
        public ArrayList get(string date)
        {
            string json1;
            DateTime timeDateTime = DateTime.Parse(date);
            string address;
            // string count = json.Split(':')[1].Replace("}", "");
            int result = DateTime.Compare(DateTime.Today, timeDateTime);
            if (result > 0)
                { 
                    address="http://livescore-api.com/api-client/scores/history.json?key=EryzF6zmFoiH4b13&secret=piJEOCYWGPz2274GzDgeJPAodS6i48mt&from="+date;

           }
                else
            {
                address="https://livescore-api.com/api-client/fixtures/matches.json?&key=EryzF6zmFoiH4b13&secret=piJEOCYWGPz2274GzDgeJPAodS6i48mt&date="+date;
            }
            json1 = new System.Net.WebClient().DownloadString(address);
            JObject json = JObject.Parse(json1);
            string match1 = (json.SelectToken("data.match")).ToString();
            JArray items = JArray.Parse(match1);
            ArrayList games = new ArrayList();
            string home, away, time;
            for (int i = 0; i < items.Count; i++)
            {
                home = items[i].SelectToken("home_name").ToString(); 
                away=items[i].SelectToken("away_name").ToString(); 
                time=items[i].SelectToken("scheduled").ToString(); 
                Game game = new Game(home,away,time);
                games.Add(game);
                

            }
            // Console.WriteLine("match 1 : "+match1);
            // Console.WriteLine("json" +json);
            return games;
        }
        
    }
}