using OpenQA.Selenium;

namespace HyperTestAutomation
{
    public class BaseTest
    {
        protected static IWebDriver Driver { get; set; }

        protected static LoggingService LoggingService { get; set; }

        #region WebPages
        public MainPage MainPage => LazyMainPage.Value;
        #endregion

        [SetUp]
        public void TestInit()
        {
            Driver = DriverFactory.Instance.CreateWebDriver();
            LoggingService = new LoggingService();
        }

        [TearDown]
        public void TearDown()
        {
           DriverFactory.Instance.ExitDriver(Driver);
        }

        #region WebPages LazyLoading
        private Lazy<MainPage> LazyMainPage = new Lazy<MainPage>(() => new MainPage(Driver));
        #endregion
    }
}