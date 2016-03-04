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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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
            modelBuilder.Configurations.Add(new UserConfiguration());

            //Security
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
        }

        private void ApplyRules()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e=>e.Entity is IAuditInfo && 
                (e.State == EntityState.Added) || 
                (e.State == EntityState.Modified)))
              
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.CreatedOn = DateTime.Now;
                }

                e.ModifiedOn = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyRules();
            return base.SaveChanges();
        }
    }
}
