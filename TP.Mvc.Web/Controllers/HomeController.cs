using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            throw new Exception("出错啦");

            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult GetPersons()
        {
            List<dynamic> list = new List<dynamic>();
            list.Add(new
            {
                Id=1,
                Name="哇哈哈",
                Age=12
            });
            list.Add(new
            {
                Id = 1,
                Name = "李四",
                Age = 32
            });
            list.Add(new
            {
                Id = 1,
                Name = "王二",
                Age = 22
            });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}