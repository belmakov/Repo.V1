using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DashBoard.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DashBoard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PopulateDbWithDefaults();

            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void PopulateDbWithDefaults()
        {
            DbContextOptions<AdminDatabaseContext> options = new DbContextOptionsBuilder<AdminDatabaseContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-AdminPortal-176EAB8B-97B8-4999-BFBE-6F7AE1D819E8;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

            using (var context = new AdminDatabaseContext(options))
            {
                if(context.Contacts.Any(c => c.FirstName == "System" && c.LastName == "System"))
                {

                }
                else
                {
                    var systemContactId = Guid.NewGuid();
                    var datetimeNow = DateTime.UtcNow;
                    var contact = new Contact()
                    {
                        Active = true,
                        Id = systemContactId,
                        CreatedBy = systemContactId,
                        Created = datetimeNow,
                        UpdatedBy = systemContactId,
                        Updated = datetimeNow,
                        Comments = "This is the default system account. This must not be deleted or updated",
                        Email = "system@nomail.com",
                        FirstName = "System",
                        LastName = "System",
                        Image = null,
                        Mobile = "12345 12345",
                        Phone = "54321 54321",
                        Address = null
                    };
                    context.Contacts.Add(contact);
                    context.SaveChanges();
                }
            }
        }
    }
}
