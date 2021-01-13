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
        public void AddTeam(string numeEchipa, List<Jucator> jucatori, int ligaId)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = GetUser(userName);

            Echipa newTeam = new Echipa();
            newTeam.EchipaId = GetAvailableId() + 1;
            newTeam.UserId = user.Id;
            newTeam.NumeEchipa = numeEchipa;
            newTeam.LigaId = ligaId;
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
    }
}
