using AutoMapper;
using HealthStore.API.Models.Domain;
using HealthStore.API.Models.DTOs;
using HealthStore.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthStore.API.Controllers;
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PatientVitals : ControllerBase{

    private readonly IRepoPatientVitals _dbContext;
    private readonly IMapper _mapper;
    public PatientVitals(IRepoPatientVitals repoPatientDetails, IMapper mapper){
        _dbContext = repoPatientDetails;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVitals(){
        try{
            var patient = await _dbContext.GetAllVitalsAsync();
            return Ok(patient);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetVitalsById([FromRoute] Guid? id){
        try{
            var patient = await _dbContext.GetPatientVitalsByIdAsync(id);
            return Ok(patient);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewPatientVitals([FromBody] AddVitalsDTO addVitalsDTO)
    {
        try{
            var vitalsDomain = new Vitals(){
                Id = Guid.NewGuid()
            };
            _mapper.Map<AddVitalsDTO, Vitals>(addVitalsDTO, vitalsDomain);
            await _dbContext.AddNewVitals(vitalsDomain);
            return Ok(addVitalsDTO);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> UpdatePatientVitals([FromRoute] Guid? id, [FromBody] AddVitalsDTO updateVitalsDTO)
    {
        try {
            var vitalsDomain = await _dbContext.GetPatientVitalsByIdAsync(id) ?? throw new ArgumentNullException(nameof(id));

            _mapper.Map<AddVitalsDTO, Vitals>(updateVitalsDTO, vitalsDomain);

            await _dbContext.UpdatePatientVitalsAsync(vitalsDomain);

            return Ok(vitalsDomain);
        }
        catch(Exception ex){
            return BadRequest(ex.Message) ;
        }
    }
    [HttpDelete]
     [Route("{id:Guid}")]
    public async Task<IActionResult> DeletePatientVitals([FromRoute] Guid? id){
        try {
            var vitalsDomain = await _dbContext.GetPatientVitalsByIdAsync(id) ?? throw new ArgumentNullException(nameof(id));
            await _dbContext.DeletePatientVitalsAsync(vitalsDomain);
            return Ok($"Deleted the record with id {id}");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }

    }   
}