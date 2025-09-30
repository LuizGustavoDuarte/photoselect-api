using Microsoft.AspNetCore.Mvc;
using PhotoSelectApi.DTOs;
using PhotoSelectApi.Services;

namespace PhotoSelectApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {

        private readonly ILogger<PhotosController> _logger;
        private readonly IPhotoService _photoService;

        public PhotosController(ILogger<PhotosController> logger, IPhotoService photoService)
        {
            _logger = logger;
            _photoService = photoService;
        }

        [HttpGet("user/{userID}/")]
        public IActionResult GetUserPhotos(Guid userID)
        {
            IEnumerable<PhotoDTO> responsePhotos = _photoService.GetUserPhotos(userID);

            if(!responsePhotos.Any())
            {
                return NotFound();
            }

            return Ok(responsePhotos);
        }

        [HttpGet("/{photoID}/")]
        public IActionResult GetPhoto(Guid photoID)
        {
            PhotoDTO responsePhoto = _photoService.GetPhoto(photoID);
            if(responsePhoto == null)
            {
                return NotFound();
            }
            return Ok(responsePhoto);
        }
    }
}
