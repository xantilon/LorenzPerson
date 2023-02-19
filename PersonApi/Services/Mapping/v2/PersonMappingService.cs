using PersonApi.Data.DTOs.v2;
using PersonApi.Data.Models;

namespace PersonApi.Services.Mapping.v2
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
                new DateOnly(person.Birthday.Year, person.Birthday.Month, person.Birthday.Day),
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
                Birthday = dto.Birthday.ToDateTime(new()),
                City = dto.City,
                Country = dto.Country
            };
        }

        public List<PersonDto> ToDto(IEnumerable<Person> people) => people.Select(i => ToDto(i)).ToList();
        public List<Person> ToEntity(IEnumerable<PersonDto> peopleDtos) => peopleDtos.Select(p => ToEntity(p)).ToList();

        public void UpdateValues(in PersonDto dto, ref Person entity)
        {
            entity.FirstName = dto.FirstName;
            entity.SurName = dto.SurName;
            entity.Gender = dto.Gender;
            entity.Birthday = dto.Birthday.ToDateTime(new());
            entity.City = dto.City;
            entity.Country = dto.Country;
        }
    }
}
