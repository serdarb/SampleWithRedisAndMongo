using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Project.Common.Models.Request;
using Project.Common.Models.Response;
using Project.Business;
using Project.Data.Repository;
using FakeItEasy;
using Project.Business.Test.Helpers;

namespace Project.Business.Test
{
    public class PersonServiceUnitTests
    {
        [Fact]
        public void PersonService_Insert_ReturnsPersonInsertResponse()
        {
            //arrange
            var request = TestHelper.GetPersonInsertRequest();

            var repository = A.Fake<PersonRepository>();
            var service = new PersonService(repository);

            //act
            var response = service.Insert(request);

            //assert
            Assert.IsType<PersonInsertResponse>(response);
        }
    }
}
