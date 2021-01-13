using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;

namespace Fantasy_Football_Manager.Data
{
    public interface IEchipaRepo
    {
        public void SaveChanges();
        public User GetUser(string userName);
        public int GetAvailableId();
        public int GetNrTotalPuncte(List<Jucator> jucatori);
        public void AddTeam(CreateEchipa createEchipa);
        public List<PlayerAllInfoDTO> GetTeamsWithPlayers(string userId, int ligaId);
        public List<Jucator> GetJucatori(string pozitie);
        public List<PlayerAllInfoDTO> GetPlayersByTeam(int echipaId);
    }
}
