namespace Project.Common.Models.Request
{
    public abstract class BaseRequest
    {
        public abstract bool IsNotValid();

        public bool IsValid()
        {
            return !IsNotValid();
        }
    }
}
