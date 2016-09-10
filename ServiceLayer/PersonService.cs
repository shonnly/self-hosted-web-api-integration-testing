namespace ServiceLayer
{
    using System.Collections.Generic;

    public class PersonsService : IValuesService
    {
        public PersonModel GetPerson()
        {
            return new PersonModel
            {
                Name = "John Petrucci"
            };
        } 
    }
}
