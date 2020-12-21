using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebStore.Models;

namespace WebStore.Controllers
{
    public class ProductController : Controller
    {
        ModelWebStore db = new ModelWebStore();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail(int proid)
        {
            PRODUCT pro = db.PRODUCTs.Where(p => p.ID_Product == proid).SingleOrDefault();
            return View(pro);
        }

        [ChildActionOnly]
        public ActionResult SaleProduct()
        {
            List<PRODUCT> salelist = (from s in db.PRODUCTs where s.Sale == 1 select s).ToList();
            return PartialView(salelist);
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            List<TYPE_PRODUCT> listtype = db.TYPE_PRODUCT.ToList();
            return PartialView(listtype);
        }

        public ActionResult CatList(int ID_Category)
        {
            List<PRODUCT> productcategorylist = (from p in db.PRODUCTs where p.ID_ProductType == ID_Category select p).ToList();
            return View(productcategorylist);
        }
    }
}