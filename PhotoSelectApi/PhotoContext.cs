using Microsoft.EntityFrameworkCore;
using PhotoSelectApi.Entities;

namespace PhotoSelectApi
{
    public class PhotoContext : DbContext, IPhotoContext
    {
        public PhotoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Photo> Photos { get; set; }
    }
}
