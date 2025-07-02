using HealthStore.API.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthStore.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase{

    private readonly UserManager<IdentityUser> _userManager;
    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserDTO registerUserDTO){
        try{
            var identityUser = new IdentityUser{
            UserName = registerUserDTO.UserName,
            Email = registerUserDTO.UserName
            };
            var identityResult = await _userManager.CreateAsync(identityUser, registerUserDTO.Password);

            if(identityResult.Succeeded){
                //Add roles to the user
                if(registerUserDTO.Roles.Any()){
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerUserDTO.Roles);
                    if(identityResult.Succeeded){
                        return Ok("User added successfully. Please login");
                    }
                }
            }
            return BadRequest("Something went wrong");

        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginIntoThis([FromBody] LoginDTO loginDTO){
        var user = await _userManager.FindByEmailAsync(loginDTO.UserName);
        if(user is not null){
            var resultPassVerification = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if(resultPassVerification){
                return Ok("Login Successful");
            }
            else{
                return BadRequest("Password Verification failed");
            }
        }
        return BadRequest("User not found");
    }
}