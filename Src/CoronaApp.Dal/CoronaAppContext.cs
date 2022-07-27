using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoronaApp.Dal;

public class CoronaAppContext : DbContext
{
    public CoronaAppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Users { get; set; }
   
}

