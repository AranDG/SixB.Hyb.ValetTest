using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SixB.Hyb.ValetTest.Core.Models.DTOs;
using SixB.Hyb.ValetTest.Core.Models;

namespace SixB.Hyb.ValetTest.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BookingDto> Bookings { get; set; }
        public DbSet<VehicleSize> VehicleSizes { get; set; }
        public DbSet<FlexibilityDay> FlexibilityDays { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Bookings = Set<BookingDto>();
            VehicleSizes = Set<VehicleSize>();
            FlexibilityDays = Set<FlexibilityDay>();
            ApplicationUsers = Set<ApplicationUser>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleSize>()
                .HasIndex(b => b.Id);

            modelBuilder.Entity<VehicleSize>()
                .HasIndex(vt => vt.Name)
                .IsUnique();

            modelBuilder.Entity<FlexibilityDay>()
                .HasIndex(b => b.Id);


            modelBuilder.Entity<VehicleSize>().HasData(InitialSeedData.VehicleTypes);
            modelBuilder.Entity<FlexibilityDay>().HasData(InitialSeedData.FlexibilityDays);
            modelBuilder.Entity<BookingDto>().HasData(InitialSeedData.Bookings);
            modelBuilder.Entity<ApplicationUser>().HasData(InitialSeedData.Users);
        }
    }
}