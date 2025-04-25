using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Entities;

namespace Tickets.DataAccess
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext() : base()
        {
        }

        public TicketsDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Row> Rows { get; set; }

        public DbSet<PriceLevel> PriceLevels { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketsDbContext).Assembly);

            modelBuilder.Entity<PriceLevel>()
                .HasData(DataGenerator.PriceLevels);

            modelBuilder.Entity<User>()
                .HasData(DataGenerator.Users);

            modelBuilder.Entity<Manager>()
                .HasData(DataGenerator.Managers);

            modelBuilder.Entity<Event>()
                .HasData(DataGenerator.Events);

            modelBuilder.Entity<Venue>()
                .HasData(DataGenerator.Venues);

            modelBuilder.Entity<Section>()
                .HasData(DataGenerator.Sections);

            modelBuilder.Entity<Row>()
                .HasData(DataGenerator.Rows);

            modelBuilder.Entity<Seat>()
                .HasData(DataGenerator.Seats);
        }
    }
}
