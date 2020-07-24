using Model.Interfaces;
using Models.Client.Entities;
using Models.Client.Mappers;
using Models.Global.Entities;
using Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Models.Client.Services
{
    public class SuperHeroService : ICRUDRepository<SuperHeroClient>
    {
        private ICRUDRepository<SuperHeroGlobal> _repo;

        public SuperHeroService()
        {
            _repo = new SuperHeroRepository_api();
        }
        
        public void Create(SuperHeroClient entity)
        {
            _repo.Create(entity.ToGlobal());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<SuperHeroClient> GetAll()
        {
            return _repo.GetAll().Select(x => x.ToClient());
        }

        public SuperHeroClient GetById(int id)
        {
            return _repo.GetById(id).ToClient();
        }

        public void Update(SuperHeroClient entity)
        {
            _repo.Update(entity.ToGlobal());
        }
    }
}
