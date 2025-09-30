using Microsoft.EntityFrameworkCore;
using PhotoSelectApi.Entities;

namespace PhotoSelectApi
{
    public interface IPhotoContext
    {
        DbSet<Photo> Photos { get; set; }
    }
}