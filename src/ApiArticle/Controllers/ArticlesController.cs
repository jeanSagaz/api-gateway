using ApiArticle.Interfaces;
using ApiArticle.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiArticle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ArticlesController> _logger;
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(ILogger<ArticlesController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        [HttpGet("weather-forecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_articleRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var writer = _articleRepository.GetById(id);
            if (writer is null)
            {
                return NotFound();
            }

            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Article article)
        {
            var result = _articleRepository.Insert(article);
            return Created($"get/{article.Id}", result);
        }
    }
}
