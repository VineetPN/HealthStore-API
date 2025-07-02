using System.ComponentModel.DataAnnotations;

namespace HealthStore.API.Models.DTOs;

public class LoginDTO {
    [Required]
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}