using FullStack.MinimalVsController.Minimal.Service.Application.Dto;

namespace FullStack.MinimalVsController.Minimal.Service.Application
{
    public interface IPersonService
    {
        void CreatePeople();
        PersonDto CreatePerson(PersonDto person);
        List<PersonDto> GetPeople();
        PersonDto GetPersonByName(string name);
    }
}