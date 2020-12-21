using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebStore.Models;


namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        ModelWebStore db = new ModelWebStore();
        public ActionResult Index()
        {
            List<PRODUCT> product = db.PRODUCTs.ToList();
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}