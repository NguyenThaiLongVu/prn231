using Microsoft.EntityFrameworkCore;

namespace PRN231.Entities
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<BookingSlot> BookingSlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        public DbSet<FacilityCheck> FacilityChecks { get; set; }
        public DbSet<UserAgreement> UserAgreements { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<RoomFacility>()
                .HasOne(rf => rf.Room)
                .WithMany(r => r.RoomFacilities)
                .HasForeignKey(rf => rf.RoomID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingHistory>()
                .HasOne(bh => bh.Booking)
                .WithMany()
                .HasForeignKey(bh => bh.BookingID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHistory>()
                .HasOne(bh => bh.User)
                .WithMany()
                .HasForeignKey(bh => bh.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHistory>()
                .HasOne(bh => bh.Room)
                .WithMany()
                .HasForeignKey(bh => bh.RoomID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHistory>()
                .HasOne(bh => bh.Slot)
                .WithMany()
                .HasForeignKey(bh => bh.SlotID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHistory>()
                .HasOne(bh => bh.ProcessedUser)
                .WithMany()
                .HasForeignKey(bh => bh.ProcessedBy)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Facility>()
                .Property(f => f.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<FacilityCheck>()
                .HasOne(fc => fc.User)
                .WithMany()
                .HasForeignKey(fc => fc.CheckedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FacilityCheck>()
                .HasOne(fc => fc.Booking)
                .WithMany()
                .HasForeignKey(fc => fc.BookingID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
