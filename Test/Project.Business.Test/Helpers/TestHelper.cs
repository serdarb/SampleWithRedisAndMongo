using System;
using Project.Common.Models.Request;

namespace Project.Business.Test.Helpers
{
    public static class TestHelper
    {
        public static PersonInsertRequest GetPersonInsertRequest()
        {
            var request = new PersonInsertRequest();
            request.FirstName = "John";
            request.LastName = "Doe";
            request.Email = "john@doe.com";
            request.Phone = "0090 555 669 99 88";
            return request;
        }

        public static PersonSelectRequest GetPersonSelectRequest(string uid)
        {
            var request = new PersonSelectRequest();
            request.UId = uid;
            return request;
        }

        internal static PersonUpdateRequest GetPersonUpdateRequest(PersonSelectRequest selectRequest, PersonInsertRequest insertRequest)
        {
            var request = new PersonUpdateRequest();
            request.UId = selectRequest.UId;
            request.FirstName = insertRequest.FirstName;
            request.LastName = insertRequest.LastName;
            request.Phone = insertRequest.Phone;

            return request;
        }
    }
}
