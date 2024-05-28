using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin_Online.Models;

namespace Magazin_Online.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

        private ApplicationContext applicationContext= new ApplicationContext();
        public ActionResult Index()
        {
            var users=applicationContext.Users.ToList();
            return View(users);
        }
    }
}