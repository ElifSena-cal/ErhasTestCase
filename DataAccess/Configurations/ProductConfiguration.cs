using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            #region ForeingKey



            builder.HasMany(x => x.BasketItems)
                      .WithOne(x => x.Product)
                      .HasForeignKey(x => x.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);


            #endregion

        }

    }
}
