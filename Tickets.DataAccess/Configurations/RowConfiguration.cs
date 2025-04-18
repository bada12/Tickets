using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;

namespace Tickets.DataAccess.Configurations
{
    internal class RowConfiguration : IEntityTypeConfiguration<Row>
    {
        public void Configure(EntityTypeBuilder<Row> builder)
        {
            builder.HasKey(r => r.Id);


            builder.HasIndex(r => new
            {
                r.Number,
                r.SectionId
            }).IsUnique();
        }
    }
}
