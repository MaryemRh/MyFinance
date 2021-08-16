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
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            //le nom de la table au niveau de la BD
            this.ToTable("MyCategories");
            this.HasKey(c => c.CategoryId);//clé primaire
            this.Property(c => c.Name).HasMaxLength(50).IsRequired();//

        }

    }
}
