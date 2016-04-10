using Project.Common.Helpers;

namespace Project.Common.Models.Request
{
    public class PersonSelectRequest : BaseRequest
    {
        public string UId { get; set; }

        public override bool IsNotValid()
        {
            var result = UId.IsEmpty();
            return result;
        }
    }
}
