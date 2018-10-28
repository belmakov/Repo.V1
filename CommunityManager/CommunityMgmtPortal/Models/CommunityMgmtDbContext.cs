using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommunityMgmtPortal.Models
{
    public partial class CommunityMgmtDbContext : DbContext
    {
        public CommunityMgmtDbContext()
        {
        }

        public CommunityMgmtDbContext(DbContextOptions<CommunityMgmtDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amenity> Amenity { get; set; }
        public virtual DbSet<AmenityType> AmenityType { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Community> Community { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionType> RegionType { get; set; }
        public virtual DbSet<SubArea> SubArea { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<TenantAmenityEntitlement> TenantAmenityEntitlement { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=facitechdbdev.database.windows.net;Initial Catalog=CommunityMgmtDb;Integrated Security=False;User ID=super_admin;Password=ZAQ!2wsx;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.AmenityType)
                    .WithMany(p => p.Amenity)
                    .HasForeignKey(d => d.AmenityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amenity_ToAmenityType");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AmenityCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amenity_ToCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AmenityUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amenity_ToUpdatedBy");
            });

            modelBuilder.Entity<AmenityType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AmenityTypeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AmenityType_ToCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AmenityTypeUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AmenityType_ToUpdatedBy");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_ToCity");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AreaCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_ToCreatedBy");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.AreaSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_ToSupervisor");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AreaUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_ToUpdatedBy");
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.Block)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Block_ToCommunity");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BlockCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Block_ToCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.BlockUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Block_ToUpdatedBy");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CityCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_ToCreatedBy");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_ToRegion");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.CityUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_ToUpdatedBy");
            });

            modelBuilder.Entity<Community>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CommunityCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Community_ToCreatedBy");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Community)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Community_ToLocation");

                entity.HasOne(d => d.SubArea)
                    .WithMany(p => p.Community)
                    .HasForeignKey(d => d.SubAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Community_ToSubArea");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.CommunityUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Community_ToUpdatedBy");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ContactCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_ToCreatedBy");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Contact_ToImage");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Contact_ToLocation");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ContactUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_ToUpdatedBy");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.CurrencyCode).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Timezone).HasMaxLength(100);

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CountryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_ToCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.CountryUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_ToUpdatedBy");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Image1)
                    .IsRequired()
                    .HasColumnName("Image")
                    .HasColumnType("image");

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AddressLine2).HasMaxLength(200);

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Landmarks).HasMaxLength(200);

                entity.Property(e => e.LocalityName).HasMaxLength(200);

                entity.Property(e => e.MapCordinates).HasMaxLength(50);

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_ToCity");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_ToCountry");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.LocationCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_ToCreatedBy");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_ToRegion");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.LocationUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_ToUpdatedBy");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Timezone).HasMaxLength(100);

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_ToCountry");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RegionCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_ToCreatedBy");

                entity.HasOne(d => d.RegionType)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.RegionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_ToRegionType");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.RegionUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_ToUpdatedBy");
            });

            modelBuilder.Entity<RegionType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RegionTypeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionType_ToCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.RegionTypeUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionType_ToUpdatedBy");
            });

            modelBuilder.Entity<SubArea>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.SubArea)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubArea_ToArea");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SubAreaCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubArea_ToCreatedBy");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.SubAreaSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubArea_ToSupervisor");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.SubAreaUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubArea_ToUpdatedBy");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Tenant)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_ToContact");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TenantCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_ToCreatedBy");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Tenant)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_ToUnit");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TenantUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_ToUpdatedBy");
            });

            modelBuilder.Entity<TenantAmenityEntitlement>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.Amenity)
                    .WithMany(p => p.TenantAmenityEntitlement)
                    .HasForeignKey(d => d.AmenityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenantAmenityEntitlement_ToAmenity");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TenantAmenityEntitlementCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenantAmenityEntitlement_ToCreatedBy");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantAmenityEntitlement)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenantAmenityEntitlement_ToTenant");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TenantAmenityEntitlementUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenantAmenityEntitlement_ToUpdatedBy");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_ToBlock");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UnitCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_ToCreatedBy");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_ToOwner");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.UnitUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_ToUpdatedBy");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("_Active");

                entity.Property(e => e.Comments).HasColumnName("_Comments");

                entity.Property(e => e.Created)
                    .HasColumnName("_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("_CreatedBy");

                entity.Property(e => e.Tags).HasColumnName("_Tags");

                entity.Property(e => e.Updated)
                    .HasColumnName("_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasColumnName("_UpdatedBy");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ToContact");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ToCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.InverseUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ToUpdatedBy");
            });
        }
    }
}
