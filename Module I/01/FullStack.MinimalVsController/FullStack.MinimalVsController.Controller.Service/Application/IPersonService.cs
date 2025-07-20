using FullStack.MinimalVsController.Controller.Service.Application.Dto;

namespace FullStack.MinimalVsController.Controller.Service.Application
{
    public interface IPersonService
    {
        void CreatePeople();
        List<PersonDto> GetPeople();
        PersonDto GetPersonByName(string name);
    }
}
