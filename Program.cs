using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// using System.Text.Json;
namespace ConsoleApp1

{
    class Program
    {

        static void Main(string[] args)
        {

            string json1;
            // string count = json.Split(':')[1].Replace("}", "");
            string date = "2021-08-10";
            int result = DateTime.Compare(DateTime.Today, DateTime.Parse(date));
            string address;
            // string count = json.Split(':')[1].Replace("}", "");
            if (result > 0)
            {
                address =
                    "http://livescore-api.com/api-client/scores/history.json?key=EryzF6zmFoiH4b13&secret=piJEOCYWGPz2274GzDgeJPAodS6i48mt&from=" +
                    date;
            }
            else
            {
                address =
                    "https://livescore-api.com/api-client/fixtures/matches.json?&key=EryzF6zmFoiH4b13&secret=piJEOCYWGPz2274GzDgeJPAodS6i48mt&date=" +
                    date;
            }

            json1 = new System.Net.WebClient().DownloadString(address);
            JObject json = JObject.Parse(json1);
            // Console.WriteLine(json);
            JsonTextReader reader = new JsonTextReader(new StringReader(json1));
            // while (reader.Read())
            // {
            //     if (reader.Value != null)
            //     {
            //         Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
            //     }
            //     else
            //     {
            //         Console.WriteLine("Token: {0}", reader.TokenType);
            //     }
            // }

            string match1 = (json.SelectToken("data.match")).ToString();
            // Console.WriteLine("match 1 : "+match1);
            JArray items = JArray.Parse(match1);
            // 
            ArrayList games = new ArrayList();
            string home, away, time;
            for (int i = 0; i < items.Count; i++)
            {
                home = items[i].SelectToken("home_name").ToString(); 
                away=items[i].SelectToken("away_name").ToString(); 
                time=items[i].SelectToken("scheduled").ToString(); 
                Game game = new Game(home,away,time);
                games.Add(game);
                Console.WriteLine(home);
                Console.WriteLine(away);
                Console.WriteLine(time);

            }
            

    }
    }
    
}

