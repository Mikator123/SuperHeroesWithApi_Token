﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroASP.Models.SuperHeroForms
{


    public class CreateForm
    {
        [Required]
        [StringLength(50, ErrorMessage = "Il faut: minimum 2 charactères et maximum 50 charactères", MinimumLength = 2)] // longueur de la string
        [DisplayName("Nom du Super Hero")]
        public string Name { get; set; }

        [Required]
        [Range(1.0, 20.0, ErrorMessage = "la valeur de la force doit être définie entre 1 & 20")] // la range de l'int
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