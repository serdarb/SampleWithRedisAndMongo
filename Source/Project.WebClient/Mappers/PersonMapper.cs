using Project.Common.Models.Request;
using Project.WebClient.ViewModels;

namespace Project.WebClient.Mappers
{
    public static class PersonMapper
    {
        public static PersonInsertRequest MapRequestFromViewModel(PersonViewModel model)
        {
            var request = new PersonInsertRequest();

            request.FirstName = model.FirstName;
            request.LastName = model.LastName;
            request.Email = model.Email;
            request.Phone = model.Phone;

            return request;
        }
    }
}