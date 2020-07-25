using Model.Interfaces;
using Models.Client.Entities;
using Models.Client.Services;
using SuperHeroASP.Infrastructures.Attributes;
using SuperHeroASP.Infrastructures.Sessions;
using SuperHeroASP.Models.Mappers;
using SuperHeroASP.Models.SuperHeroForms;
using System.Web.Mvc;

namespace SuperHeroASP.Controllers
{
    [AuthRequired]
    public class SuperHeroesController : Controller
    {
        private ICRUDRepository<SuperHeroClient> _service;
        private string _token;

        public SuperHeroesController()
        {
            _token = SessionManager.User.Token;
            _service = new SuperHeroService(_token); // ????
        }
        

        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id));
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateForm entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Create(entity.ToClient());
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                ViewBag.Error = "Le nom est déjà répertorié";
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id).ToUpdateForm());
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateForm entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Update(entity.ToClient());
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                ViewBag.Error = "Le nom est déjà répertorié";
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(SuperHeroClient entity)
        {
            try
            {
                _service.Delete(entity.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
