using PersonApi.Helpers.Enums.v2;

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

        public bool CanDisplayInV1 => Gender != eGender.Diverse;
    }
}
