using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data;
using Domain.Entities;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add Product
            using (var context = new MyFinanceContext())
            {
                var pr = new Product()
                {
                    Name = "Tomate",
                    Price = 5,
                    Quantity = 3,
                    DateProd = DateTime.Now,
                    CategoryId=1
                };
                context.Products.Add(pr);

                context.SaveChanges();
            }
        }
    }
}
