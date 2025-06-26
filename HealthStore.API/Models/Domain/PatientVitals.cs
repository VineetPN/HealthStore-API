using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HealthStore.API.Models.Domain;

public class PatientVitals{
    public int SPO2 { get; set; }
    public string? BloodPressure { get; set; }
    public string? SugarLevel { get; set; }
    public int BeatsPerMinute { get; set; }
    public string? Temperature { get; set; }
    public DateTime TimeStamp { get; set; }
}