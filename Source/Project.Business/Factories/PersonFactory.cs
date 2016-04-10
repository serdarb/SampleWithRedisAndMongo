using Project.Data.Entity;

namespace Project.Business.Factories
{
    public static class PersonFactory
    {
        public static Person CreatePerson()
        {
            var person = new Person();
            return person;
        }
    }
}
