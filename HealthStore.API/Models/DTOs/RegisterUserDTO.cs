using System.ComponentModel.DataAnnotations;

namespace HealthStore.API.Models.DTOs;

public class RegisterUserDTO{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public string[] Roles { get; set; }
}