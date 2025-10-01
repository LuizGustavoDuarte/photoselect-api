using PhotoSelectApi.DTOs;
using PhotoSelectApi.Entities;

namespace PhotoSelectApi.Repositories
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetPhotosByUserID(Guid userID);
        Photo GetPhotoByID(Guid photoID);
        Photo AddPhoto(Photo photo);
    }
}
