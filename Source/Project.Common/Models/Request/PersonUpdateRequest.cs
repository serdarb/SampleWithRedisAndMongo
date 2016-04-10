using Project.Common.Helpers;

namespace Project.Common.Models.Request
{
    public class PersonUpdateRequest : BaseRequest
    {
        public string UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public override bool IsNotValid()
        {
            var result = UId.IsEmpty();
            return result;
        }
    }
}
