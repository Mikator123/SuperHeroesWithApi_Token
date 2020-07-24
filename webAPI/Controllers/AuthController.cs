using Model.Interfaces;
using Models.Global.Entities;
using Models.Global.Repositories;
using System.Web.Http;

namespace webAPI.Controllers
{


    public class AuthController : ApiController
    {
        public IAuthRepository<UserGlobal> _repo;

        public AuthController()
        {
            _repo = new AuthRepository();
        }

        [HttpPost]
        [Route("api/Auth/Login")]
        public UserGlobal Login([FromBody] UserGlobal entity)
        {
            return _repo.Login(entity);
        }


        [HttpPost]
        [Route("api/Auth/Register")]
        public void Register([FromBody] UserGlobal entity)
        {
            _repo.Register(entity);
        }
    }
}