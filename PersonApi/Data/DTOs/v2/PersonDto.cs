using PersonApi.Helpers.Enums.v2;

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
