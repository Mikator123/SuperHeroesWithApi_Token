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

        [HttpPost] //type de la méthode qui traverse l'api (POST)
        [Route("api/Auth/Login")] //défini la route liée a la méthode **** PS: si les méthodes sont du même type (post, put, delete, get), la route devra être différente.
        public UserGlobal Login([FromBody] LoginForm form) // récupère un formulaire adéquat en paramètre dans lequel la sérialisation du JSON pourra être injecté
        {
            UserGlobal user = _repo.Login(form.Login, form.Password); // récupération de l'utilisateur
            if (user != null)
            {
                user.Token = TokenService.Instance.EncodeToken(user); //ajout du token dans l'utilisateur
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