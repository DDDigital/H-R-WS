using System;
using System.Collections.Generic;
using System.Text;
using H_R_WS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace H_R_WS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }


       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            modelBuilder.Entity<Room>()
                    .HasMany(c => c.Features).WithMany(i => i.Rooms)
                    .Map(t => t.MapLeftKey("RoomD")
                    .MapRightKey("FeatureID")
                    .ToTable("RoomFeatures"));
        }
    }
}
