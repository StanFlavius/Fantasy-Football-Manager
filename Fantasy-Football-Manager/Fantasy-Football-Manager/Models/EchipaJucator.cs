using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.Models
{
    public class EchipaJucator
    {
        [Required]
        public int EchipaId { get; set; }

        [Required]
        public Echipa Echipa { get; set; }

        [Required]
        public int JucatorId { get; set; }

        [Required]
        public Jucator Jucator { get; set; }

    }
}
