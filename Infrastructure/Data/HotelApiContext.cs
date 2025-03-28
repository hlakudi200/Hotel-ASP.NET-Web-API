using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class HotelApiContext : DbContext
    {

        public HotelApiContext(DbContextOptions<HotelApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<Admin> Admins { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Feature> Features { get; set; } = default!;
        public DbSet<RoomFeature> RoomFeatures { get; set; } = default!;

        public DbSet<Payment> Payments { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomFeature>()
                .HasOne(rf => rf.Room)
                .WithMany(r => r.RoomFeatures)
                .HasForeignKey(rf => rf.RoomId);

            modelBuilder.Entity<RoomFeature>()
                .HasOne(rf => rf.Feature)
                .WithMany()
                .HasForeignKey(rf => rf.FeatureId);

        }

    }
}
