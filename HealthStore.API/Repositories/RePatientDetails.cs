using System.Reflection.Metadata.Ecma335;
using HealthStore.API.Data;
using HealthStore.API.Models.Domain;
using SQLitePCL;

namespace HealthStore.API.Repository;

public class RePatientDetails : IRepoPatientDetails
{
    private readonly HSDbContext _dBContext;
    public RePatientDetails(HSDbContext hSDbContext){
        _dBContext = hSDbContext;
    }

    public async Task<int> AddNewPatientVitals(Patient patient)
    {
        await _dBContext.Patients.AddAsync(patient);
        await _dBContext.SaveChangesAsync();
        return 0;
    }

    public async Task<List<Patient>> GetAllPatientsAsync() => _dBContext.Patients.ToList();
}