using Bogus;
using PersonApi.Helpers.Enums;

namespace PersonApi.Helpers.SampleData;

public class PersonFaker : Faker<Data.Models.Person>
{
    //private static int index = 1;
    public PersonFaker()
    {
        Locale = "de";
        RuleFor(p => p.Id, f => f.IndexGlobal + 1);
        RuleFor(p => p.FirstName, f => f.Name.FirstName());
        RuleFor(p => p.SurName, f => f.Name.LastName());
        RuleFor(p => p.Birthday, f => f.Date.Between(
            DateTime.Now.AddYears(-85), 
            DateTime.Now.AddYears(-15)
        ));
        RuleFor(p => p.Gender, f => f.PickRandom<eGender>());
        RuleFor(p => p.City, f => f.Address.City());
        RuleFor(p => p.Country, f => f.Address.Country());
    }


}
