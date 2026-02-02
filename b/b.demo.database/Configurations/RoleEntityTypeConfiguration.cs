using b.demo.database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace b.demo.database.Configurations
{
    internal class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.Name).IsUnique();

            builder.HasData(new Role { Id = 1, Name = BuiltInRoles.User });
            builder.HasData(new Role { Id = 2, Name = BuiltInRoles.Admin });
        }
    }
}
