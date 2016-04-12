using OpenQA.Selenium.Chrome;
using Xunit;

namespace Project.Business.Test
{
    public class PersonAcceptanceTests
    {
        public const string BASE_URL = "http://localhost:4630";

        [Fact]
        public void should_add_person()
        {
            var browser = new ChromeDriver();
            browser.Navigate().GoToUrl($"{BASE_URL}/Person/New");

            browser.FindElementById("FirstName").SendKeys("test first name");
            browser.FindElementById("LastName").SendKeys("test last name");
            browser.FindElementById("Email").SendKeys("test@test.com");
            browser.FindElementById("Phone").SendKeys("0905556669988");

            browser.FindElementById("btnSave").Click(); 

            Assert.NotNull(browser);
            Assert.True(browser.PageSource.Contains("Person Detail View"));

            browser.Close();
        }
    }
}
