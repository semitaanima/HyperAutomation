using OpenQA.Selenium;

namespace HyperTestAutomation
{
    public class MainPage : WebPage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => string.Empty;
    }
}