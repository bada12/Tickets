using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;

namespace Tickets.DataAccess.Configurations
{
    internal class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.SpotName).IsRequired();

            builder.Property(v => v.Address).IsRequired();


            builder.HasOne(v => v.Event)
                .WithOne(e => e.Venue)
                .HasForeignKey<Venue>(v => v.EventId)
                .IsRequired();
        }
    }
}
