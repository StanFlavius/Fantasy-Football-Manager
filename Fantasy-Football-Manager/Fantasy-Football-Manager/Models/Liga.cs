using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.Models
{
    public class Liga
    {
        [Required]
        [Key]
        public int LigaId { get; set; }
        
        [Required]
        public string NumeLiga { get; set; }

        [Required]
        public int NrMaxUseri { get; set; }

        public ICollection<UserLiga> Users { get; set; }
        
        public ICollection<Echipa> Echipe { get; set; }
    }
}
