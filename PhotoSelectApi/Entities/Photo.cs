using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoSelectApi.Entities
{
    [Table("pho_photos")]
    public class Photo
    {
        [Key]
        public Guid PhotoID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public string Title { get; set; }

        public DateTime DateUploaded { get; set; }

        public DateTime DateUpdated { get; set; }

        public Photo()
        {
            PhotoID = Guid.NewGuid();
            DateUploaded = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }

    }
}
