using ApiAuthentication.Models;
using ApiAuthentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IJwtTokenService _articleRepository;

        public AuthenticationController(ILogger<AuthenticationController> logger, IJwtTokenService articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login model)
        {
            var result = _articleRepository.GenerateAuthToken(model);
            if (result is null)
                return Unauthorized();

            return Ok(result);
        }
    }
}
