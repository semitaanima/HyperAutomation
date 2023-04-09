using OpenQA.Selenium;

namespace TestEngine.FindStrategy
{
    public class FindStrategies
    {
        private static IWebDriver _driver;

        public FindStrategies(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FindElementByCss(string cssSelector)
        {
            return _driver.FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement FindElementByXpath(string xpath)
        {
            return _driver.FindElement(By.XPath(xpath));
        }
    }
}