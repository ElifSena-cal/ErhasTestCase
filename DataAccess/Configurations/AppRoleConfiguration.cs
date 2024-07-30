using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            #region SeedData

            var role1 = new AppRole() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" };
            var role2 = new AppRole() { Id = 2, Name = "User", NormalizedName = "USER" };

            builder.HasData(role1, role2);

            #endregion
        }
    }
}