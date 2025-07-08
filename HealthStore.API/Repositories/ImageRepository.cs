using HealthStore.API.Data;
using HealthStore.API.Models.Domain;

namespace HealthStore.API.Repository;

public class ImageRepository : IImageRepository
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly HSDbContext dbContext;

    public ImageRepository(IWebHostEnvironment webHostEnvironment, 
        IHttpContextAccessor httpContextAccessor,
        HSDbContext dbContext)
    {
        this.webHostEnvironment = webHostEnvironment;
        this.httpContextAccessor = httpContextAccessor;
        this.dbContext = dbContext;
    }
    public async Task<Image> UploadToLocal(Image imageObj)
    {
        // get the image from the ActionMethod
        var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", imageObj.FileName, imageObj.FileExtension);
        // Create a new file with that name and copy the contect from the IFormImage
        using var reader = new FileStream(localPath, FileMode.Create, FileAccess.ReadWrite);
        
        await imageObj.File.CopyToAsync(reader);

        // We have to build the url for the images where they are saved
        // Ex: https://localhost:1234/images/filename.png For that we need to add HttpContextAccessor in program.cs

        var imagePath = $@"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}
        {httpContextAccessor.HttpContext.Request.PathBase}/Images/{imageObj.FileName}{imageObj.FileExtension}";
        Console.WriteLine(imagePath);

        imageObj.FilePath = imagePath;

        dbContext.Images.Add(imageObj);
        await dbContext.SaveChangesAsync();

        return imageObj;
    }
}