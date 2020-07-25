using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class LoginForm // créé pour le serialize du JSON dans le controller Auth
    {
        public string Login { get; set; }
        public string  Password { get; set; }
    }
}