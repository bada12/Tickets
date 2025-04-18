using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;

namespace Tickets.DataAccess.Configurations
{
    internal class PriceLevelConfiguration : IEntityTypeConfiguration<PriceLevel>
    {
        public void Configure(EntityTypeBuilder<PriceLevel> builder)
        {
            builder.HasKey(pl => pl.Level);

            builder.Property(pl => pl.Level)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();


            builder.ToTable(_ =>
                _.HasCheckConstraint("CK_Level", @$"[Level] IN (
                    N'{PriceLevelEnum.Adult}'
                    ,N'{PriceLevelEnum.Child}'
                    ,N'{PriceLevelEnum.VIP}'
                )")
            );
        }
    }
}
