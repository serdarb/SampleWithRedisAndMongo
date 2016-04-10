using Project.Common.Helpers;

namespace Project.Common.Models.Request
{
    public class PersonInsertRequest : BaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override bool IsNotValid()
        {
            var result = Email.IsNotEmail();
            return result;
        }
    }
}
