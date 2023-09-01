namespace Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DataContext : IdentityDbContext<AppIdentityUser>
    {

        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppIdentityUser> users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppIdentityUser>().HasMany(x => x.Bookings).WithOne(x => x.User).HasForeignKey(x => x.UserId);


        }

    }
}