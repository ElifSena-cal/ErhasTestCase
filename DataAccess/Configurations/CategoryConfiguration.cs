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
    public  class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            #region ForeingKey

            builder.HasMany(x => x.Products)
                        .WithOne(x => x.Category)
                        .HasForeignKey(x => x.CategoryId)
                        .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region SeedData

            var category1 = new Category() { Id = Guid.NewGuid(), Name = "Mont", CreatedDate = new DateTime(2022, 09, 08) };
            var category2 = new Category() { Id = Guid.NewGuid(), Name = "Hırka ve Süveter", CreatedDate = new DateTime(2022, 09, 08) };
            var category3 = new Category() { Id = Guid.NewGuid(), Name = "Kazak", CreatedDate = new DateTime(2022, 09, 08) };
            var category4 = new Category() { Id = Guid.NewGuid(), Name = "Bluz", CreatedDate = new DateTime(2022, 09, 08) };
            var category5 = new Category() { Id = Guid.NewGuid(), Name = "Gömlek", CreatedDate = new DateTime(2022, 09, 08) };
            var category6 = new Category() { Id = Guid.NewGuid(), Name = "Tişört", CreatedDate = new DateTime(2022, 09, 08) };
            var category7 = new Category() { Id = Guid.NewGuid(), Name = "Sweatshirt", CreatedDate = new DateTime(2022, 09, 08) };
            var category8 = new Category() { Id = Guid.NewGuid(), Name = "Jean", CreatedDate = new DateTime(2022, 09, 08) };

            builder.HasData(category1, category2, category3, category4, category5, category6, category7, category8);

            #endregion
        }
    }
}
