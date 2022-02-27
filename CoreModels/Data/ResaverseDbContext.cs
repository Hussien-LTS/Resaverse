using CoreModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreModels.Data
{
    public class ResaverseDbContext : IdentityDbContext<ApplicationUser>
    {
        public ResaverseDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Amenity>()
                .HasIndex(sad => sad.AmenityName).IsUnique();
            modelBuilder
                .Entity<Amenity>()
                .HasMany(a => a.RoomAmenities)
                .WithOne(am => am.Amenity)
                .HasForeignKey(a => a.AmenityId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<Floor>()
                .HasMany(f => f.Rooms)
                .WithOne(f => f.Floor)
                .HasForeignKey(f => f.FloorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<Room>()
                .HasMany(r => r.RoomAmenities)
                .WithOne(f => f.Room)
                .HasForeignKey(f => f.RoomId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<RoomType>()
                .HasMany(rt => rt.Rooms)
                .WithOne(rt => rt.RoomType)
                .HasForeignKey(rt => rt.RoomTypeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<RoomAmenity>()
                .HasKey(ra => new { ra.AmenityId, ra.RoomId });
            modelBuilder
                .Entity<Reservation>()
                .HasKey(r => new { r.RoomId, r.UserId });
        }
    }
}
