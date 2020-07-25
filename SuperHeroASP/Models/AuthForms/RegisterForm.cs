using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroASP.Models.AuthForms
{
    public class RegisterForm
    {
        [Required]
        [StringLength(50, ErrorMessage = "Il faut: minimum 2 charactères et maximum 50 charactères", MinimumLength = 2)]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Il faut: minimum 2 charactères et maximum 50 charactères", MinimumLength = 2)]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "vos données ne correspondent pas à une adresse Email.")]
        [DisplayName("Email/Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{7,}$", ErrorMessage = "Le mot de passe doit contenir au minimum 7 charactères dont au moin une lettre et un chiffre.")]
        public string Password { get; set; }

        [DisplayName("Répetez votre mot de passe")]
        [Compare("Password", ErrorMessage = "Le mot de passe n'est pas identique.")] // oblige la prop à être identique au premier paramètre rentré
        public string RepeatPassword { get; set; }
    }
}