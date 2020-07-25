using Models.Client.Entities;
using SuperHeroASP.Models.AuthForms;
using SuperHeroASP.Models.SuperHeroForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroASP.Models.Mappers
{
    public static class Mappers
    {
        public static UserClient ToClient(this RegisterForm user)
        {
            return new UserClient()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Login = user.Login,
                Password = user.Password
            };
        }
        public static SuperHeroClient ToClient(this CreateForm entity)
        {
            return new SuperHeroClient()
            {
                Name = entity.Name,
                Charism = entity.Charism,
                Intelligence = entity.Intelligence,
                Strenght = entity.Strenght,
                Stamina = entity.Stamina,
            };
        }
        public static SuperHeroClient ToClient(this UpdateForm entity)
        {
            return new SuperHeroClient()
            {
                Id = entity.Id,
                Name = entity.Name,
                Charism = entity.Charism,
                Intelligence = entity.Intelligence,
                Strenght = entity.Strenght,
                Stamina = entity.Stamina,
            };
        }
        public static UpdateForm ToUpdateForm(this SuperHeroClient entity)
        {
            return new UpdateForm()
            {
                Id = entity.Id,
                Name = entity.Name,
                Charism = entity.Charism,
                Intelligence = entity.Intelligence,
                Strenght = entity.Strenght,
                Stamina = entity.Stamina,
            };
        }
    }
}