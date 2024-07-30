using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

            //#region ForeingKey

            //builder.HasMany(x => x.Products)
            //          .WithOne(x => x.Brand)
            //          .HasForeignKey(x => x.BrandId)
            //          .OnDelete(DeleteBehavior.Restrict);

            //#endregion

            #region SeedData

            var brand1 = new Brand() { Id = Guid.NewGuid(), Name = "LCWAIKIKI", CreatedDate = new DateTime(2022, 09, 08) };
            var brand2 = new Brand() { Id = Guid.NewGuid(), Name = "DEFACTO", CreatedDate = new DateTime(2022, 09, 08) };
            var brand3 = new Brand() { Id = Guid.NewGuid(), Name = "MANGO", CreatedDate = new DateTime(2022, 09, 08) };
            var brand4 = new Brand() { Id = Guid.NewGuid(), Name = "MAVİ", CreatedDate = new DateTime(2022, 09, 08) };
            var brand5 = new Brand() { Id = Guid.NewGuid(), Name = "TRENDYOL", CreatedDate = new DateTime(2022, 09, 08) };
            builder.HasData(brand1, brand2, brand3, brand4, brand5);

            #endregion
        }
    }
}
