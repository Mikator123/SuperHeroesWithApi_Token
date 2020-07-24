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
        private IAuthRepository<UserGlobal> _repo;
        public AuthService()
        {
            _repo = new AuthRepository_api();
        }
        public UserClient Login(string login, string password)
        {
            return _repo.Login(login, password).ToClient();
        }

        public void Register(UserClient entity)
        {
            _repo.Register(entity.ToGlobal());
        }
    }
}
