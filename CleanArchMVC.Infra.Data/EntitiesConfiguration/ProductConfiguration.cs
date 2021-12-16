using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.DS_NAME).HasMaxLength(100).IsRequired();
            builder.Property(p => p.DS_DESCRIPTION).HasMaxLength(200).IsRequired();
            builder.Property(p => p.VL_PRICE).HasPrecision(10, 2);

            builder.HasOne(p => p.Category).WithMany(e => e.Products).HasForeignKey(e => e.ID_CATEGORY);
        }
    }
}
