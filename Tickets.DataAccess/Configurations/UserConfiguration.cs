using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;

namespace Tickets.DataAccess.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).IsRequired();

            builder.Property(u => u.LastName).IsRequired();

            builder.Property(u => u.Username).IsRequired();

            builder.Property(u => u.Email).IsRequired();

            builder.Property(u => u.Password).IsRequired();


            builder.HasIndex(u => u.Username).IsUnique();

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
