using System.Net.Mail;

namespace Project.Common.Helpers
{
    public static class EmailHelper
    {
        public static bool IsEmail(this string text)
        {
            try
            {
                new MailAddress(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNotEmail(this string text)
        {
            return !IsEmail(text);
        }
    }
}
