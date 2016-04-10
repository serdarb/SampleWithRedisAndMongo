using FakeItEasy;
using Xunit;

using Project.Common.Models.Response;
using Project.Data.Repository;
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
