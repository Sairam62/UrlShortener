namespace UrlShortener.Models
{
    public class UrlMapping
    {
        public int Id { get; set; }
        
        public string ShortCode { get; set; } = String.Empty;

        public string LongUrl { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
