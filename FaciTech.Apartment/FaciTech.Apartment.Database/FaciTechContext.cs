using FaciTech.Apartment.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FaciTech.Apartment.Database
{
    public class FaciTechContext : DbContext
    {
        public FaciTechContext(DbContextOptions<FaciTechContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Community> Community { get; set; }
        public DbSet<Section> Block { get; set; }
        public DbSet<CommunityLocation> CommunityLocation { get; set; }
        public DbSet<Country> Country{ get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<SubArea> SubArea { get; set; }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Feature> Feature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(e=>e.ToTable("User"));

            modelBuilder.Entity<UserGroup>().HasKey(ug => new { ug.UserId, ug.GroupId });
            modelBuilder.Entity<GroupRole>().HasKey(gr => new { gr.GroupId, gr.RoleId });
            modelBuilder.Entity<RoleFeature>().HasKey(rf => new { rf.RoleId, rf.FeatureId });

            modelBuilder.Entity<Unit>()
                .HasMany<Tenant>(u => u.Tenants)
                .WithOne(t => t.Unit)
                .HasForeignKey(t => t.UnitId)
                .OnDelete(DeleteBehavior.Restrict);


            Guid sysContactId = Guid.NewGuid();
            Guid sysUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User { Id = sysUserId, Created = DateTime.UtcNow, CreatedBy = sysUserId , Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Comments = "sys user record", Inactive = false, Password = "Bi4Fi6tHEiF+Cv3Jh0V0MA==", Salt = "123", Username = "system", Contact = null, ContactId = null});

            Guid indiaCountryId = Guid.NewGuid();
            modelBuilder.Entity<Country>().HasData(new Country { Id = indiaCountryId, Name = "India", Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });

            Guid karnatakaStateId = Guid.NewGuid();
            modelBuilder.Entity<State>().HasData(new State { Id = karnatakaStateId, Name = "Karnataka", CountryId = indiaCountryId, Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });

            Guid bangaloreCityId = Guid.NewGuid();
            modelBuilder.Entity<City>().HasData(new City { Id = bangaloreCityId, Name = "Bangalore", StateId = karnatakaStateId, Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });

            Guid northAreadId = Guid.NewGuid();
            modelBuilder.Entity<Area>().HasData(new Area { Id = northAreadId, Name = "North", CityId = bangaloreCityId, Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });
            Guid southAreadId = Guid.NewGuid();
            modelBuilder.Entity<Area>().HasData(new Area { Id = southAreadId, Name = "South", CityId = bangaloreCityId, Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });

            Guid jayanagarSubAreaId = Guid.NewGuid();
            modelBuilder.Entity<SubArea>().HasData(new SubArea { Id = jayanagarSubAreaId, Name = "Jayanagar", AreaId = southAreadId, Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });
            Guid hebbalSubAreaId = Guid.NewGuid();
            modelBuilder.Entity<SubArea>().HasData(new SubArea { Id = hebbalSubAreaId, Name = "Hebbal", AreaId = northAreadId, Created = DateTime.UtcNow, CreatedBy = sysUserId, Updated = DateTime.UtcNow, UpdatedBy = sysUserId, Inactive = false });



        }
    }
}
