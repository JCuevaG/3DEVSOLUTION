using _3DEV.MODELS;

namespace _3DEV.MVC.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        public Product Product { get; set; }
        public bool IsNew { get; set; }

        public ProductViewModel()
        {
            this.Product = new Product();
        }
    }
}