using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fantasy_Football_Manager.Models
{
    public class UserLiga
    {
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public User User { get; set; }

        [Required]
        public int LigaId { get; set; }

        [Required]
        public Liga Liga { get; set; }
    }
}
