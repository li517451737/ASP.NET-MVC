using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Mvc.Web.Models;

namespace TP.Mvc.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            var i = 0;
            ViewBag.Count = 1 / i;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToRoute("Default");
            }

            return View(model);
        }
    }
}