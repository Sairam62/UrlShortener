using Microsoft.EntityFrameworkCore;
using System.Text;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Services.Inerfaces;

namespace UrlShortener.Services
{
    public class TinyUrlService : ITinyUrlService
    {
        private readonly AppDbContext _dbcontext;
        private const string Base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public TinyUrlService(AppDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<string> ShortenUrlAsync(string LongUrl)
        {
            //Generate a unique short code
            string ShortUrl = GenerateShortUrl();
            ShortUrl = "8bURLqr";

            //Save Mapping to the DB
            var mapping = new UrlMapping
            {
                ShortCode = ShortUrl,
                LongUrl = LongUrl,
                CreatedAt = DateTime.UtcNow
            };

            _dbcontext.UrlMappings.Add(mapping);

            try
            {
                await _dbcontext.SaveChangesAsync();
                
                return ShortUrl;
            }
            catch (DbUpdateException ex)
            {
                _dbcontext.UrlMappings.Remove(mapping);

                // Handle the case where a unique constraint violation occurs (short code collision)
                // You can log the error or retry with a different short code
                if (IsUniqueConstraintViolation(ex))
                {
                    return await ShortenUrlAsync(LongUrl); // Retry with a new short code
                }

                throw; // Handle other exceptions
            }

        }

        private static bool IsUniqueConstraintViolation(DbUpdateException ex)
        {
            // Check if the exception is related to a unique constraint violation
            // This can vary depending on the database provider; adjust as needed
            return ex.InnerException is Npgsql.PostgresException pgEx &&
                   pgEx.SqlState == "23505"; // PostgreSQL unique violation code
        }

        public async Task<string?> RedirectUrlAsync(string shortCode)
        {
            var mapping = await _dbcontext.UrlMappings.FirstOrDefaultAsync(m => m.ShortCode == shortCode);

            if(mapping != null)
            {
                return mapping.LongUrl;
            }

            return null;
        }

        private static string GenerateShortUrl()
        {
            var x = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(x))
                throw new ArgumentNullException(nameof(x), "Input string cannot be null or empty.");

            var result = new StringBuilder();
            long value = 0;

            // Calculate a numerical value from the input string
            foreach (char c in x)
            {
                value = value * 256 + c;
            }

            // Encode the numerical value into Base62
            while (value > 0)
            {
                int remainder = (int)(value % 62);
                result.Insert(0, Base62Chars[remainder]);
                value /= 62;
            }

            return result.ToString()[..7];
        }
    }
}
