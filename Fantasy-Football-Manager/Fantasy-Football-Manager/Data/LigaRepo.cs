using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;

namespace Fantasy_Football_Manager.Data
{
    public class LigaRepo : ILigaRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEchipaRepo _echipaRepo;

        public LigaRepo (ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, IEchipaRepo echipaRepo)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
            _echipaRepo = echipaRepo;
        }

        public bool SaveChanges()
        {
            return (_applicationDbContext.SaveChanges() >= 0);
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
                        from liga in _applicationDbContext.Ligi
                        orderby liga.LigaId descending
                        select liga.LigaId).FirstOrDefault();
            return id;
        }

        public void AddLeague(Liga liga)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = GetUser(userName);

            int id = GetAvailableId();

            liga.LigaId = id + 1;
            _applicationDbContext.Ligi.Add(liga);
            _applicationDbContext.SaveChanges();

            UserLiga userLiga = new UserLiga();
            userLiga.LigaId = liga.LigaId;
            userLiga.UserId = user.Id;
            _applicationDbContext.UsersLigi.Add(userLiga);
            _applicationDbContext.SaveChanges();
        }

        public int GetNrUsers(int ligaId)
        {
            var userLigi = _applicationDbContext.UsersLigi.Where(x => x.LigaId == ligaId);
            return userLigi.ToList().Count;
        }

        public List<LeagueStats> GetLeaguesNotCurrUser()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            
            User user = GetUser(userName);
            Console.WriteLine(user.Id);
            List<LeagueStats> leagueStats = new List<LeagueStats>();

            List<Liga> toateLigi = _applicationDbContext.Ligi.ToList();
            List<int> cuLigiIds = new List<int>();

            List<UserLiga> usersLigi = _applicationDbContext.UsersLigi.ToList();


            foreach (UserLiga userLiga in usersLigi)
            {
                if(userLiga.UserId == user.Id)
                {
                    cuLigiIds.Add(userLiga.LigaId);
                }
            }

            foreach(Liga liga1 in toateLigi)
            {
                int currId = liga1.LigaId;
                bool p = true;
                foreach(int ligaId2 in cuLigiIds)
                {
                    if (currId == ligaId2)
                    {
                        p = false;
                    }
                }

                if (p == true)
                {
                    Liga liga = _applicationDbContext.Ligi.FirstOrDefault(l => l.LigaId == currId);
                    LeagueStats leagueS = new LeagueStats();
                    leagueS.LigaId = liga.LigaId;
                    leagueS.NumeLiga = liga.NumeLiga;
                    leagueS.NrCurrUseri = GetNrUsers(liga.LigaId);
                    leagueS.NrMaxUseri = liga.NrMaxUseri;
                    if(GetNrUsers(liga.LigaId) < liga.NrMaxUseri)
                        leagueStats.Add(leagueS);
                }

            }

            return leagueStats;
        }

        public List<LeagueStats> GetLeaguesWithCurrUser()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            User user = GetUser(userName);
            Console.WriteLine(user.Id);
            List<LeagueStats> leagueStats = new List<LeagueStats>();

            List<Liga> toateLigi = _applicationDbContext.Ligi.ToList();
            List<int> cuLigiIds = new List<int>();

            List<UserLiga> usersLigi = _applicationDbContext.UsersLigi.ToList();


            foreach (UserLiga userLiga in usersLigi)
            {
                if (userLiga.UserId == user.Id)
                {
                    cuLigiIds.Add(userLiga.LigaId);
                }
            }

            foreach (Liga liga1 in toateLigi)
            {
                int currId = liga1.LigaId;
                bool p = true;
                foreach (int ligaId2 in cuLigiIds)
                {
                    if (currId == ligaId2)
                    {
                        p = false;
                    }
                }

                if (p == false)
                {
                    Liga liga = _applicationDbContext.Ligi.FirstOrDefault(l => l.LigaId == currId);
                    LeagueStats leagueS = new LeagueStats();
                    leagueS.LigaId = liga.LigaId;
                    leagueS.NumeLiga = liga.NumeLiga;
                    leagueS.NrCurrUseri = GetNrUsers(liga.LigaId);
                    leagueS.NrMaxUseri = liga.NrMaxUseri;
                    leagueStats.Add(leagueS);
                }

            }

            return leagueStats;
        }

        public void AddNewUser(int IdLiga)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = GetUser(userName);

            _applicationDbContext.UsersLigi.Add(new UserLiga { UserId = user.Id, LigaId = IdLiga });
            _applicationDbContext.SaveChanges();
        }

        public int GetNrTotalPuncte(List<int> jucatoriIds)
        {
            int nrTotal = 0;
            foreach (int jucatorId in jucatoriIds)
            {
                StatisticiJucator statisticiJucator = _applicationDbContext.StatisticiJucatori.Find(jucatorId);
                nrTotal += statisticiJucator.NrTotalPuncte;
            }

            return nrTotal;
        }

        public List<TeamLeaderboard> GetLeaderboard(int idLiga)
        {
            var echipeLiga = (
                                           from e in _applicationDbContext.Echipe
                                           where e.LigaId == idLiga
                                           select e
                                      );

            List<TeamLeaderboard> teams = new List<TeamLeaderboard>();

            foreach(Echipa e in echipeLiga.ToList())
            {
                TeamLeaderboard team = new TeamLeaderboard();
                team.EchipaId = e.EchipaId;
                team.LigaId = idLiga;
                team.NumeEchipa = e.NumeEchipa;
                team.NumeUser = _applicationDbContext.Users.Find(e.UserId).UserName;
                List<int> jucatoriIds = (
                                            from ej in _applicationDbContext.EchipeJucatori
                                            where ej.EchipaId == e.EchipaId
                                            select ej.JucatorId
                                        ).ToList();

                team.NrTotalPuncte = GetNrTotalPuncte(jucatoriIds);

                teams.Add(team);
            }

            teams = teams.
                    Where(x => x != null)
                    .OrderByDescending(x => x.NrTotalPuncte)
                    .ToList();

            return teams;
        }
    }
}
