using PhotoSelectApi.Entities;

namespace PhotoSelectApi.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IPhotoContext _photoContext;

        public PhotoRepository(IPhotoContext photoContext)
        {
            _photoContext = photoContext;
        }
        public Photo GetPhotoByID(Guid photoID)
        {
            return _photoContext.Photos.FirstOrDefault(photo => photo.PhotoID == photoID);
        }

        public IEnumerable<Photo> GetPhotosByUserID(Guid userID)
        {
            return _photoContext.Photos.Where(photo => photo.UserID == userID).ToList();
        }

        public Photo AddPhoto(Photo photo)
        {
            if(photo.PhotoID == Guid.Empty)
            {
                photo.PhotoID = Guid.NewGuid();
            }

            if(photo.UserID == Guid.Empty)
            {
                throw new ArgumentException("UserID cannot be empty.");
            }

            var newPhoto = _photoContext.Photos.Add(photo).Entity;
            _photoContext.SaveChanges();
            return newPhoto;
        }

        public Photo UpdatePhoto(Photo photo)
        {
            var existingPhoto = _photoContext.Photos.FirstOrDefault(p => p.PhotoID == photo.PhotoID);
            if(existingPhoto == null)
            {
                throw new ArgumentException("Photo not found.");
            }
            existingPhoto.Url = photo.Url;
            existingPhoto.Description = photo.Description;
            existingPhoto.Title = photo.Title;
            existingPhoto.DateUpdated = DateTime.UtcNow;
            _photoContext.Photos.Update(existingPhoto);
            return existingPhoto;
        }
    }
}
