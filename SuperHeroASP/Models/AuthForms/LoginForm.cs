using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroASP.Models.AuthForms
{
    public class LoginForm
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "vos données ne correspondent pas à une adresse Email.")]
        [DisplayName("Email/Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{7,}$", ErrorMessage = "Le mot de passe doit contenir au minimum 7 charactères dont au moin une lettre et un chiffre.")]
        public string Password { get; set; }
    }
}