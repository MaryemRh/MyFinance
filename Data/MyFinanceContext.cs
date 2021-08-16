using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.Entity;
using Domain.Entities;
//
using Data.Configurations;
//
using Data.CustomConvention;

namespace Data
{
    public class MyFinanceContext : DbContext
    {
        public MyFinanceContext(): base("Name=MyFinanceCtx")
        {
            //Database.SetInitializer<MyFinanceContext>(new MyFinanceContextInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Facture> Factures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                
            //modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new ProductConfiguration());
            //modelBuilder.Configurations.Add(new AdressConfiguration());
            //modelBuilder.Conventions.Add(new DataTime2Convention());
            //base.OnModelCreating(modelBuilder); 
        }

  
    }

    public class MyFinanceContextInitializer : DropCreateDatabaseIfModelChanges<MyFinanceContext>
    {
        protected override void Seed(MyFinanceContext context)
        {
            var listCategories = new List<Category>{
            	new Category{Name="Medicament" },
            	new Category{Name="Vetement" },
            	new Category{Name="Meuble" },                   	
        	};

            context.Categories.AddRange(listCategories);
            context.SaveChanges();
        }

    }
}
