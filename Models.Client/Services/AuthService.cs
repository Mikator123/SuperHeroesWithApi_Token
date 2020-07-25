using Model.Interfaces;
using Models.Client.Entities;
using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Models.Global.Repositories;
using Models.Client.Mappers;

namespace Models.Client.Services
{
    public class AuthService : IAuthRepository<UserClient>
    {
        private IAuthRepository<UserGlobal> _repo; // utilisation de l'interface pour plus de flexibilité dans le ctor
        public AuthService()
        {
            _repo = new AuthRepository_api();
        }
        public UserClient Login(string login, string password)
        {
            return _repo.Login(login, password).ToClient(); // mappers nécessaire pour transferer d'un modèle à un autre.
        }

        public void Register(UserClient entity)
        {
            _repo.Register(entity.ToGlobal());
        }
    }
}
