using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace TestEngine.Core
{
    public class DriverFactory
    {
        // Implementing with singleton pattern
        private static DriverFactory _instance;

        private DriverFactory() { }

        public static DriverFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DriverFactory();

                return _instance;
            }
        }

        public IWebDriver CreateWebDriver()
        {
            string json = File.ReadAllText(GlobalVariables.ConfigFilePath);
            JObject jsonObj = JObject.Parse(json);
            string browserType = (string)jsonObj.GetValue("browserType");

            if (browserType == "chrome")
                return CreateChromeDriver();
            else
                throw new ArgumentException("Unsupported BrowserType: " + browserType.ToString());
        }

        internal IWebDriver CreateChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            return driver;
        }

        public void ExitDriver(IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver = null;
            }
        }
    }
}