using System.Reflection.Metadata.Ecma335;
using HealthStore.API.Data;
using HealthStore.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
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

    public async Task<int> DeletePatientAsync(Patient patient)
    {
        try{
            _dBContext.Patients.Remove(patient);
            await _dBContext.SaveChangesAsync();
            return 0;
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    public async Task<List<Patient>> GetAllPatientsAsync() => _dBContext.Patients.ToList();

    public async Task<Patient> GetPatientByIdAsync(Guid? id)
    {
        return await _dBContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> UpdatePatientAsync(Patient patient)
    {
        try
    {
        _dBContext.Patients.Update(patient);
        await _dBContext.SaveChangesAsync();
        return 0;
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database update failed: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while updating patient: {ex.Message}");
    }

    return -1; 
    }
}