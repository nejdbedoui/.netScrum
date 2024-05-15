using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITacheService itacheservice;
        private readonly ISprintService isprintservice;
        private readonly IMembreService imembreservice;

        public HomeController(ITacheService tacheservice, ISprintService sprintservice, IMembreService membreservice)
        {
            this.itacheservice = tacheservice;
            this.isprintservice = sprintservice;
            this.imembreservice = membreservice;
        }
        // GET: TacheControlleur
        public ActionResult Index()
        {

            return View(itacheservice.GetListOuverte());
        }
       

        // GET: HomeController/Details/5
        public ActionResult Details(int SprintKey ,string MembreKey ,string Titre )
        {
            var tache = itacheservice.GetAll().FirstOrDefault(t => t.SprintKey == SprintKey && t.MembreKey == MembreKey && t.Titre == Titre);
            return View(tache);
        }

        public ActionResult DetailsMembre(string id)
        {
            return View(imembreservice.GetById(id));
        }
        // GET: HomeController/Create
        public ActionResult Create()
        {
            ViewBag.Etat = new SelectList(Enum.GetNames(typeof(EtatTache)));
            ViewBag.MembreKey = new SelectList(imembreservice.GetAll().ToList(), "Matricule", "Nom");
            ViewBag.SprintKey = new SelectList(isprintservice.GetAll().ToList(), "Id", "Id");
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tache tache)
        {
            try
            {
                itacheservice.Add(tache);
                itacheservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
