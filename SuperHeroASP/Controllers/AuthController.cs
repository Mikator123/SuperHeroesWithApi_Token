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

        //GET
        [AnonymousRequired]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterForm user)
        {
            try
            {
                _service.Register(user.ToClient());
                return RedirectToAction("login");
            }
            catch
            {
                ViewBag.Error = "Le login est déjà existant";
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
                if(ModelState.IsValid)
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
            return RedirectToAction("index","Home");
        }
    }
}