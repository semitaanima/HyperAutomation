using NUnit.Framework.Internal;

namespace Undertest
{
    [TestFixture]
    public class MainTest : BaseTest
    {
        [Test]
        public void TestOne()
        {
            MainPage.GoTo();
            MainPage.AssertNavigated();
            LoggingService.LogInformation("The test has passed successfully!");
        }
    }
}