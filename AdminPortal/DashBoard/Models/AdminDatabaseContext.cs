using Microsoft.EntityFrameworkCore;

namespace DashBoard.Models
{
    public class AdminDatabaseContext : DbContext
    {
        public AdminDatabaseContext(DbContextOptions<AdminDatabaseContext> options) : base(options)
        {
        }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<SubArea> SubAreas { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Unit> Flats { get; set; }
        public DbSet<Section> Blocks { get; set; }
        public DbSet<Association> Associations { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<AmcItem> AmcItems { get; set; }
        //public DbSet<Amenety> Ameneties { get; set; }
        //public DbSet<ParkingLayout> ParkingLayouts { get; set; }
        public DbSet<Member> Members { get; set; }
        //public DbSet<GateKeeper> GateKeepers { get; set; }
        //public DbSet<ParkingSlot> ParkingSlots { get; set; }
        //public DbSet<PersonalHelper> PersonalHelpers { get; set; }
        //public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AttachmentBlob> AttachmentBlobs { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Community>()
                .HasOne(s => s.SubArea)
                .WithMany(c => c.Communities)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubArea>()
                .HasOne(s => s.Area)
                .WithMany(c => c.SubAreas)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Area>()
                .HasOne(s => s.City)
                .WithMany(c => c.Areas)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<City>()
                .HasOne(s => s.State)
                .WithMany(c => c.Cities)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Section>()
                .HasOne(b => b.Community)
                .WithMany(c => c.Blocks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Unit>()
                .HasOne(b => b.Block)
                .WithMany(c => c.Apartments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Member>()
            //    .HasOne(b => b.Apartment)
            //    .WithMany(c => c.Tenants)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Contact>();
            modelBuilder.Entity<User>()
                .HasOne(b => b.UserContact);
            modelBuilder.Entity<Attachment>();
            modelBuilder.Entity<AttachmentBlob>();


        }
    }
}

