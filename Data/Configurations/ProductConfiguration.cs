using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Domain.Entities.Product>
    {
        public ProductConfiguration()
        {
            //Many to Many configuration
            this.HasMany(p => p.Providers)
            .WithMany(pr => pr.Products)
            .Map(m =>
            {
                m.ToTable("Providings");   //Table d'association
                m.MapLeftKey("Product");
                m.MapRightKey("Provider");
            });

            this.Property(p => p.Description).HasMaxLength(200).IsOptional();
            //One To Many
            this.HasRequired(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).WillCascadeOnDelete(false);

            //Inheritance
            this.Map<Biological>(c =>
            {
                c.Requires("IsBiological").HasValue(1);  //isBiological is the discreminator
            });
            this.Map<Chemical>(c =>
            {
                c.Requires("IsBiological").HasValue(0);
            });

        }
    }
}
