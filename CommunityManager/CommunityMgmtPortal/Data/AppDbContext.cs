using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using CommunityMgmtPortal.Models;

namespace CommunityMgmtPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Community> Communities { get; set; }
        public DbSet<SubArea> SubAreas { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}
