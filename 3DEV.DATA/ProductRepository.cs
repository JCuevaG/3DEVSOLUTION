using _3DEV.MODELS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEV.DATA
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
