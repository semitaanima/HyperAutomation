using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TestEngine.WaitStrategy;

namespace TestEngine.Core
{
    public abstract class WebPage
    {
        public WebPage(IWebDriver driver)
        {
            Driver = driver;

            WaitStrategy = new WaitStrategies();
            WebDriverWait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
        }

        protected IWebDriver Driver { get; set; }

        protected WaitStrategies WaitStrategy { get; set; }

        protected WebDriverWait WebDriverWait { get; set; }

        protected abstract string Url { get; }

        protected IWebElement WaitAndFindElement(By locator)
        {
            return WaitStrategy.WaitAndFindElement(Driver, locator);
        }

        protected IWebElement FindButtonByTextContaining(string text)
        {
            string xpathExpression = $"//button[text() = '{text}']";
            return WaitStrategy.WaitAndFindElement(Driver, By.XPath(xpathExpression));
        }

        protected IWebElement FindSpanByTextContaining(string text)
        {
            string xpathExpression = $"//span[text() = '{text}']";
            return WaitStrategy.WaitAndFindElement(Driver, By.XPath(xpathExpression));
        }

        protected IWebElement FindParagraphByTextContaining(string text)
        {
            string xpathExpression = $"//p[text() = '{text}']";
            return WaitStrategy.WaitAndFindElement(Driver, By.XPath(xpathExpression));
        }

        public void GoTo()
        {
            string urlbuilder = ConfigurationService.GetValueFromConfigFile("baseUrl") + Url;
            Driver.Navigate().GoToUrl(urlbuilder);
            WaitForCompletePageLoad();
        }

        public void AssertNavigated()
        {
            WaitForCompletePageLoad();
            Assert.IsTrue(Driver.Url.Contains(Url), "The loaded page is not as expected!");
        }

        protected virtual void WaitForPageToLoad() { }

        protected void WaitForCompletePageLoad()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}