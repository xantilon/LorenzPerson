using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs.v2;

namespace PersonApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<PersonDto> Get()
        {
            return new List<PersonDto>();
        }
    }
}