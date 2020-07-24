using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Global.Entities
{
    public class UserGlobal
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
