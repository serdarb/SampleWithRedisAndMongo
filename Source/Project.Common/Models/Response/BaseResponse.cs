namespace Project.Common.Models.Response
{
    public abstract class BaseResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
