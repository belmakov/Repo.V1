using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityPortal.Data
{
    public class CommunityContext : DbContext
    {
        public CommunityContext(DbContextOptions<CommunityContext> options) : base(options)
        {
        }

        public DbSet<Community> Communities { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}
