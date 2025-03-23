using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace HotelApi.Data
{
    public class HotelApiContext : DbContext
    {
  
        public HotelApiContext (DbContextOptions<HotelApiContext> options)
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
    
    }
}
