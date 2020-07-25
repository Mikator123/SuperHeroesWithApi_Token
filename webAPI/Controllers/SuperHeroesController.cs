using Model.Interfaces;
using Models.Global.Entities;
using Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Infrastructure;

namespace webAPI.Controllers
{
    [AuthRequired]  // ce controller nécissite un TOKEN valide pour y accéder
    public class SuperHeroesController : ApiController
    {
        private ICRUDRepository<SuperHeroGlobal> _repo;
        // GET api/values
        public SuperHeroesController()
        {
            _repo = new SuperHeroRepository();
        }


        [Route("api/SuperHeroes")]
        public IEnumerable<SuperHeroGlobal> Get()
        {
            return _repo.GetAll();
        }


        [Route("api/SuperHeroes/{id}")]
        public SuperHeroGlobal Get(int id)
        {
            return _repo.GetById(id);
        }


        [Route("api/SuperHeroes")]
        public void Post([FromBody] SuperHeroGlobal entity)
        {
            _repo.Create(entity);
        }


        [Route("api/SuperHeroes/{id}")]
        public void Put([FromBody] SuperHeroGlobal entity)
        {
            _repo.Update(entity);
        }


        [Route("api/SuperHeroes/{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
