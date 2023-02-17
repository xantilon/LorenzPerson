using PersonApi.DTOs.v2;
using PersonApi.Models;

namespace PersonApi.Helpers.Mapping.v2
{
    public class PersonMappingService : IMappingService<Person, PersonDto>
    {
        public PersonDto ToDto(Person person)
        {
            return new PersonDto(
                person.Id,
                person.FirstName,
                person.SurName,
                person.Gender,
                person.Birthday,
                person.City,
                person.Country
            );
        }

        public Person ToEntity(PersonDto dto)
        {
            return new Person
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                SurName = dto.SurName,
                Gender = dto.Gender,
                Birthday = dto.Birthday,
                City = dto.City,
                Country = dto.Country
            };
        }

        public List<PersonDto> ToDto(IEnumerable<Person> people) => people.Select(i => ToDto(i)).ToList();
        public List<Person> ToEntity(IEnumerable<PersonDto> peopleDtos) => peopleDtos.Select(p => ToEntity(p)).ToList();
    }
}
