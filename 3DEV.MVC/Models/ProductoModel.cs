using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3DEV.MVC.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}