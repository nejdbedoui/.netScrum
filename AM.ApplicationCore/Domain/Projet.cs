using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Projet
    {
        [Key]
        public string Code { get; set; }
        [Required(ErrorMessage ="required")]
        public string Titre { get; set; }
        public string Description { get; set; }
        [ForeignKey("SprintFk")]
        public virtual Sprint Sprint { get; set; }
        public int SprintFk { get; set; }
    }
}
