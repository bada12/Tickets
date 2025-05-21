using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;

namespace Tickets.DataAccess.Configurations
{
    internal class PriceLevelConfiguration : IEntityTypeConfiguration<Domain.Entities.PriceLevel>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.PriceLevel> builder)
        {
            builder.HasKey(pl => pl.Level);

            builder.Property(pl => pl.Level)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();


            builder.ToTable(_ =>
                _.HasCheckConstraint("CK_Level", @$"[Level] IN (
                    N'{Domain.Enums.PriceLevel.Adult}'
                    ,N'{Domain.Enums.PriceLevel.Child}'
                    ,N'{Domain.Enums.PriceLevel.VIP}'
                )")
            );
        }
    }
}
