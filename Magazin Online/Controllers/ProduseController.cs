using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin_Online.Models;

namespace Magazin_Online.Controllers
{
    public class ProduseController : Controller
    {
        private ApplicationContext applicationContext = new ApplicationContext();
        // GET: Produse
        public ActionResult Index()
        {
            var produse = applicationContext.Produse.Include("Vanzatori").ToList();
            return View(produse);
        }

        public ActionResult Details(int id)
        {
            var produs = applicationContext.Produse.Include("Vanzator").FirstOrDefault(p => p.ProdusId == id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        public ActionResult Create()
        {
            ViewBag.VanzatorId = new SelectList(applicationContext.Vanzatori, "VanzatorId", "User.Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdusId,Denumire,Pret,Descriere,VanzatorId")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                applicationContext.Produse.Add(produs);
                applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VanzatorId = new SelectList(applicationContext.Vanzatori, "VanzatorId", "User.Email", produs.VanzatorId);
            return View(produs);
        }

        public ActionResult Edit(int id)
        {
            var produs = applicationContext.Produse.Find(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            ViewBag.VanzatorId = new SelectList(applicationContext.Vanzatori, "VanzatorId", "User.Email", produs.VanzatorId);
            return View(produs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdusId,Denumire,Pret,Descriere,VanzatorId")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                applicationContext.Entry(produs).State = System.Data.Entity.EntityState.Modified;
                applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VanzatorId = new SelectList(applicationContext.Vanzatori, "VanzatorId", "User.Email", produs.VanzatorId);
            return View(produs);
        }

        public ActionResult Delete(int id)
        {
            var produs = applicationContext.Produse.Find(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produs = applicationContext.Produse.Find(id);
            applicationContext.Produse.Remove(produs);
            applicationContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}