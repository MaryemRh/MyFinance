using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateProd { get; set; }
        public string ImageName { get; set; }
        //foreign Key properties
        public int? CategoryId { get; set; }
        //navigation properties
        public virtual Category Category { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }

        public int NbreClient { get; set; }

        public ProductModel(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;
            DateProd = product.DateProd;
            CategoryId = product.CategoryId;
            Category = product.Category;
            Providers = product.Providers;
            Factures = product.Factures;
        }
    }
}