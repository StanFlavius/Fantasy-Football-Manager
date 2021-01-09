using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Newtonsoft.Json;

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
    }
}
