using Microsoft.EntityFrameworkCore;

namespace DashBoard.Models
{
    public class AdminDatabaseContext : DbContext
    {
        public AdminDatabaseContext(DbContextOptions<AdminDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<AmcItem> AmcItems { get; set; }
        public DbSet<Amenety> Ameneties { get; set; }
        public DbSet<ParkingLayout> ParkingLayouts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GateKeeper> GateKeepers { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<PersonalHelper> PersonalHelpers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}

