using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _3DEV.MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace _3DEV.MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var lista = new[]{
                new ProductoModel{
                    Id = 1,
                    ProductName = "easdas",
                    Price=2,
                    Quantity=10
                }
            };

            
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