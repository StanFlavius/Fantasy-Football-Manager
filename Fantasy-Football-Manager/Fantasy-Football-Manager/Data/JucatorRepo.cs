using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fantasy_Football_Manager.Data
{
    public class JucatorRepo : IJucatorRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public JucatorRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool SaveChanges()
        {
            return (_applicationDbContext.SaveChanges() >= 0);
        }

        public Jucator GetJucator(string name, string surname)
        {
            Console.WriteLine("IN FUNCTIE" + " " + name + "." + surname);
            var jucator = _applicationDbContext.Jucatori
                            .FirstOrDefault<Jucator>(j => j.NumeJucator == name && j.PrenumeJucator.Substring(0,1) == surname);
            
            /*var query = from j in _applicationDbContext.Jucatori
                           where j.NumeJucator == name && j.PrenumeJucator[0] == surname
                           select j;*/

            //int jucatorId = jucator.JucatorId;

            //StatisticiJucator myStatisticiJucator = _applicationDbContext.StatisticiJucatori.FirstOrDefault(s => s.StatisticiJucatorId == jucatorId);
            //var jucator = query.FirstOrDefault<Jucator>();
            return jucator;
        }

        public int GetPointsByParams(string position, string eventMatch)
        {
            if (eventMatch == "played")
                return 1;
            if (eventMatch == "notPlayed60")
                return -1;
            if (eventMatch == "lineup")
                return 2;
            if (eventMatch == "goal" && position == "Portar")
                return 7;
            if (eventMatch == "goal" && position == "Fundas")
                return 6;
            if (eventMatch == "goal" && position == "Mijlocas")
                return 5;
            if (eventMatch == "goal" && position == "Atacant")
                return 4;
            if (eventMatch == "assist" && position == "Portar")
                return 6;
            if (eventMatch == "assist" && position == "Fundas")
                return 5;
            if (eventMatch == "assist" && position == "Mijlocas")
                return 4;
            if (eventMatch == "assist" && position == "Atacant")
                return 3;
            if (eventMatch == "cleansheet" && (position == "portar" || position == "fundas"))
                return 6;
            if (eventMatch == "cleansheet" && (position == "mijlocas" || position == "atacant"))
                return 2;
            if (eventMatch == "yellow card")
                return -2;
            if (eventMatch == "red card")
                return -4;
            return 0;
        }

        public void EditPointsPlayer(string name, string data)
        {
            string[] words = name.Split(' ');

            string namePlayer, surnamePlayer;

            if (words.Length == 1)
            {
                Console.WriteLine("HEI");
                namePlayer = words[0];
                surnamePlayer = "";
            }
            else
            {
                namePlayer = "";
                for (int i = 0; i < words.Length - 1; i++)
                {
                    namePlayer += words[i];
                    if (i != words.Length - 2)
                        namePlayer += " ";
                }

                string[] words2 = words[words.Length - 1].Split('.');
                surnamePlayer = words2[0];
            }
       
            //Console.WriteLine(surnamePlayer + ".S");
            Jucator jucator = GetJucator(namePlayer, surnamePlayer);

            int nrPoints = GetPointsByParams(jucator.PozitieJucator, data);

            Console.WriteLine("AM LUAT PUNCTE");
            int jucatorId = jucator.JucatorId;
            StatisticiJucator statisticiJucator = _applicationDbContext.StatisticiJucatori.FirstOrDefault(s => s.StatisticiJucatorId == jucatorId);

            string points = nrPoints.ToString();
            Console.WriteLine("AFARA" + jucator.NumeJucator + " " + jucator.PrenumeJucator + " " + points);
            Console.WriteLine(" ");
            /*statisticiJucator.NrTotalPuncte += nrPoints;
            if (data == "goal")
            {
                statisticiJucator.NrGoluri++;
            }
            if (data == "assist")
            {
                statisticiJucator.NrAssists++;
            }
            if (data == "cleansheet")
            {
                statisticiJucator.NrCleansheets++;
            }*/
        }

        public async Task<List<Jucator>> GetAllPlayersAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://apiv2.apifootball.com/?action=get_teams&league_id=148&APIkey=abaf250928e03ae4b44f868683a80d5d25387a925ecbd272d00c121151d3b23b");

            HttpContent content = response.Content;

            string data = await content.ReadAsStringAsync();

            List<EchipaJSON> myData = JsonConvert.DeserializeObject<List<EchipaJSON>>(data);  

            int cnt = 1;
            List<Jucator> jucatori = new List<Jucator>();

            foreach (EchipaJSON echipaJSON in myData)
            {
                string numeEchipa = echipaJSON.team_name;
                foreach(JucatorJSON jucatorIt in echipaJSON.players)
                {
                    Jucator jucator = new Jucator();
                    jucator.JucatorId = cnt; cnt++;
                    Console.WriteLine(jucatorIt.player_name);
                    string[] words = jucatorIt.player_name.Split(' ');
                    if (words.Length == 2)
                    {
                        jucator.NumeJucator = words[0];
                        jucator.PrenumeJucator = words[1];
                    }
                    else
                    {
                        jucator.NumeJucator = words[0];
                        jucator.PrenumeJucator = "";
                    }
                    if (jucatorIt.player_type == "Goalkeepers")
                        jucator.PozitieJucator = "Portar";
                    if (jucatorIt.player_type == "Defenders")
                        jucator.PozitieJucator = "Fundas";
                    if (jucatorIt.player_type == "Midfielders")
                        jucator.PozitieJucator = "Mijlocas";
                    if (jucatorIt.player_type == "Forwards")
                        jucator.PozitieJucator = "Atacant";
                    jucator.EchipaFotbal = numeEchipa;
                    jucatori.Add(jucator);
                }
                
            }
            return jucatori;
        }
        
        public async Task UpdatePlayers(string startDate, string endDate)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://apiv2.apifootball.com/?action=get_events&league_id=148&APIkey=abaf250928e03ae4b44f868683a80d5d25387a925ecbd272d00c121151d3b23b&from=" + startDate + "&to=" + endDate);

            HttpContent content = response.Content;

            string data = await content.ReadAsStringAsync();

            JArray matches = JArray.Parse(data);

            foreach(JObject match in matches)
            {

                string matchStatus = (string)match["match_status"];
                Console.WriteLine(matchStatus);
                if (matchStatus == "Finished")
                {
                    JArray goalscorers = (JArray)match["goalscorer"];
                    foreach (JObject goalscorer in goalscorers)
                    {
                        if((string)goalscorer["home_scorer"] != "")
                        {
                            EditPointsPlayer((string)goalscorer["home_scorer"], "goal");
                            if((string)goalscorer["home_assist"] !=  "")
                                EditPointsPlayer((string)goalscorer["home_assist"], "assist");
                        }
                        if ((string)goalscorer["away_scorer"] != "")
                        {
                            EditPointsPlayer((string)goalscorer["away_scorer"], "goal");
                            if ((string)goalscorer["away_assist"] != "")
                                EditPointsPlayer((string)goalscorer["away_assist"], "assist");
                        }
                    }

                    JArray cards = (JArray)match["cards"];
                    foreach (JObject card in cards)
                    {
                        if((string)card["home_fault"] != "")
                        {
                            EditPointsPlayer((string)card["home_fault"], (string)card["card"]);
                        }
                        if ((string)card["away_fault"] != "")
                        {
                            EditPointsPlayer((string)card["away_fault"], (string)card["card"]);
                        }
                    }

                    string goalsHome = (string)match["match_hometeam_score"];
                    string goalsAway = (string)match["match_awayteam_score"];

                    JArray homeLineup = (JArray)match["lineup"]["home"]["starting_lineups"];
                    foreach (JObject player in homeLineup)
                    {
                        string lineupPlayer = (string)player["lineup_player"];
                        string name = lineupPlayer.Replace(" (C)", "");
                        name = name.Replace(" (G)", "");
                        EditPointsPlayer(name, "lineup");
                        if (goalsAway == "0")
                            EditPointsPlayer(name, "cleansheet");
                    }
                    JArray awayLineup = (JArray)match["lineup"]["away"]["starting_lineups"];
                    foreach (JObject player in awayLineup)
                    {
                        string lineupPlayer = (string)player["lineup_player"];
                        string name = lineupPlayer.Replace(" (C)", "");
                        name = name.Replace(" (G)", "");
                        EditPointsPlayer(name, "lineup");
                        if (goalsHome == "0")
                            EditPointsPlayer(name, "cleansheet");
                    }

                    JArray homeSubs = (JArray)match["substitutions"]["home"];
                    foreach (JObject sub in homeSubs)
                    {
                        string substitution = (string)sub["substitution"];
                        string newString = substitution.Replace(" | ", "/");
                        string[] words = newString.Split("/");
                        string time = (string)sub["time"];
                        if (time == "1" || time == "2" || time == "3" || time == "4" || time == "5" ||
                            time == "6" || time == "7" || time == "8" || time == "9" ||
                            time[0] == '1' || time[0] == '2')
                        {
                            EditPointsPlayer(words[1], "lineup");
                            EditPointsPlayer(words[0], "notPlayed60");
                        }
                        if ((time[0] == '3' && time != "30") || time[0] == '4' || time[0] == '5')
                        {
                            EditPointsPlayer(words[1], "played");
                            EditPointsPlayer(words[0], "notPlayed60");
                        }
                        if (time[0] == '6' || time[0] == '7' || time[0] == '8' || time[0] == '9')
                        {
                            EditPointsPlayer(words[1], "played");
                        }
                    }

                    JArray awaySubs = (JArray)match["substitutions"]["away"];
                    foreach (JObject sub in awaySubs)
                    {
                        string substitution = (string)sub["substitution"];
                        string newString = substitution.Replace(" | ", "/");
                        string[] words = newString.Split("/");
                        string time = (string)sub["time"];
                        if (time == "1" || time == "2" || time == "3" || time == "4" || time == "5" ||
                            time == "6" || time == "7" || time == "8" || time == "9" ||
                            time[0] == '1' || time[0] == '2')
                        {
                            EditPointsPlayer(words[1], "lineup");
                            EditPointsPlayer(words[0], "notPlayed60");
                        }
                        if ((time[0] == '3' && time != "30") || time[0] == '4' || time[0] == '5') 
                        {
                            EditPointsPlayer(words[1], "played");
                            EditPointsPlayer(words[0], "notPlayed60");
                        }
                        if (time[0] == '6' || time[0] == '7' || time[0] == '8' || time[0] == '9')
                        {
                            EditPointsPlayer(words[1], "played");
                        }
                    }
                }
            }
        }
    }
}
