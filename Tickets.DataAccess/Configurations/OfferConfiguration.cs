using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;

namespace Tickets.DataAccess.Configurations
{
    internal class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Status)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.UserId)
                .IsRequired();


            builder.ToTable(_ =>
                _.HasCheckConstraint("CK_Status", @$"[Status] IN (
                    N'{OfferStatusEnum.Created}'
                    ,N'{OfferStatusEnum.Sent}'
                    ,N'{OfferStatusEnum.Paid}'
                    ,N'{OfferStatusEnum.Declined}'
                )")
            );
        }
    }
}
