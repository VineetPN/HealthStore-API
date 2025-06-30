using HealthStore.API.Models.Domain;

namespace HealthStore.API.Repository;

public interface IRepoPatientDetails{
    Task<List<Patient>> GetAllPatientsAsync();

    Task<int> AddNewPatientVitals(Patient patients);

    Task<Patient> GetPatientByIdAsync(Guid? id);

    Task<int> UpdatePatientAsync(Patient patient);

    Task<int> DeletePatientAsync(Patient patient);
}