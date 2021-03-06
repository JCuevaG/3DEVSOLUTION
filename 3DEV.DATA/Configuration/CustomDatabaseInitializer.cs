﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3DEV.MODELS;
using System.Data.Entity;

namespace _3DEV.DATA.Configuration
{
    public class CustomDatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>//CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            string[] description = new string[5] {
                "Description 1",
                "Description 2",
                "Description 3",
                "Description 4",
                "Description 5"
            };

            int count = 5;
            while((count--) != 0)
            {
                Product product = new Product();
                product.ProductName = string.Format("Producto {0} !", count);
                product.Price = 100 + (count * 100);
                product.Description = description[count];
                product.Quantity = 10 + count;
                product.CreatedOn = DateTime.Now;
                product.ModifiedOn = DateTime.Now;
                context.Products.Add(product);
            }

            Role admin = new Role();
            admin.RoleName = "admin";
            context.Roles.Add(admin);

            Role mgr = new Role();
            mgr.RoleName = "manager";
            context.Roles.Add(mgr);

            Role usr = new Role();
            usr.RoleName = "user";
            context.Roles.Add(usr);

            base.Seed(context);
        }
    }
}
