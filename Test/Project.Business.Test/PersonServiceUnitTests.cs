using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Project.Common.Models.Request;
using Project.Common.Models.Response;
using Project.Business;

namespace Project.Business.Test
{
    public class PersonServiceUnitTests
    {
        [Fact]
        public void PersonService_Insert_ReturnsPersonInsertResponse()
        {
            //arrange
            var request = new PersonInsertRequest();
            var service = new PersonService();

            //act
            var response = service.Insert(request);

            //assert
            Assert.IsType<PersonInsertResponse>(response);
        }
    }
}
