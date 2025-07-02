using HealthStore.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HealthStore.API.Data;

public class HSDbContext : IdentityDbContext{
    public HSDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Patient> Patients { get; set; }
    //public DbSet<PatientVitals> PatientVitals{ get; set; }
    public DbSet<Vitals> Vitals{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Seed the data.
        // This is the older way of seeding the data

        var seedObj = new Patient(){
            Id = Guid.Parse("8f5d33a7-9ac7-4fc1-84a3-21e1c1829f7e"),
            PatientName = "GHJ",
            PhoneNumber = 1234567890,
            weight = 66.6f,
            PatientDoc = "Mr. String"
        };

        modelBuilder.Entity<Patient>().HasData(seedObj);


        var roleObj = new List<IdentityRole>(){
            new IdentityRole(){
                Id = "4dbe5fa8-338b-4e77-9e7c-69c7ac8bbba2",
                Name = "NonAdmin",
                ConcurrencyStamp = "4dbe5fa8-338b-4e77-9e7c-69c7ac8bbba2", 
                NormalizedName = "NonAdmin".ToUpper()
            },
            new IdentityRole(){
                Id = "39a21228-ea23-42a5-bf0a-32c4fe253a1c",
                Name = "Admin",
                ConcurrencyStamp = "39a21228-ea23-42a5-bf0a-32c4fe253a1c", 
                NormalizedName = "Admin".ToUpper()
            }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roleObj);

    }
}