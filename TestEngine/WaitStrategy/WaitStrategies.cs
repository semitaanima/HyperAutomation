using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestEngine.Core;

namespace TestEngine.WaitStrategy
{
    public class WaitStrategies
    {
        //Function to find element and wait for it to appear
        public IWebElement WaitAndFindElement(IWebDriver webDriver, By locator)
        {
            int maxWaitTimeInInt = int.Parse(ConfigurationService.GetValueFromConfigFile("maxWaitTimetoFindElement"));
            if (maxWaitTimeInInt > 0)
            {
                new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(maxWaitTimeInInt)).Until(condition: ExpectedConditions.ElementExists(locator));
                return webDriver.FindElement(locator);
            }
            return webDriver.FindElement(locator);
        }

        //Function to wait until a single element is visible
        internal IWebElement WaitToBeVisible(IWebDriver webDriver, IWebElement element)
        {
            int maxWaitTimeInInt = int.Parse(ConfigurationService.GetValueFromConfigFile("maxWaitTimeElementToBeVisible"));
            if (maxWaitTimeInInt > 0)
            {
                new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(maxWaitTimeInInt)).Until(condition: ExpectedConditions.ElementIsVisible((By)element));
            }
            return element;
        }

        //Function to wait until a single element is clickable
        internal IWebElement WaitToBeClickable(IWebDriver webDriver, IWebElement element)
        {
            int maxWaitTimeInInt = int.Parse(ConfigurationService.GetValueFromConfigFile("maxWaitTimeElementToBeClickable"));
            if (maxWaitTimeInInt > 0)
            {
                new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(maxWaitTimeInInt)).Until(condition: ExpectedConditions.ElementToBeClickable(element));
            }
            return element;
        }

        //Function to wait until a single element is visible with a polling rate
        internal IWebElement WaitForElementToBeVisible(IWebDriver webDriver, IWebElement element)
        {
            int maxWaitTimeInInt = int.Parse(ConfigurationService.GetValueFromConfigFile("maxWaitTimeElementToBeClickable"));
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(maxWaitTimeInInt));
                wait.PollingInterval = TimeSpan.FromMilliseconds((int)WaitTime.DefaultMilliseconds);
                wait.Until(ExpectedConditions.ElementIsVisible((By)element));
            }
            catch (TimeoutException)
            {
                throw new Exception("Unable to find the required element!");
            }
            return element;
        }

        //Function to do a static implicit wait
        internal void ThreadSleep(WaitTime waitTime)
        {
            Thread.Sleep((int)waitTime);
        }
    }
}