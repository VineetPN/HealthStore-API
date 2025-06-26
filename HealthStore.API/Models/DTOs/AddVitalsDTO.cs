namespace HealthStore.API.Models.DTOs;

public class AddVitalsDTO{
    public string? Name { get; set; }
    public string? PatDoc { get; set; }
    

    public int SPO2 { get; set; }
    public string? BloodPressure { get; set; }
    public string? SugarLevel { get; set; }
    public int BeatsPerMinute { get; set; }
    public string? Temperature { get; set; }
    public DateTime TimeStamp { get; set; }
}