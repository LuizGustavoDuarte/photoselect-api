namespace PhotoSelectApi.DTOs
{
    public class PhotoDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
