using Project.Business.Test.Helpers;
using Project.Common.Models;
using Project.Common.Models.Request;
using Project.Common.Models.Response;
using Project.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.Business.Test
{
    public class PersonServiceIntegrationTests
    {
        public PersonService GetPersonService()
        {
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            return service;
        }

        [Fact]
        public void PersonService_Insert()
        {
            //arrange
            var request = TestHelper.GetPersonInsertRequest();
            var service = GetPersonService();

            //act
            var response = service.Insert(request);

            //assert
            Assert.IsType<PersonInsertResponse>(response);

            Assert.IsType<bool>(response.Status);
            Assert.True(response.Status);
        }

        [Fact]
        public void PersonService_SelectOne()
        {
            //arrange
            var service = GetPersonService();

            var insertRequest = TestHelper.GetPersonInsertRequest();
            var insertResponse = service.Insert(insertRequest);

            var request = TestHelper.GetPersonSelectRequest(insertResponse.Model.UId);           

            //act
            var response = service.Select(request);

            //assert
            Assert.NotNull(response);
            Assert.IsType<PersonSelectResponse>(response);
            Assert.NotNull(response.Model);
            Assert.IsType<PersonModel>(response.Model);
        }
    }
}
