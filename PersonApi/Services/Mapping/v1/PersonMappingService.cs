using PersonApi.Data.DTOs.v1;
using PersonApi.Data.Models;
using PersonApi.Helpers.Enums.v1;

namespace PersonApi.Services.Mapping.v1
{
    public class PersonMappingService : IMappingService<Person, PersonDto>
    {
        public PersonDto ToDto(Person person)
        {
            return new PersonDto(
                person.Id,
                person.FirstName,
                person.SurName,
                (eGender)(int)person.Gender,
                new DateOnly(person.Birthday.Year, person.Birthday.Month, person.Birthday.Day)
            );
        }

        public Person ToEntity(PersonDto dto)
        {
            return new Person
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                SurName = dto.SurName,
                Gender = (Helpers.Enums.v2.eGender)(int)dto.Gender,
                Birthday = dto.Birthday.ToDateTime(new())
            };
        }

        public List<PersonDto> ToDto(IEnumerable<Person> people) => people.Select(i => ToDto(i)).ToList();
        public List<Person> ToEntity(IEnumerable<PersonDto> peopleDtos) => peopleDtos.Select(p => ToEntity(p)).ToList();

        public void UpdateValues(in PersonDto dto, ref Person entity)
        {
            entity.FirstName = dto.FirstName;
            entity.SurName = dto.SurName;
            entity.Gender = (Helpers.Enums.v2.eGender)(int)dto.Gender;
            entity.Birthday = dto.Birthday.ToDateTime(new());
        }       
    }
}
