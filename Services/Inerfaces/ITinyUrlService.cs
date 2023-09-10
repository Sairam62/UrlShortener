namespace UrlShortener.Services.Inerfaces
{
    public interface ITinyUrlService
    {
        Task<string?> ShortenUrlAsync(string LongUrl);

        Task<string?> RedirectUrlAsync(string shortCode);
    }
}