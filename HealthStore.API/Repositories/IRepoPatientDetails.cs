using HealthStore.API.Models.Domain;

namespace HealthStore.API.Repository;

public interface IRepoPatientDetails{
    Task<List<Patient>> GetAllPatientsAsync();

    Task<int> AddNewPatientVitals(Patient patients);
}