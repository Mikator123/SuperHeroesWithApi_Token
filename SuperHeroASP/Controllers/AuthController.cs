using Model.Interfaces;
using Models.Client.Entities;
using Models.Client.Services;
using SuperHeroASP.Infrastructures.Attributes;
using SuperHeroASP.Infrastructures.Sessions;
using SuperHeroASP.Models.AuthForms;
using SuperHeroASP.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SuperHeroASP.Controllers
{
    public class AuthController : Controller
    {
        private IAuthRepository<UserClient> _service;
        public AuthController()
        {
            _service = new AuthService();
        }


        [AnonymousRequired] // Session
        public ActionResult Register()
        {
            return View(); // view de la page en elle même, dépendra du formulaire adéquat
        }

        [HttpPost] // méthode de type POST qui va renvoyer les données d'un input type="submit" d'un "formulaire"
        [ValidateAntiForgeryToken] // vérifie que l'utilisateur qui a validé la page est bien celui qui a envoyé les données
        public ActionResult Register(RegisterForm user) // retour de validation de la vue avec en paramètre le type de donnée dont disposait la view 
        {
            if (ModelState.IsValid) // vérifie que les data annotation soient bien respectées dans le formulaire. (voir le modelForm)
            {
                try
                {
                    _service.Register(user.ToClient()); // mapper les données
                    return RedirectToAction("login"); // redirige vers une autre action
                }
                catch
                {
                    ViewBag.Error = "Le login est déjà existant";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserClient userClient = _service.Login(user.Login, user.Password);
                    if (userClient != null)
                    {
                        SessionManager.User = userClient;
                        return RedirectToAction("index", "SuperHeroes");
                    }
                    else
                    {
                        ViewBag.Error = "Le login / mot de passe est incorrect";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "certains champs sont incorrects";
                    return View();
                }
            }
            catch
            {
                ViewBag.Error = "Unknown Error";
                return View();
            }
        }

        [AuthRequired]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
    }
}