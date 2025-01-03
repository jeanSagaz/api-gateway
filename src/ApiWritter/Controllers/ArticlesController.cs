using ApiWritter.Interfaces;
using ApiWritter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWritter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> _logger;
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(ILogger<ArticlesController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
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
