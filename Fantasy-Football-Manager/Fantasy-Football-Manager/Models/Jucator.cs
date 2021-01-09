using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.Models
{
    public class Jucator
    {
        [Key]
        [Required]
        public int JucatorId { get; set; }

        [Required]
        public string NumeJucator { get; set; }

        [Required]
        public string PrenumeJucator { get; set; }

        [Required]
        public string PozitieJucator { get; set; }

        [Required]
        public string EchipaFotbal { get; set; }

        public int StatisticiJucatorId { get; set; }
        public StatisticiJucator StatisticiJucator { get; set; }

        public ICollection<EchipaJucator> Echipe { get; set; }
    }
}
