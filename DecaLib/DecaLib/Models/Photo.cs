namespace DecaLib.Models
{
    public class Photo : BaseEntity
    {
        public string PhotoId { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public bool IsMain { get; set; }
    }
}