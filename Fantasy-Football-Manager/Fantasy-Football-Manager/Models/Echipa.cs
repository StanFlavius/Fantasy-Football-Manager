using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.Models
{
    public class Echipa
    {
        [Key]
        [Required]
        public int EchipaId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string NumeEchipa { get; set; }

        public int NrTotalPuncte { get; set; }

        public int LigaId { get; set; }
        public Liga Liga { get; set; }

        public ICollection<EchipaJucator> Jucatori { get; set; }
    }
}
