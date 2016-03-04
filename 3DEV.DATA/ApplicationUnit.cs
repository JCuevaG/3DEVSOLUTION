using _3DEV.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEV.DATA
{
    public class ApplicationUnit : IDisposable
    {
        private DataContext _context = new DataContext();
        private IRepository<Product> _products = null;
        private IRepository<User> _users = null;

        public IRepository<Product> Products
        {
            get
            {
                if (this._products == null)
                {
                    this._products = new GenericRepository<Product>(this._context);
                }

                return this._products;
            }
        }

        public IRepository<User> Users {
            get
            {
                if (this._users == null)
                {
                    this._users = new GenericRepository<User>(this._context);
                }

                return this._users;
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
