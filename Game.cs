using System;

namespace ConsoleApp1
{
           public class Game
        {
            private string time { get; set; }
            private string away_name { get; set; }
            private string home_name { get; set; }
            public Game(string home, string away, string hour)
                {
                    time = hour;
                    home_name = home;
                    away_name = away;
                }
        }
}