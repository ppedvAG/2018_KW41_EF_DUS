using ppedv.ElenasUwe.Logic;
using ppedv.ElenasUwe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.ElenasUwe.UI.Web.Controllers
{
    public class ProduktController : Controller
    {
        Core core = new Core();

        // GET: Produkt
        public ActionResult Index()
        {
            return View(core.UnitOfWork.ProduktRepository.GetAll());
        }

        // GET: Produkt/Details/5
        public ActionResult Details(int id)
        {

            return View(core.UnitOfWork.ProduktRepository.GetById(id));
        }

        // GET: Produkt/Create
        public ActionResult Create()
        {
            return View(new Produkt() { Preis = 6m, Name = "NEU" });
        }

        // POST: Produkt/Create
        [HttpPost]
        public ActionResult Create(Produkt prod)
        {
            try
            {
                core.UnitOfWork.ProduktRepository.Add(prod);
                core.UnitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produkt/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.UnitOfWork.ProduktRepository.GetById(id));
        }

        // POST: Produkt/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produkt prod)
        {
            try
            {
                // TODO: Add update logic here
                core.UnitOfWork.ProduktRepository.Update(prod);
                core.UnitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produkt/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UnitOfWork.ProduktRepository.GetById(id));
        }

        // POST: Produkt/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produkt prod)
        {
            try
            {
                // TODO: Add delete logic here
                var loaded = core.UnitOfWork.ProduktRepository.GetById(id);
                if (loaded != null)
                {
                    core.UnitOfWork.ProduktRepository.Delete(loaded);
                    core.UnitOfWork.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
