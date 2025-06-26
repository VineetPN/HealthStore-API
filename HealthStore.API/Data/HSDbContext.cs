using HealthStore.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HealthStore.API.Data;

public class HSDbContext : DbContext{
    public HSDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Patient> Patients { get; set; }
    //public DbSet<PatientVitals> PatientVitals{ get; set; }
    public DbSet<Vitals> Vitals{ get; set; }
}