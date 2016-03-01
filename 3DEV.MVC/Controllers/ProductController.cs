using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _3DEV.MVC.Models;
using _3DEV.DATA;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace _3DEV.MVC.Controllers
{
    public class ProductController : Controller
    {

        ApplicationUnit unit = new ApplicationUnit();



        // GET: Product
        public ActionResult Index()
        {
            var lista = unit.Products.GetAll().ToArray();

            
            var serializer = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            //var jo = Newtonsoft.Json.Linq.JObject.FromObject(lista, serializer);
            var jo = JsonConvert.SerializeObject(lista,Formatting.None, serializer);


            return View("Index","",jo);

        }
    }
}