using HealthStore.API.Models.Domain;

namespace HealthStore.API.Repository;

public interface IImageRepository{
    Task<Image> UploadToLocal(Image imageObj);
}