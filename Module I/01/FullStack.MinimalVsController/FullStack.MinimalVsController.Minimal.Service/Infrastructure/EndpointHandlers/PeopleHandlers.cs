using FullStack.MinimalVsController.Minimal.Service.Application;
using FullStack.MinimalVsController.Minimal.Service.Application.Dto;
using Microsoft.AspNetCore.Http.HttpResults;


namespace FullStack.MinimalVsController.Minimal.Service.Infrastructure.EndpointHandlers
{
    public static class PeopleHandlers
    {
        public static Ok<List<PersonDto>> GetPeople(
            IPersonService personService            
        )
        {
            return TypedResults.Ok(personService.GetPeople());
        }
        public static Ok<PersonDto> GetPersonByName(
            IPersonService personService, 
            string name
        )
        {
            return TypedResults.Ok(personService.GetPersonByName(name));
        }
        public static PersonDto CreatePerson(
           IPersonService personService,
           PersonDto person
        )
        {
          return personService.CreatePerson(person);
        }
    }
}
