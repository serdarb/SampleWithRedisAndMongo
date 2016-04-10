namespace Project.Common.Models.Request
{
    public class PersonSelectPageRequest : BaseRequest
    {
        public string Filter { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public PersonSelectPageRequest(int skip, int take, string filter)
        {
            Skip = skip;
            Take = take;
            Filter = filter;
        }

        public void MakeValid()
        {
            if (Skip < 0)
            {
                Skip = 0;
            }

            if (Take > 100)
            {
                Take = 100;
            }
        }

        public override bool IsNotValid()
        {
            MakeValid();
            return false;
        }
    }
}
