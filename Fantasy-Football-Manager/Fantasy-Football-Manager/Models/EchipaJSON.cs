using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football_Manager.Models
{
    public class EchipaJSON
    {
        public string team_key { get; set; }
        public string team_name { get; set; }
        public string team_badge { get; set; }

        public ICollection<JucatorJSON> players { get; set; }
        
        public ICollection<AntrenorJSON> coaches { get; set; }
    }
}
