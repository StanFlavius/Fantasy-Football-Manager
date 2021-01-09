using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Fantasy_Football_Manager.Models
{
    public class User : IdentityUser
    {
        [Required]
        public int Nume { get; set; }

        [Required]
        public int Prenume { get; set; }

        public ICollection<UserLiga> Ligi { get; set; }

        public ICollection<Echipa> Echipe { get; set; }
    }
}
