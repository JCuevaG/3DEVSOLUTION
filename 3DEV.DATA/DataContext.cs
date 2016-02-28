using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3DEV.MODELS;
using _3DEV.DATA.Configuration;

using System.Data.Entity;
using System.Configuration;

namespace _3DEV.DATA
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }
        public DataContext() : base(nameOrConnectionString: DataContext.ConnectionStringName) { }

        public DbSet<Product> Products { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.
                        AppSettings["ConnectionStringName"].ToString();
                }

                return "3DEVCNX";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
