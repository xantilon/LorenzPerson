using Microsoft.AspNetCore.Mvc;
using PersonApi.Data;
using PersonApi.Data.DTOs.v2;
using PersonApi.Data.Models;
using PersonApi.Services.Mapping.v2;

namespace PersonApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly LorenzContext _db;
        private readonly PersonMappingService _personMapper;

        public PersonController(ILogger<PersonController> logger,
                                LorenzContext db,
                                PersonMappingService personMapper)
        {
            _logger = logger;
            _db = db;
            _personMapper = personMapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet()]
        public ActionResult<IEnumerable<PersonDto>> Get()
        {
            List<PersonDto> ret = _db.People
                .Select(p => _personMapper.ToDto(p))
                .ToList();
            if (!ret.Any())
                return NotFound();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            PersonDto? ret = _db.Set<Person>()
                .Where(p => p.Id == id)
                .Select(p => _personMapper.ToDto(p))
                .FirstOrDefault();
            if (ret is null)
                return NotFound();
            return Ok(ret);
        }

        [HttpPost]
        public ActionResult<PersonDto> Post([FromBody] PersonDto person)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Person entity = _personMapper.ToEntity(person);
            entity.Id = 0;
            _db.People.Add(entity);
            if (_db.SaveChanges() > 0)
                return Ok(_personMapper.ToDto(entity));
            return BadRequest("person could not be created");
        }

        [HttpPut()]
        public ActionResult<PersonDto> Put([FromBody] PersonDto person)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Person? entity = _db.People.FirstOrDefault(p=>p.Id == person.Id);
            if(entity is null) 
                return NotFound();
            _personMapper.UpdateValues(person, ref entity);
            if (_db.SaveChanges() > 0)
                return Accepted(_personMapper.ToDto(entity));
            return BadRequest("person could not be updated");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Person? entity = _db.People.FirstOrDefault(p => p.Id == id);
            if (entity is null)
                return NotFound();

            _db.People.Remove(entity);
            if(_db.SaveChanges() > 0)
                return NoContent();
            return BadRequest("person could not be deleted");
        }
    }
}