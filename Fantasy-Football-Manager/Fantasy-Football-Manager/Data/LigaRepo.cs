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

        public LigaRepo (ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
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

        }

        public List<LeagueStats> GetLeaguesNotCurrUser()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = GetUser(userName);

            //List<Liga> ligi = new List<Liga>();
            List<LeagueStats> leagueStats = new List<LeagueStats>();

            List<UserLiga> usersLigi = _applicationDbContext.UsersLigi.ToList();

            foreach(UserLiga userLiga in usersLigi)
            {
                if (userLiga.UserId != user.Id)
                {
                    Liga liga = _applicationDbContext.Ligi.FirstOrDefault(l => l.LigaId == userLiga.LigaId);
                    LeagueStats leagueS = new LeagueStats();
                    leagueS.LigaId = liga.LigaId;
                    leagueS.NrCurrUseri = 
                    ligi.Add(liga);
                }
            }

            return ligi;
        }

        public List<Liga> GetLeaguesWithCurrUser()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = GetUser(userName);

            List<Liga> ligi = new List<Liga>();
            List<UserLiga> usersLigi = _applicationDbContext.UsersLigi.ToList();

            foreach (UserLiga userLiga in usersLigi)
            {
                if (userLiga.UserId == user.Id)
                {
                    Liga liga = _applicationDbContext.Ligi.FirstOrDefault(l => l.LigaId == userLiga.LigaId);
                    ligi.Add(liga);
                }
            }

            return ligi;
        }
    }
}
