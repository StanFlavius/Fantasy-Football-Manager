using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;

namespace Fantasy_Football_Manager.Data
{
    public class EchipaRepo : IEchipaRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EchipaRepo(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        public User GetUser(string userName)
        {
            var user = _applicationDbContext.Users
                            .FirstOrDefault<User>(u => u.UserName == userName);

            return user;
        }
        public int GetAvailableId()
        {
            int id = (
                        from echipa in _applicationDbContext.Echipe
                        orderby echipa.EchipaId descending
                        select echipa.EchipaId).FirstOrDefault();
            return id;
        }
        public int GetNrTotalPuncte(List<Jucator> jucatori)
        {
            int nrTotal = 0;
            foreach(Jucator jucator in jucatori)
            {
                StatisticiJucator statisticiJucator = _applicationDbContext.StatisticiJucatori.Find(jucator.StatisticiJucatorId);
                nrTotal += statisticiJucator.NrTotalPuncte;
            }

            return nrTotal;
        }

        public void AddTeam(CreateEchipa createEchipa)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = GetUser(userName);

            Echipa newTeam = new Echipa();
            newTeam.EchipaId = GetAvailableId() + 1;
            newTeam.UserId = user.Id;
            newTeam.NumeEchipa = createEchipa.NumeEchipa;
            newTeam.LigaId = createEchipa.LigaId;
            List<Jucator> jucatori = new List<Jucator>();
            Jucator portar1 = _applicationDbContext.Jucatori.Find(createEchipa.Portar1);
            Jucator portar2 = _applicationDbContext.Jucatori.Find(createEchipa.Portar2);
            Jucator fundas1 = _applicationDbContext.Jucatori.Find(createEchipa.Fundas1);
            Jucator fundas2 = _applicationDbContext.Jucatori.Find(createEchipa.Fundas2);
            Jucator fundas3 = _applicationDbContext.Jucatori.Find(createEchipa.Fundas3);
            Jucator fundas4 = _applicationDbContext.Jucatori.Find(createEchipa.Fundas4);
            Jucator fundas5 = _applicationDbContext.Jucatori.Find(createEchipa.Fundas5);
            Jucator mijlocas1 = _applicationDbContext.Jucatori.Find(createEchipa.Mijlocas1);
            Jucator mijlocas2 = _applicationDbContext.Jucatori.Find(createEchipa.Mijlocas2);
            Jucator mijlocas3 = _applicationDbContext.Jucatori.Find(createEchipa.Mijlocas3);
            Jucator mijlocas4 = _applicationDbContext.Jucatori.Find(createEchipa.Mijlocas4);
            Jucator mijlocas5 = _applicationDbContext.Jucatori.Find(createEchipa.Mijlocas5);
            Jucator atacant1 = _applicationDbContext.Jucatori.Find(createEchipa.Atacant1);
            Jucator atacant2 = _applicationDbContext.Jucatori.Find(createEchipa.Atacant2);
            Jucator atacant3 = _applicationDbContext.Jucatori.Find(createEchipa.Atacant3);
            jucatori.Add(portar1);
            jucatori.Add(portar2);
            jucatori.Add(fundas1);
            jucatori.Add(fundas2);
            jucatori.Add(fundas3);
            jucatori.Add(fundas4);
            jucatori.Add(fundas5);
            jucatori.Add(mijlocas1);
            jucatori.Add(mijlocas2);
            jucatori.Add(mijlocas3);
            jucatori.Add(mijlocas4);
            jucatori.Add(mijlocas5);
            jucatori.Add(atacant1);
            jucatori.Add(atacant2);
            jucatori.Add(atacant3);

            newTeam.NrTotalPuncte = GetNrTotalPuncte(jucatori);

            _applicationDbContext.Echipe.Add(newTeam);
            _applicationDbContext.SaveChanges();

            foreach(Jucator jucator in jucatori)
            {
                EchipaJucator echipaJucator = new EchipaJucator();
                echipaJucator.EchipaId = newTeam.EchipaId;
                echipaJucator.JucatorId = jucator.JucatorId;
                _applicationDbContext.EchipeJucatori.Add(echipaJucator);
                _applicationDbContext.SaveChanges();
            }
        }
        public List<PlayerAllInfoDTO> GetTeamsWithPlayers(string userId, int ligaId)
        {
            List<PlayerAllInfoDTO> playersList = new List<PlayerAllInfoDTO>();

            Echipa echipa = _applicationDbContext.Echipe.FirstOrDefault<Echipa>(e => e.UserId == userId && e.LigaId == ligaId);

            List<EchipaJucator> listEchipeJucatori = (
                                        from e in _applicationDbContext.EchipeJucatori
                                        where e.EchipaId == echipa.EchipaId
                                        select e
                                     ).ToList();
            
            foreach(EchipaJucator e in listEchipeJucatori)
            {
                PlayerAllInfoDTO player = new PlayerAllInfoDTO();
                Jucator jucator = _applicationDbContext.Jucatori.Find(e.JucatorId);
                player.JucatorId = jucator.JucatorId;
                player.NumeJucator = jucator.NumeJucator;
                player.PrenumeJucator = jucator.PrenumeJucator;
                player.PozitieJucator = jucator.PozitieJucator;
                player.EchipaFotbal = jucator.EchipaFotbal;
                StatisticiJucator statisticiJucator = _applicationDbContext.StatisticiJucatori.Find(jucator.JucatorId);
                player.NrGoluri = statisticiJucator.NrGoluri;
                player.NrAssists = statisticiJucator.NrAssists;
                player.NrCleansheets = statisticiJucator.NrCleansheets;
                player.NrTotalPuncte = statisticiJucator.NrTotalPuncte;

                playersList.Add(player);
            }

            return playersList;
        }

        public List<Jucator> GetJucatori(string pozitie)
        {
            List<Jucator> jucatori = (
                                        from j in _applicationDbContext.Jucatori
                                        where j.PozitieJucator == pozitie
                                        select j
                                    ).ToList();
            return jucatori;
        }

        public List<PlayerAllInfoDTO> GetPlayersByTeam(int echipaId)
        {
            List<int> jucatoriIds = (
                                       from ej in _applicationDbContext.EchipeJucatori
                                       where ej.EchipaId == echipaId
                                       select ej.JucatorId
                                  ).ToList();

            List<PlayerAllInfoDTO> players = new List<PlayerAllInfoDTO>();

            foreach(int id in jucatoriIds)
            {
                PlayerAllInfoDTO player = new PlayerAllInfoDTO();
                Jucator jucator = _applicationDbContext.Jucatori.Find(id);
                StatisticiJucator statisticiJucator = _applicationDbContext.StatisticiJucatori.Find(id);
                player.NumeJucator = jucator.NumeJucator;
                player.PrenumeJucator = jucator.PrenumeJucator;
                player.EchipaFotbal = jucator.EchipaFotbal;
                player.PozitieJucator = jucator.PozitieJucator;
                player.NrGoluri = statisticiJucator.NrGoluri;
                player.NrAssists = statisticiJucator.NrAssists;
                player.NrCleansheets = statisticiJucator.NrCleansheets;
                player.NrTotalPuncte = statisticiJucator.NrTotalPuncte;

                players.Add(player);
            }

            return players;
        }
    }
}
