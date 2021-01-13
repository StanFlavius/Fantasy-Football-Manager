using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football_Manager.ViewModels
{
    public class TeamLeaderboard
    {
        public int EchipaId { get; set; }
        public string NumeEchipa { get; set; }
        public int LigaId { get; set; }
        public string NumeUser { get; set; }
        public int NrTotalPuncte { get; set; }
    }
}
