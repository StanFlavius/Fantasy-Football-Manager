using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.ViewModels
{
    public class LeagueStats
    {
        [Required]
        [Key]
        public int LigaId { get; set; }

        [Required]
        public string NumeLiga { get; set; }

        [Required]
        public int NrMaxUseri { get; set; }

        [Required]
        public int NrCurrUseri { get; set; }
    }
}
