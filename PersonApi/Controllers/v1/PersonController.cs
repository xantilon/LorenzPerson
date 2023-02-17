using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs.v1;

namespace PersonApi.Controllers.v1
{
    /// <summary>
    /// Controller for CRUD operations for people    
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {       

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        ///<summary>
        ///Get all People
        ///</summary>
        ///<returns>List of People</returns>
        [HttpGet()]
        public IEnumerable<PersonDto> Get()
        {
            return new List<PersonDto>();
        }
    }
}