using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
namespace ShelterReadinessSystemAPI.Data;



public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Inspection> Inspections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shelter>() //Between shelter to area
             .HasOne(e => e.Area)
             .WithMany(e => e.Shelters)
             .HasForeignKey(e => e.AreaId)
             .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Shelter>()
            .HasMany(e => e.Inspections)
            .WithOne(e=> e.Shelter)
            .HasForeignKey(e=> e.ShelterId).
            OnDelete(DeleteBehavior.Cascade);
    }

}

