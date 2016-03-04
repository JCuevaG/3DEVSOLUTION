using _3DEV.MODELS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEV.DATA
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
