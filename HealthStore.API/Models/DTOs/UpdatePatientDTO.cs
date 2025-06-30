namespace HealthStore.API.Models.DTOs;

public class UpdatePatientDTO{
    public string? PatientName { get; set; }
    public int PhoneNumber { get; set; }
    public float weight { get; set; } = 0.0f;
    public string? PatientDoc { get; set; }
}