using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;

namespace Fantasy_Football_Manager.Data
{
    public interface ILigaRepo
    {
        public bool SaveChanges();
        public User GetUser(string userName);
        public int GetAvailableId();
        public void AddLeague(Liga liga);
        public List<Liga> GetLeaguesNotCurrUser();
        public List<Liga> GetLeaguesWithCurrUser();
        public int GetNrUsers();
    }
}
