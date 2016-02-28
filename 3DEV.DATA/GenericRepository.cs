using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEV.DATA
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public DbSet<T> DbSet { get; set; }
        public DbContext context { get; set; }       

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {

            }

            this.context = context;
            this.DbSet = this.context.Set<T>();
        }


        public void Add(T entity)
        {
            this.DbSet.Add(entity);
            this.context.SaveChanges();

        }

        public void Delete(T entity)
        {
            this.DbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public T FindById(int Id)
        {
            return this.DbSet.Find(Id);
        }

        public void Update(T entity)
        {
            //this.context.SaveChanges();
        }

        public IQueryable<T> List()
        {
            return this.DbSet;
        }
    }
}
