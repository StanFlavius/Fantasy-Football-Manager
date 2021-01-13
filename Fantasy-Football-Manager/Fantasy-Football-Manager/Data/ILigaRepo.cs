using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;

namespace Fantasy_Football_Manager.Data
{
    public interface ILigaRepo
    {
        public bool SaveChanges();
        public User GetUser(string userName);
        public int GetAvailableId();
        public void AddLeague(Liga liga);
        public List<LeagueStats> GetLeaguesNotCurrUser();
        public List<LeagueStats> GetLeaguesWithCurrUser();
        public int GetNrUsers(int ligaId);
        public void AddNewUser(int IdLiga);
    }
}
