namespace PhotoSelectApi.Services
{
    using PhotoSelectApi.DTOs;

    public interface IPhotoService
    {
        IEnumerable<PhotoDTO> GetUserPhotos(Guid userID);
        PhotoDTO GetPhoto(Guid photoID);
    }
}