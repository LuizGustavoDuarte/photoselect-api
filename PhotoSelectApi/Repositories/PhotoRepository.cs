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
    }
}
