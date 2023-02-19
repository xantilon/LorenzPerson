using PersonApi.Helpers.Enums;

namespace PersonApi.Data.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = "";
        public string SurName { get; set; } = "";
        public eGender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
    }
}
