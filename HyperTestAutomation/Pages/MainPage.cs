using OpenQA.Selenium;

namespace Undertest
{
    public class MainPage : WebPage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => string.Empty;
    }
}