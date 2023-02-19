using PersonApi.Helpers.Enums;

namespace PersonApi.Data.DTOs.v1
{
    /// <summary>
    /// this should be a useful documentation
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="FirstName"></param>
    /// <param name="SurName"></param>
    /// <param name="Gender"></param>
    /// <param name="Birthday"></param>
    public record PersonDto(int Id,
                            string FirstName,
                            string SurName,
                            eGender Gender,
                            DateOnly Birthday) : BaseDto(Id);
}
