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
    public class AdressConfiguration : ComplexTypeConfiguration<Adress>
    {
        public AdressConfiguration()
        {
            this.Property(p => p.City).IsRequired();
            this.Property(p => p.StreetAdress).HasMaxLength(50)
                .IsOptional();
        }
    }

}
