using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.Models
{
    public class StatisticiJucator
    {
        [Key]
        [Required]
        public int StatisticiJucatorId { get; set; }

        [Required]
        public int NrGoluri { get; set; }

        [Required]
        public int NrAssists { get; set; }

        [Required]
        public int NrCleansheets { get; set; }

        [Required]
        public int NrTotalPuncte { get; set; }
    }
}
