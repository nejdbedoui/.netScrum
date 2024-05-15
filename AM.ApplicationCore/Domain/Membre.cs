using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Membre
    {
        [Key]
        public string Matricule { get; set; }
        [EmailAddress(ErrorMessage ="mail required")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public virtual List<Tache> Taches { get; set; }
    }
}
