using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoronaApp.Dal
{
    public class CoronaAppContext : DbContext
    {
        public CoronaAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        //public DbSet<Log> Logs { get; set; }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = "324103357", Name = "Miriam"},
                new Patient() { Id = "324864800", Name = "Leah",  },
                new Patient() { Id = "212825376", Name = "Shani", });
        }*/
    }

}
