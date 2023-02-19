using PersonApi.Helpers.Enums;

namespace PersonApi.Data.DTOs.v2
{
    public record PersonDto(int Id,
                            string FirstName,
                            string SurName,
                            eGender Gender,
                            DateOnly Birthday,
                            string City,
                            string Country) : BaseDto(Id);
}
