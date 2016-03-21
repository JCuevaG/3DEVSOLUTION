using _3DEV.DATA;
using _3DEV.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3DEV.MVC.ViewModels;

namespace _3DEV.MVC.Controllers
{
    [Authorize]
    public class ProductController : JsonController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [AllowAnonymous]
        public ActionResult Index()
        {
            //throw new Exception("New Email test Elmah");            
            return View();
        }

        [AllowAnonymous]
        public ActionResult getProducts()
        {
            var query = this._unit.Products.GetAll().OrderByDescending(x => x.Id).ToList();

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            ProductViewModel vm = new ProductViewModel();
            vm.IsNew = true;

            return View("Home",vm);
        }

        [ActionName("Edit")]
        public ActionResult Get(int id)
        {
            ProductViewModel vm = new ProductViewModel();

            vm.Product = this._unit.Products.GetById(id);

            if (vm.Product != null)
            {
                return View("Home", vm);
            }

            return View("NotFound");
        }
        protected override void Dispose(bool disposing)
        {
            this._unit.Dispose();
            base.Dispose(disposing);
        }

    }
}
