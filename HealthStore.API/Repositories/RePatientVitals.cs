using System.Reflection.Metadata.Ecma335;
using HealthStore.API.Data;
using HealthStore.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HealthStore.API.Repository;

public class RePatientVitals : IRepoPatientVitals
{
    private readonly HSDbContext _dbContext;
    public RePatientVitals(HSDbContext hSDbContext){
        _dbContext = hSDbContext;
    }

    public async Task<int> AddNewVitals(Vitals vitals)
    {
        await _dbContext.Vitals.AddAsync(vitals);
        await _dbContext.SaveChangesAsync();
        return 0;
    }

    public async Task<int> DeletePatientVitalsAsync(Vitals vitals)
    {
        _dbContext.Vitals.Remove(vitals);
        await _dbContext.SaveChangesAsync();
        return 0;
    }

    public async Task<List<Vitals>> GetAllVitalsAsync() => await _dbContext.Vitals.ToListAsync();

    public async Task<Vitals> GetPatientVitalsByIdAsync(Guid? id)
    {
        return await _dbContext.Vitals.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> UpdatePatientVitalsAsync(Vitals patient)
    {
        _dbContext.Vitals.Update(patient);
        return await _dbContext.SaveChangesAsync();
    }

    Task<Vitals> IRepoPatientVitals.GetPatientVitalsByIdAsync(Guid? id)
    {
        throw new NotImplementedException();
    }
}