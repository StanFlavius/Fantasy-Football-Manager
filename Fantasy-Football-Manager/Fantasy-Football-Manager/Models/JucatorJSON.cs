using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football_Manager.Models
{
    public class JucatorJSON
    {
        public long player_key { get; set; }
        public string player_name { get; set; }
        public string player_number { get; set; }
        public string player_country { get; set; }
        public string player_type { get; set; }
        public string player_age { get; set; }
        public string player_match_played { get; set; }
        public string player_goals { get; set; }
        public string player_yellow_cards { get; set; }
        public string player_red_cards { get; set; }


    }
}
