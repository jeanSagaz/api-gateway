using ApiWritter.Interfaces;
using ApiWritter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWritter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WritersController : ControllerBase
    {
        private readonly ILogger<WritersController> _logger;
        private readonly IWriterRepository _writerRepository;

        public WritersController(ILogger<WritersController> logger, IWriterRepository writerRepository)
        {
            _logger = logger;
            _writerRepository = writerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_writerRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var writer = _writerRepository.GetById(id);
            if (writer is null)
            {
                return NotFound();
            }

            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Writer writer)
        {
            var result = _writerRepository.Insert(writer);
            return Created($"get/{writer.Id}", result);
        }
    }
}
