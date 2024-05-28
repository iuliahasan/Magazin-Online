using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin_Online.Models;

namespace Magazin_Online.Controllers
{
    public class VanzatoriController : Controller
    {
        private ApplicationContext applicationContext = new ApplicationContext();
        // GET: Vanzatori
        public ActionResult Index()
        {
            var vanzatori = applicationContext.Vanzatori.Include("User").ToList();
            return View(vanzatori);
        }

        public ActionResult Details(int id)
        {
            var vanzator = applicationContext.Vanzatori.Include("User").FirstOrDefault(v => v.VanzatorId == id);

            if (vanzator == null)
            {
                return HttpNotFound();
            }
            return View(vanzator);
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(applicationContext.Users, "UserId", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VanzatorId, UserId, AprobareCont")] Vanzator vanzator)
        {
            if (ModelState.IsValid)
            {
                applicationContext.Vanzatori.Add(vanzator);
                applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(applicationContext.Users, "UserId", "Email", vanzator.UserId);
            return View(vanzator);
        }

        public ActionResult Edit(int id)
        {
            var vanzator = applicationContext.Vanzatori.Find(id);

            if (vanzator == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(applicationContext.Users, "UserId", "Email", vanzator.UserId);
            return View(vanzator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vanzator,UserId,AprobareCont")] Vanzator vanzator)
        {
            if (ModelState.IsValid)
            {
                applicationContext.Entry(vanzator).State = System.Data.Entity.EntityState.Modified;
                applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(applicationContext.Users, "UserId", "Email", vanzator.UserId);
            return View(vanzator);
        }

        public ActionResult Delete(int id)
        {
            var vanzator = applicationContext.Vanzatori.Find(id);

            if (vanzator == null)
            {
                return HttpNotFound();
            }
            return View(vanzator);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vanzator = applicationContext.Vanzatori.Find(id);
            applicationContext.Vanzatori.Remove(vanzator);
            applicationContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}