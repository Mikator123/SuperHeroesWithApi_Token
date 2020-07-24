using Model.Interfaces;
using Models.Global.Entities;
using Models.Global.Repositories;
using System.Web.Http;
using webAPI.Models;
using webAPI.Models.Services;

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
        public UserGlobal Login([FromBody] LoginForm form)
        {
            UserGlobal user = _repo.Login(form.Login, form.Password);
            if (user != null)
            {
                user.Token = TokenService.Instance.EncodeToken(user);
            }
            return user;
        }


        [HttpPost]
        [Route("api/Auth/Register")]
        public void Register([FromBody] UserGlobal entity)
        {
            _repo.Register(entity);
        }
    }
}