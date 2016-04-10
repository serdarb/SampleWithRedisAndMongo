using System.Collections.Generic;

namespace Project.Common.Models.Response
{
    public class PersonSelectPageResponse : BaseResponse
    {
        public List<PersonModel> Items { get; set; }
        public long TotalCount { get; set; }

        public PersonSelectPageResponse()
        {
            Items = new List<PersonModel>();
        }
    }
}
