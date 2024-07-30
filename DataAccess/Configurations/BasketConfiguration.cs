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
    internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            #region ForeingKey

            builder.HasMany(x => x.BasketItems)
                      .WithOne(x => x.Basket)
                      .HasForeignKey(x => x.BasketId)
                      .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
