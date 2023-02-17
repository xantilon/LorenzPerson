using PersonApi.Helpers.Enums;

namespace PersonApi.DTOs.v2
{
    public record PersonDto(int Id,
                            string FirstName,
                            string SurName,
                            eGender Gender,
                            DateTime Birthday,
                            string City,
                            string Country) : BaseDto(Id);
}
