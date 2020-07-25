using Models.Client.Entities;
using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Models.Client.Mappers
{
    public static class Mappers
    {
        public static UserClient ToClient(this UserGlobal user) // retourne un UserClient à partir d'une méthode d'extension d'un UserGlobal -> (this UserGlobal user)
        {
            return new UserClient()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Login = user.Login,
                Password = user.Password,
                Token = user.Token,
                
            };
        }
        public static UserGlobal ToGlobal(this UserClient user)
        {
            return new UserGlobal()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Login = user.Login,
                Password = user.Password,
                Token = user.Token
                
            };
        }
        public static SuperHeroClient ToClient(this SuperHeroGlobal SH)
        {
            return new SuperHeroClient()
            {
                Id = SH.Id,
                Name = SH.Name,
                Strenght = SH.Strenght,
                Stamina = SH.Stamina,
                Intelligence = SH.Intelligence,
                Charism = SH.Charism

            };
        }
        public static SuperHeroGlobal ToGlobal(this SuperHeroClient SH)
        {
            return new SuperHeroGlobal()
            {
                Id = SH.Id,
                Name = SH.Name,
                Strenght = SH.Strenght,
                Stamina = SH.Stamina,
                Intelligence = SH.Intelligence,
                Charism = SH.Charism

            };
        }
    }
}
