using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin_Online.Models;

namespace Magazin_Online.Controllers
{
    public class OfertePretNegociabilController : Controller
    {
        private ApplicationContext applicationContext = new ApplicationContext();
        // GET: OfertePretNegociabil
        public ActionResult Index()
        {
            var oferte = applicationContext.OfertePretNegociabil.Include("Produs").Include("Cumparator").ToList();
            return View(oferte);
        }

        public ActionResult Details(int id)
        {
            var oferta = applicationContext.OfertePretNegociabil.Include("Produs").Include("Cumparator").FirstOrDefault(o => o.OfertaId == id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        public ActionResult Create()
        {
            ViewBag.ProdusId = new SelectList(applicationContext.Produse, "ProdusId", "Denumire");
            ViewBag.CumparatorId = new SelectList(applicationContext.Users, "UserId", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfertaId,ProdusId,CumparatorId,Oferta,DataOferta,Stare")] OfertePretNegociabil oferta)
        {
            if (ModelState.IsValid)
            {
                applicationContext.OfertePretNegociabil.Add(oferta);
                applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdusId = new SelectList(applicationContext.Produse, "ProdusId", "Denumire", oferta.ProdusId);
            ViewBag.CumparatorId = new SelectList(applicationContext.Users, "UserId", "Email", oferta.CumparatorId);
            return View(oferta);
        }

        public ActionResult Edit(int id)
        {
            var oferta = applicationContext.OfertePretNegociabil.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdusId = new SelectList(applicationContext.Produse, "ProdusId", "Denumire", oferta.ProdusId);
            ViewBag.CumparatorId = new SelectList(applicationContext.Users, "UserId", "Email", oferta.CumparatorId);
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfertaId,ProdusId,CumparatorId,Oferta,DataOferta,Stare")] OfertePretNegociabil oferta)
        {
            if (ModelState.IsValid)
            {
                applicationContext.Entry(oferta).State = System.Data.Entity.EntityState.Modified;
                applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdusId = new SelectList(applicationContext.Produse, "ProdusId", "Denumire", oferta.ProdusId);
            ViewBag.CumparatorId = new SelectList(applicationContext.Users, "UserId", "Email", oferta.CumparatorId);
            return View(oferta);
        }

        public ActionResult Delete(int id)
        {
            var oferta = applicationContext.OfertePretNegociabil.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var oferta = applicationContext.OfertePretNegociabil.Find(id);
            applicationContext.OfertePretNegociabil.Remove(oferta);
            applicationContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}