using HealthStore.API.Models.Domain;

namespace HealthStore.API.Repository;

public interface IRepoPatientVitals{

    Task<int> AddNewVitals(Vitals vitals);

    Task<Vitals> GetPatientVitalsByIdAsync(Guid? id);

    Task<int> UpdatePatientVitalsAsync(Vitals vitals);

    Task<int> DeletePatientVitalsAsync(Vitals vitals);

    Task<List<Vitals>> GetAllVitalsAsync();
}