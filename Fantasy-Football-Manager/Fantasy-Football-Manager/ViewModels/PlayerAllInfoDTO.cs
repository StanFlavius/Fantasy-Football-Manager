using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.ViewModels
{
    public class PlayerAllInfoDTO
    {
        public int JucatorId { get; set; }

        [Required]
        public string NumeJucator { get; set; }

        [Required]
        public string PrenumeJucator { get; set; }

        [Required]
        public string PozitieJucator { get; set; }

        [Required]
        public string EchipaFotbal { get; set; }

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
