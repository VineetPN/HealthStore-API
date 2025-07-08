using HealthStore.API.Models.Domain;
using HealthStore.API.Models.DTOs;
using HealthStore.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HealthStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase{
    private readonly IImageRepository imageRepository;

    public ImagesController(IImageRepository imageRepository){
        this.imageRepository = imageRepository;
    }
    //api/Images/Upload
    [HttpPost]
    [Route("Upload")]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO requestDTO){
        ValiDateFileUpload(requestDTO);
        if(ModelState.IsValid){
            // get the details from the requestDTO and form an entity
            var imageEntity = new Image{
                Id = Guid.NewGuid(),
                File = requestDTO.File, 
                FileDescription = requestDTO.FileDescription, 
                FileName = requestDTO.FileName, 
                FileExtension = Path.GetExtension(requestDTO.FileName)
            };
            await imageRepository.UploadToLocal(imageEntity);

            return Ok(imageEntity);
        }
        else
            return BadRequest(ModelState);
    }

    private void ValiDateFileUpload(ImageUploadRequestDTO requestDTO){
        var allowedExtension = new string[]{".jpeg", ".jpg", ".png",};

        if(!allowedExtension.Contains(Path.GetExtension(requestDTO.FileName))){
            ModelState.AddModelError("File", "UnSupported file extension");
        }
        if(requestDTO.File.Length > 10485760){
            ModelState.AddModelError("Image","Unsupported file size");
        }
    }


}