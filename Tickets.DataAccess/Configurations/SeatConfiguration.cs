﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;

namespace Tickets.DataAccess.Configurations
{
    internal class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.PriceLevel)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();


            builder.HasOne(s => s.Offer)
                .WithMany(o => o.Seats)
                .HasForeignKey(s => s.OfferId);

            builder.HasOne(s => s.LevelPrice)
                .WithMany(pl => pl.Seats)
                .HasForeignKey(s => s.PriceLevel)
                .IsRequired();


            builder.ToTable(_ =>
                _.HasCheckConstraint("CK_Status", @$"[Status] IN (
                    N'{SeatStatus.Available}'
                    ,N'{SeatStatus.Booked}'
                    ,N'{SeatStatus.Purchased}'
                )")
            );

            builder.ToTable(_ =>
                _.HasCheckConstraint("CK_PriceLevel", @$"[PriceLevel] IN (
                    N'{Domain.Enums.PriceLevel.Adult}'
                    ,N'{Domain.Enums.PriceLevel.Child}'
                    ,N'{Domain.Enums.PriceLevel.VIP}'
                )")
            );
        }
    }
}
