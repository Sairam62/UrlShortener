using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services.Inerfaces;

namespace UrlShortener.Controllers
{
    /// <summary>
    /// Controller for managing URL shortening operations.
    /// </summary>
    
    [Route("api/url")]
    [ApiController]
    public class UrlShotenerController : ControllerBase
    {
        private readonly ITinyUrlService tinyUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlShortenerController"/> class.
        /// </summary>
        /// <param name="ITinyUrlService">The URL shortener service.</param>
        
        public UrlShotenerController(ITinyUrlService TinyUrl)
        {
            tinyUrl = TinyUrl;
        }

        /// <summary>
        /// Shorten a long URL and generate a unique short code for it.
        /// </summary>
        /// <param name="longurl">The long URL to shorten.</param>
        /// <returns>The generated short code for the URL.</returns>

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] string longurl)
        {
            string shortCode = await tinyUrl.ShortenUrlAsync(longurl);

            return Ok(shortCode);
        }

        /// <summary>
        /// Redirect to the original long URL using the short code.
        /// </summary>
        /// <param name="shortCode">The short code to resolve.</param>
        /// <returns>A redirection to the original long URL.</returns>

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectUrl(string shortCode)
        {
            string? longUrl = await tinyUrl.RedirectUrlAsync(shortCode);

            if(longUrl != null)
            {
                return RedirectPermanent(longUrl);
            }

            return NotFound();
        }
    }
}
