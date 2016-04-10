using System.Web.Security;

namespace Project.WebClient.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        public void SignIn(string id, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(id, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    public interface IAuthHelper
    {
        void SignIn(string id, bool createPersistentCookie);

        void SignOut();
    }
}