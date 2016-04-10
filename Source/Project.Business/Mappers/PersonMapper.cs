using Project.Business.Factories;
using Project.Common.Models.Request;
using Project.Data.Entity;
using Project.Common.Models;

namespace Project.Business.Mappers
{
    public static class PersonMapper
    {
        public static Person MapEntityFromRequest(PersonInsertRequest request)
        {
            var person = PersonFactory.CreatePerson();

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.Phone = request.Phone;            

            return person;
        }

        internal static PersonModel MapModelFromEntity(Person entity)
        {
            var model = new PersonModel();

            model.UId = entity.UId;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Email = entity.Email;
            model.Phone = entity.Phone;

            return model;
        }
    }
}
