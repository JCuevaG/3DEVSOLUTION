using _3DEV.MODELS;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace _3DEV.MVC.ViewModels
{
    public class ProductsListViewModel : ViewModelBase
    {
        public IList<Product> Products { get; set; }        
    }
}