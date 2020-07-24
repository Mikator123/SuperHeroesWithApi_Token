using Model.Interfaces;
using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Client.Services
{
    public class SuperHeroService : ICRUDRepository<SuperHeroClient>
    {
        public void Create(SuperHeroClient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SuperHeroClient> GetAll()
        {
            throw new NotImplementedException();
        }

        public SuperHeroClient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SuperHeroClient entity)
        {
            throw new NotImplementedException();
        }
    }
}
