using AutoMapper;
using HealthStore.API.Models.Domain;
using HealthStore.API.Models.DTOs;
using HealthStore.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HealthStore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PatientDetailsController : ControllerBase{

    private readonly IRepoPatientDetails _dbPatientDetails;
    private readonly IMapper _mapper;
    //For dependency injection.... Hell yeahh!!
    public PatientDetailsController(IRepoPatientDetails dbPatientDetails, IMapper mapper)
    {
        _dbPatientDetails = dbPatientDetails;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllPatientDetails(){
        var PatientList = await _dbPatientDetails.GetAllPatientsAsync();
        return Ok(PatientList);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetPatientDetailsByGuid([FromRoute] Guid? id){
        var patientDomain = await _dbPatientDetails.GetPatientByIdAsync(id);
        if(patientDomain == null){return NotFound(id);}

        return Ok(patientDomain);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewPatientDetails([FromBody] PatientDTO newPatient){
        if(newPatient.PhoneNumber != 123){return BadRequest("Please enter some data");}

        var domainPatient = new Patient(){
            Id = Guid.NewGuid()
        };
        _mapper.Map<PatientDTO, Patient>(newPatient, domainPatient);

        var result = await _dbPatientDetails.AddNewPatientVitals(domainPatient);
        if(result is 0) return Ok (newPatient);
        else return BadRequest("Something has happened"); 

    }
    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> UpdatePatientDetails([FromBody] UpdatePatientDTO updateDTO, [FromRoute] Guid id){
        try{
            var patientDomain = await _dbPatientDetails.GetPatientByIdAsync(id);
            if(patientDomain == null){return NotFound(id);}

            _mapper.Map<UpdatePatientDTO, Patient>(updateDTO, patientDomain);
            await _dbPatientDetails.UpdatePatientAsync(patientDomain);
            return Ok(updateDTO);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }  
    [HttpDelete]
    [Route("{id:Guid}")] 
    public async Task<IActionResult> DeletePatientDetails([FromRoute] Guid? id){
        try{
            var patDetails = await _dbPatientDetails.GetPatientByIdAsync(id);
            if(patDetails == null){return NotFound();}
            await _dbPatientDetails.DeletePatientAsync(patDetails);
            return Ok($"deleted id {id}");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

}