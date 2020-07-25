using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroASP.Models.SuperHeroForms
{
    public class UpdateForm
    {
        [Required]
        [StringLength(50, ErrorMessage = "Il faut: minimum 2 charactères et maximum 50 charactères", MinimumLength = 2)]
        [DisplayName("Nom du Super Hero")]
        public string Name { get; set; }

        [Required]
        [Range(1.0, 20.0, ErrorMessage = "la valeur de la force doit être définie entre 1 & 20")]
        [DisplayName("Sa force")]
        public int Strenght { get; set; }

        [Required]
        [Range(1.0, 20.0, ErrorMessage = "la valeur de la force doit être définie entre 1 & 20")]
        [DisplayName("Son intelligence")]
        public int Intelligence { get; set; }

        [Required]
        [Range(1.0, 20.0, ErrorMessage = "la valeur de la force doit être définie entre 1 & 20")]
        [DisplayName("Son endurance")]
        public int Stamina { get; set; }

        [Required]
        [Range(1.0, 20.0, ErrorMessage = "la valeur de la force doit être définie entre 1 & 20")]
        [DisplayName("Son charisme")]
        public int Charism { get; set; }
    }
}