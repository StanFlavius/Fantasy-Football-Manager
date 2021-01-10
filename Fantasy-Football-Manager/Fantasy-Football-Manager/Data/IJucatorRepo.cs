using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;

namespace Fantasy_Football_Manager.Data
{
    public interface IJucatorRepo
    {
        public bool SaveChanges();

        public Task<List<Jucator>> GetAllPlayersAsync();

        public int GetPointsByParams(string position, string eventMatch);

        public Jucator GetJucator(string name, string surname);

        public void EditPointsPlayer(string name, string data);

        public Task UpdatePlayers(string startDate, string endDate);
    }
}