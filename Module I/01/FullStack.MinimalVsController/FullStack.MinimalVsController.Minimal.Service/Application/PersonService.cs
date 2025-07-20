using FullStack.MinimalVsController.Minimal.Service.Application.Dto;
using FullStack.MinimalVsController.Minimal.Service.Infrastructure.Data;

namespace FullStack.MinimalVsController.Minimal.Service.Application
{
    public class PersonService : IPersonService
    {
        private List<Person> _people;
        public PersonService()
        {
            CreatePeople();
        }
        public List<PersonDto> GetPeople()
        {
            List<PersonDto> people = new List<PersonDto>();
            foreach (var person in _people)
            {
                people.Add(new PersonDto { Name = person.Name, LastName = person.LastName, Age = person.Age });
            }
            return people;
        }
        public PersonDto GetPersonByName(string name)
        {
            var person = _people.FirstOrDefault(p => p.Name == name);
            if (person != null)
            {
                return new PersonDto { Name = person.Name, LastName = person.LastName, Age = person.Age };
            }
            return null;
        }
        public PersonDto CreatePerson(PersonDto person)
        {
            _people.Add(new Person { Name = person.Name, LastName = person.LastName, Age = person.Age });
            return person;
        }
        public void CreatePeople()
        {
            _people = new List<Person>();
            _people.Add(new Person { Name = "Erick", LastName = "Arostegui", Age = 40 });
            _people.Add(new Person { Name = "Juan", LastName = "Perez", Age = 39 });
            _people.Add(new Person { Name = "Jose", LastName = "Lopez", Age = 25 });
            _people.Add(new Person { Name = "Pedro", LastName = "Picapiedra", Age = 21 });
            _people.Add(new Person { Name = "Luis", LastName = "Rodriguez", Age = 32 });
            _people.Add(new Person { Name = "Jorge", LastName = "Diaz", Age = 37 });
            _people.Add(new Person { Name = "María", LastName = "Sarmiento", Age = 19 });
        }
    }
}
