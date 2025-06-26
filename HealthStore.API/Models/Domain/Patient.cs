namespace HealthStore.API.Models.Domain;

public class Patient{
    public Guid Id { get; set; }
    public string? PatientName { get; set; }
    public int PhoneNumber { get; set; }
    public float weight { get; set; } = 0.0f;
    public string? PatientDoc { get; set; }

}