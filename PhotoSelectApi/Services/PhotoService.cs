using PhotoSelectApi.DTOs;
using PhotoSelectApi.Entities;
using PhotoSelectApi.Repositories;

namespace PhotoSelectApi.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository) {
            _photoRepository = photoRepository;
        }

        public PhotoDTO GetPhoto(Guid photoID)
        {
            Photo foundPhoto = _photoRepository.GetPhotoByID(photoID);
            if(foundPhoto == null)
            {
                return null;
            }
            return new PhotoDTO
            {
                Id = foundPhoto.PhotoID,
                UserId = foundPhoto.UserID,
                Url = foundPhoto.Url,
                Description = foundPhoto.Description
            };
        }

        public IEnumerable<PhotoDTO> GetUserPhotos(Guid userID)
        {
            IEnumerable<Photo> photos = _photoRepository.GetPhotosByUserID(userID);
            if(!photos.Any())
            {
                return new List<PhotoDTO>();
            }
            return photos.Select(photo => new PhotoDTO
            {
                Id = photo.PhotoID,
                UserId = photo.UserID,
                Url = photo.Url,
                Description = photo.Description
            });
        }
    }
}
