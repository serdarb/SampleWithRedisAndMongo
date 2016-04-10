using System;
using Project.Common.Models;
using Project.Common.Models.Request;
using Project.WebClient.ViewModels;

namespace Project.WebClient.Mappers
{
    public static class PersonMapper
    {
        public static PersonUpdateRequest MapUpdateRequestFromViewModel(PersonViewModel model)
        {
            var request = new PersonUpdateRequest();

            request.UId = model.UId;
            request.FirstName = model.FirstName;
            request.LastName = model.LastName;            
            request.Phone = model.Phone;

            return request;
        }

        public static PersonInsertRequest MapRequestFromViewModel(PersonViewModel model)
        {
            var request = new PersonInsertRequest();

            request.FirstName = model.FirstName;
            request.LastName = model.LastName;
            request.Email = model.Email;
            request.Phone = model.Phone;

            return request;
        }

        internal static PersonViewModel MapViewModelFromModel(PersonModel model)
        {
            var viewModel = new PersonViewModel();

            viewModel.FirstName = model.FirstName;
            viewModel.LastName = model.LastName;
            viewModel.Email = model.Email;
            viewModel.Phone = model.Phone;
            viewModel.UId = model.UId;

            return viewModel;
        }
    }
}